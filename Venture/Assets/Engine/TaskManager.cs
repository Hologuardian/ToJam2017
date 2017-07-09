using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public delegate void Task();

public class TaskManager : MonoBehaviour
{
    List<Thread> threadPool;
    static BlockingPriorityQueue<Task> taskList;
    static BlockingPriorityQueue<Task> unityTaskList;
    static BlockingPriorityQueue<Task> physicsTaskList;
    static bool running = true;

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
    }
    
    private void Update()
    {
        //TODO Frame check heuristic and time left in frame
        unityTaskList.Pop().Invoke();
    }

    private void FixedUpdate()
    {
        //TODO Frame check heuristic and time left in frame
        physicsTaskList.Pop().Invoke();
    }

    private void OnDestroy()
    {
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
