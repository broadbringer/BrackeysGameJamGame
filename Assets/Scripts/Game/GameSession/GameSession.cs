using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class GameSession : MonoBehaviour
{
    [SerializeField] private GameSessionData _gameData;
    private EventsManager _eventsManager;
    private GameEconomy _gameEconomy;

    private void Start()
    {
        _gameData = Application.GetInstance().GameSessionData;
        _eventsManager = Application.GetInstance().EventsManager;
        _eventsManager.CassettSpinnedByClickableWorker += AddToSpinnedCassets;
        _eventsManager.DayIsOver += OnOneDayEnded;
        _gameEconomy = new GameEconomy {DayIndex = _gameData.CurrentDay};
        _gameData.DayState = DayState.DayContinue;
        StartCoroutine(StartOneHourTimer());
    }

    private IEnumerator StartOneHourTimer()
    {
        while (true)
        {
            if (_gameData.DayState == DayState.DayContinue)
            {
                yield return new WaitForSeconds(Application.GetInstance().GameSessionData.OneHourInSeconds);
                OnOneHourEnded(); 
            }
        }
    }

    private void OnOneHourEnded()
    {
        if (_gameData.AIWorkers.Count != 0)
        {
            foreach (var worker in _gameData.AIWorkers)
            {
                worker.SpinCassette();
            }
        }
    }
    
    private void OnOneDayEnded()
    {
        AddToPlayedDays();
        _gameEconomy.SetMoney(_gameData);
        _gameEconomy.SetNextDayCassettGoal(_gameData);
        _gameEconomy.DayIndex++;
    }
    
    private void AddToPlayedDays()
    {
        const int value = 1;
        _gameData.CurrentDay += value;
    }
    
    private void AddToSpinnedCassets(int value)
    {
        if (_gameData.SpinnedCassetts >= _gameData.SpinnedCassettsGoal)
        {
            _gameData.SpinnedCassetts = _gameData.SpinnedCassettsGoal;
            return;
        }
        _gameData.SpinnedCassetts += value;
    }
}

