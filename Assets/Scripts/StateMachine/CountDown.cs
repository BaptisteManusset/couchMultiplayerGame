using System;
using UnityEngine;

[Serializable]
public class CountDown
{
    public float duration = 0;
    public float progress = 0;
    public bool started = false;
    public bool paused = false;
    public bool finish = false;

    public float normalizedProgress => progress / duration;

    public CountDown(float a_duration = 0, bool a_started = false)
    {
        progress = a_duration;
        duration += a_duration;
    }


    public void Update()
    {
        if (started == false)
        {
            Debug.Log("No started");
            return;
        }

        if (finish)
        {
            Debug.Log("finish");
            return;
        }

        if (paused)
        {
            Debug.Log("paused");
            return;
        }

        progress -= Time.deltaTime;
        if (progress <= 0)
        {
            finish = true;
        }
    }

    public void SetDurationAndStart(int a_duration = 1)
    {
        SetDuration(a_duration);
        started = true;
    }

    public void SetDuration(int a_duration = 1)
    {
        duration = a_duration;
        progress = a_duration;
    }
}