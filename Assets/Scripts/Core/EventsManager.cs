using System;

namespace Assets.Scripts.Core
{
    public class EventsManager
    {
        public event Action<int> CassettSpinnedByClickableWorker;

        public void OnCassettSpinnedByClickableWorker(int value)
        {
            CassettSpinnedByClickableWorker?.Invoke(value);
        }

        public event Action DayIsOver;

        public void OnDayIsOver()
        {
            DayIsOver?.Invoke();
        }

    }
}
