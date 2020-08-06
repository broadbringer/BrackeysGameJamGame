using System.Collections.Generic;
using Assets.Scripts.Game.Workers;
using UnityEngine;

namespace Assets.Scripts.Game.GameSession
{
    
    public enum DayState
    {
        DayContinue,
        DayOver
    }
    
    [System.Serializable]
    
    public class GameSessionData
    {
        public float Money {get;set;}
        public float TimeLeft{ get; set; }
        public int CurrentDay{ get; set; }
        public int SpinnedCassettsGoal{ get; set; }
        public int SpinnedCassetts{ get; set; }
        public int WorkingPlacesAmount { get; set; }
        public int AvailableWorkingPlaces{ get; set; }
        public float CassetDurabillity{ get; private set; }

        public readonly float OneHourInSeconds = 15f;
        public readonly float OneDayInSecond = 120f;
        public readonly float OneCassettPrice = 0.01f;
        
        public List<Worker> AIWorkers;
        
        public DayState DayState;

        public Inventory Equipment;
        public GameSessionData()
        {
            Money = 1000;
            TimeLeft = OneDayInSecond;
            CurrentDay = 1;
            SpinnedCassettsGoal = 2;
            WorkingPlacesAmount = 0;
            AvailableWorkingPlaces = 0;
            CassetDurabillity = 30;
            SpinnedCassetts = 0;
            AIWorkers = new List<Worker>();
            DayState = DayState.DayContinue;
            Equipment = new Inventory();
        }
    }
}
