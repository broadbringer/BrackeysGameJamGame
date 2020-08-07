using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Application = Assets.Scripts.Core.Application;

//Представляет собой хранилище магазина и имеет метод который покупает предмет.
public class Shop : MonoBehaviour
{
    
    private ShopItem[] Items;
    public List<Tool> Tools;

    private GameSessionData _gameData;
    private EventsManager _eventsManager;
    
    private void Start()
    {
        _gameData = Application.GetInstance().GameSessionData;
        _eventsManager = Application.GetInstance().EventsManager;
        _eventsManager.BuyButtonPressed += BuyItem;
        Items = GetComponentsInChildren<ShopItem>();
        var index = 0;
        
        foreach (var tool in Tools)
        {
            Debug.Log("Current tool is " + tool);
            Debug.Log(Items[index]);
            Items[index].Info = tool;
            Items[index].Sprite.sprite = tool.Sprite;
            index++;
        }
    }

    private void BuyItem(Tool item)
    {
        if (IsHaveMoney(item))
        {
            if (_gameData.Equipment.IsHaveEmptySlot)
            {
                //Вынести в отдельные классы обязательно.
                //Для спешки сделаем пока так
                _gameData.Money -= item.Price;
                _gameData.Equipment.Controller.AddNewItem(item);
                
            }
            else
            {
                Debug.Log("No empty slots");
            }
        }
        else
        {
            Debug.Log("No Money");
        }
    }

    private bool IsHaveMoney(Tool item) => _gameData.Money >= item.Price;
}

