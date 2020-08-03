using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class GameSession : MonoBehaviour
{
    private GameSessionData _gameData;
    private EventsManager _eventsManager;
    
    private void Start()
    {
        _gameData = Application.GetInstance().GameSessionData;
        _eventsManager = Application.GetInstance().EventsManager;
        _eventsManager.CassettSpinnedByClickableWorker += AddToSpinnedCassets;
    }
    
    private void AddToMoney(float value)
    {
        _gameData.Money += value;
    }

    private void AddToPlayedDays(int value = 1)
    {
        _gameData.PlayedDays += value;
    }

    private void AddToOnDayAvailableCassets(int value)
    {
        _gameData.OnDayAvailableCassetts += value;
    }

    private void AddToSpinnedCassets(int value)
    {
        _gameData.SpinnedCassetts += value;
    }
}
