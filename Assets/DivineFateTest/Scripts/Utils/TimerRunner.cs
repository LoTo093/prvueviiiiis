using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerRunner : MonoBehaviour
{

    static TimerRunner t;
    public static TimerRunner timerRunner
    {
        get
        {
            if (t == null)
            {
                t = (TimerRunner)GameObject.Find("GlobalSystem/TimerRunner").GetComponent<TimerRunner>();
                if (t.NotInitialized())
                {
                    t.Initialize();
                }
            }
            return t;
        }
    }

    TimerRunner()
    {
        Initialize();
    }

    List<Timer> allTimers;
    bool notInitialized;

    public void AddTimer(Timer t)
    {
        allTimers.Add(t);
    }

    public void RemoveTimer(Timer t)
    {
        allTimers.Remove(t);
    }

    void RunAll()
    {
        for (int i = 0; i < allTimers.Count; i++)
        {
            allTimers[i].Run();
        }
    }

    public void Initialize()
    {
        allTimers = new List<Timer>();
        notInitialized = false;
    }

    public bool NotInitialized()
    {
        return notInitialized;
    }

    // Use this for initialization
    void Start()
    {
        notInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        RunAll();
    }
}
