using System.Collections.Generic;
using Assets.Scripts.Game.Workers;

namespace Assets.Scripts.Game.GameSession
{
    [System.Serializable]
    public class GameSessionData
    {
        public float Money { get; set; }
        public float DayTime { get; set; }
        public int PlayedDays { get; set; }
        public int OnDayAvailableCassetts { get; set; }
        public int SpinnedCassetts { get; set; }
        public int WorkingPlacesAmount { get; set; }
        public int AvailableWorkingPlaces { get; set; }
        public float CassetDurabillity { get; private set; }

        public readonly float OneHourInSeconds = 10f;
        public readonly float OnDayInSecond = 240f;

        public List<Worker> AIWorkers; 
        
        public GameSessionData()
        {
            Money = 0;
            DayTime = 0;
            PlayedDays = 0;
            OnDayAvailableCassetts = 0;
            WorkingPlacesAmount = 5;
            AvailableWorkingPlaces = 0;
            CassetDurabillity = 30;
            SpinnedCassetts = 0;
            AIWorkers = new List<Worker>();
        }
    }
}
