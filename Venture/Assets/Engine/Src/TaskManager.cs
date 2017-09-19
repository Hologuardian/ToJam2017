using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;

namespace Assets.Engine
{
    public struct TaskHeuristic
    {
        public TaskHeuristic(List<float> times)
        {
            timesRun = times.Count;
            averageTime = 0;
            foreach (float time in times)
            {
                averageTime += time;
            }
            averageTime /= timesRun;
        }

        public TaskHeuristic(float time)
        {
            timesRun = 1;
            averageTime = time;
        }

        public void AddTime(float time)
        {
            averageTime *= timesRun;
            averageTime += time;
            timesRun++;
            averageTime /= timesRun;
        }

        int timesRun;
        public float averageTime;
    }

    public class TaskManager : MonoBehaviour
    {
        List<Thread> threadPool;
        static BlockingPriorityQueue<TaskNode> taskList;
        static BlockingPriorityQueue<TaskNode> unityTaskList;
        static BlockingPriorityQueue<TaskNode> physicsTaskList;
        static bool running = true;
        public int allocatedTime = 16;
        public int allocatedPhysicsTime = 16;

        Dictionary<string, TaskHeuristic> taskHeuristics = new Dictionary<string, TaskHeuristic>();

        public void QueueUnityTask(TaskNode t, float priority)
        {
            if(taskHeuristics.ContainsKey(t.name))
            {
                priority += taskHeuristics[t.name].averageTime * 0.01f;
            }
            t.Priority = priority;
            unityTaskList.Add(t);
        }

        public void QueuePhysicsTask(TaskNode t, float priority)
        {
            if (taskHeuristics.ContainsKey(t.name))
            {
                priority += taskHeuristics[t.name].averageTime * 0.01f;
            }
            t.Priority = priority;
            physicsTaskList.Add(t);
        }

        public void QueueTask(TaskNode t, float priority)
        {
            if (taskHeuristics.ContainsKey(t.name))
            {
                priority += taskHeuristics[t.name].averageTime * 0.01f;
            }
            t.Priority = priority;
            taskList.Add(t);
        }

        [Range(1, 32)]
        public int ThreadLimit = 4;
        void Start()
        {
            threadPool = new List<Thread>();
            taskList = new BlockingPriorityQueue<TaskNode>();
            unityTaskList = new BlockingPriorityQueue<TaskNode>();
            physicsTaskList = new BlockingPriorityQueue<TaskNode>();
            for (int i = 0; i < ThreadLimit; i++)
            {
                Thread t = new Thread(Execute);
                t.Start();
                threadPool.Add(t);
            }
            StartCoroutine(ExecuteUnityTasks());
            StartCoroutine(ExecutePhysicsTask());

            TaskHelper.TaskManager = this;
        }

        private IEnumerator ExecuteUnityTasks()
        {
            while (running)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();
                while (stopwatch.ElapsedMilliseconds < allocatedTime)
                {
                    Stopwatch taskTime = Stopwatch.StartNew();

                    TaskNode node = unityTaskList.CheckPop();
                    if (node == null)
                        break;
                    node.task.Invoke();

                    if (taskHeuristics.ContainsKey(node.name))
                    {
                        taskHeuristics[node.name].AddTime(taskTime.ElapsedMilliseconds);
                    }
                    else
                    {
                        taskHeuristics.Add(node.name, new TaskHeuristic(taskTime.ElapsedMilliseconds));
                    }
                    taskTime.Stop();
                }
                stopwatch.Stop();
                yield return new WaitForEndOfFrame();
            }
        }

        public IEnumerator ExecutePhysicsTask()
        {
            while (running)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();
                while (stopwatch.ElapsedMilliseconds < allocatedPhysicsTime)
                {
                    Stopwatch taskTime = Stopwatch.StartNew();

                    TaskNode node = physicsTaskList.CheckPop();
                    if (node == null)
                        break;
                    node.task.Invoke();

                    if(taskHeuristics.ContainsKey(node.name))
                    {
                        taskHeuristics[node.name].AddTime(taskTime.ElapsedMilliseconds);
                    }
                    else
                    {
                        taskHeuristics.Add(node.name, new TaskHeuristic(taskTime.ElapsedMilliseconds));
                    }
                    taskTime.Stop();
                }
                stopwatch.Stop();
                yield return new WaitForFixedUpdate();
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            running = false;
        }

        private static void Execute()
        {
            while (running)
            {
                TaskNode node = taskList.Pop();
                node.task.Invoke();
            }
        }
    }
}