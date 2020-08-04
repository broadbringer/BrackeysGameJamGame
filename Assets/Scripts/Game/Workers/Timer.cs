using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using TMPro;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class Timer : MonoBehaviour
{
    private GameSessionData _gameData;
    private float dayTime;
    private EventsManager _eventsManager;
    public float TimeScale = 1;
    
    private void Start()
    {
        _gameData = Application.GetInstance().GameSessionData;
        _eventsManager = Application.GetInstance().EventsManager;
    }
    public void Update()
    {
        Time.timeScale = TimeScale;
        if (_gameData.TimeLeft > 0)
        {
            CountDown();
            return;
        }
        TimeSpend();
    }

    private void TimeSpend()
    {
        _gameData.DayState = DayState.DayOver;
        _gameData.TimeLeft = Application.GetInstance().GameSessionData.OneDayInSecond;
        _eventsManager.OnDayIsOver();
        _gameData.DayState = DayState.DayContinue;
    }
    private void CountDown()
    {
        _gameData.TimeLeft -= Time.deltaTime;
    }
}
