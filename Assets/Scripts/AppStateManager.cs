//using HoloToolkitExtensions;
using UnityEngine;
using System;

public class AppStateManager : BaseAppStateManager
{
    public int totalScore = 0;
    public TimeSpan totalTime;
    public int touchCubeCount = 0;
    public int maxCubeCount;

    private TimeSpan startTime;
    private bool isStarting;

    public void StartGame()
    {
        isStarting = true;
        startTime = new TimeSpan(DateTime.Now.Ticks);
    }

    public void EndGame()
    {
        isStarting = false;
        TimeSpan now = new TimeSpan(DateTime.Now.Ticks);
        totalTime = now.Subtract(startTime).Duration();

        touchCubeCount = 0;
    }

    private void Update()
    {
        if (isStarting)
        {
            TimeSpan now = new TimeSpan(DateTime.Now.Ticks);
            totalTime = now - startTime;
        }
        if (touchCubeCount >= maxCubeCount)
        {
            EndGame();
        }

    }

    public static new AppStateManager Instance
    {
        get { return (AppStateManager)BaseAppStateManager.Instance; }
    }

    


}