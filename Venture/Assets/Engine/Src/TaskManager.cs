using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;

public class TaskManager : MonoBehaviour
{
    List<Thread> threadPool;
    static BlockingPriorityQueue<TaskNode> taskList;
    static BlockingPriorityQueue<TaskNode> unityTaskList;
    static BlockingPriorityQueue<TaskNode> physicsTaskList;
    static bool running = true;
    public int allocatedTime = 16;
    public int allocatedPhysicsTime = 16;

    public void QueueUnityTask(Task t, float priority)
    {
        unityTaskList.Add(new TaskNode(t), priority);
    }

    public void QueuePhysicsTask(Task t, float priority)
    {
        physicsTaskList.Add(new TaskNode(t), priority);
    }

    public void QueueTask(Task t, float priority)
    {
        taskList.Add(new TaskNode(t), priority);
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
            threadPool.Add(t);
        }
        StartCoroutine(ExecuteUnityTasks());
        StartCoroutine(ExecutePhysicsTask());
    }

    private IEnumerator ExecuteUnityTasks()
    {
        while (running)
        {
            yield return new WaitForEndOfFrame();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < allocatedTime)
            {
                //TODO Frame check heuristic
                unityTaskList.Pop().task.Invoke();
            }
            stopwatch.Stop();
        }
    }

    public IEnumerator ExecutePhysicsTask()
    {
        while (running)
        {
            yield return new WaitForFixedUpdate();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < allocatedPhysicsTime)
            {
                //TODO Frame check heuristic
                unityTaskList.Pop().task.Invoke();
            }
            stopwatch.Stop();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        running = false;
    }

    private static void Execute()
    {
        while(running)
        {
            Task t = taskList.Pop().task;
            t.Invoke();
        }
    }
}
