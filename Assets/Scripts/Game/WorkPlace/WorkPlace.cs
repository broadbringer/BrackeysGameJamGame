using Assets.Scripts.Core;
using Assets.Scripts.Game.GameSession;
using UnityEngine;
using UnityEngine.EventSystems;
using Application = Assets.Scripts.Core.Application;

public class WorkPlace : MonoBehaviour,IPointerClickHandler
{
    private GameSessionData _gameData;
    private EventsManager _eventsManager;
        
    public float Price;
    public bool IsCanBuy = false;
    public float AvailableDayToBuy;
    
    
    private void Start()
    {
        _gameData = Application.GetInstance().GameSessionData;
        _eventsManager = Application.GetInstance().EventsManager;
        _eventsManager.DayIsOver += OnNewDayStarted;
    }

    private void OnNewDayStarted()
    {
        //сделать проверку на то, что бы сделать этот стол активным
        if (AvailableDayToBuy >= _gameData.CurrentDay)
        {
            //делаем активным данный стол, наверное будем слои менять и цвет
            _eventsManager.DayIsOver -= OnNewDayStarted;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}

