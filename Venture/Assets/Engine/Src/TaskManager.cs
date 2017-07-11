using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;

public delegate void Task();

public class TaskManager : MonoBehaviour
{
    List<Thread> threadPool;
    static BlockingPriorityQueue<Task> taskList;
    static BlockingPriorityQueue<Task> unityTaskList;
    static BlockingPriorityQueue<Task> physicsTaskList;
    static bool running = true;
    public int allocatedTime = 16;
    public int allocatedPhysicsTime = 16;

    [Range(1, 32)]
    public int ThreadLimit = 4;
    void Start()
    {
        threadPool = new List<Thread>();
        taskList = new BlockingPriorityQueue<Task>();
        unityTaskList = new BlockingPriorityQueue<Task>();
        physicsTaskList = new BlockingPriorityQueue<Task>();
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
                unityTaskList.Pop().Invoke();
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
                unityTaskList.Pop().Invoke();
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
            Task t = taskList.Pop();
            t.Invoke();
        }
    }
}
