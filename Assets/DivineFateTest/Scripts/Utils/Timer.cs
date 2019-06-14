using UnityEngine;
using System.Collections;
using CustomEvents;

public class Timer
{

    CustomEvent onExpireEvent;
    public CustomEvent onExpire
    {
        get { return onExpireEvent; }
        set { onExpireEvent = value; }
    }

    bool isRunning;

    float t_ini; //When it started
    public float startTime
    {
        get { return t_ini; }
        //set { t_end = value; } //Should not be used
    }

    float t_end; //When it has to end from the starting time
    public float endTime
    {
        get { return t_end; }
        set { t_end = value * (1.0f / 60.0f); }
    }

    public Timer(float end, CustomEvent e)
    {
        t_ini = Time.time;
        t_end = end * (1.0f / 60.0f);
        onExpireEvent = e;
    }

    public Timer()
    {
        t_ini = 0;
        t_end = 9999999999;
        onExpireEvent = null;
    }

    public void Initialize(float end, CustomEvent e)
    {
        t_ini = Time.time;
        t_end = end * (1.0f / 60.0f);
        onExpireEvent = e;
    }

    public float GetTime()
    {
        return Time.time - t_ini;
    }

    public void Enable()
    {
        TimerRunner.timerRunner.AddTimer(this);
    }

    public void Disable()
    {
        TimerRunner.timerRunner.RemoveTimer(this);
    }

    public void Start()
    {
        t_ini = Time.time;
        isRunning = true;
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void Reset()
    {
        //Post: Restarts to current time
        t_ini = Time.time;
    }

    public void Restart()
    {
        //Post: Restarts to when it should have ended
        Debug.Log("RESTARTED");
        t_ini = Time.time - (Time.time - (t_ini + t_end)); //Adjust the difference so the time is "strict"
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public void Run()
    {
        if (!isRunning) return;
        if (Time.time > (t_ini + t_end))
        {
            Debug.Log("Timer Is: T_Ini = " + t_ini + ", T_End = " + (t_ini + t_end));
            Debug.Log("IT IS ALIVE:" + Time.time);
            onExpireEvent.Invoke();
        }
    }

}
