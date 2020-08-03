using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Core;
using Application = Assets.Scripts.Core.Application;

namespace Assets.Scripts.Game.Workers
{
    public class ClickableWorker : MonoBehaviour, IPointerClickHandler
    {
        private EventsManager _eventsManager;
        private float CurrentCassetDurabillity;
        private Calculator _calculator;
        
        public float Productivity;
        
        private void Start()
        {
            Productivity = 1;
            CurrentCassetDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
            _calculator = new Calculator();
            _eventsManager = Application.GetInstance().EventsManager;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            SpinCassette();
        }

        private void SpinCassette()
        {
            if (Productivity > CurrentCassetDurabillity)
            {
                var cassettSurplus = _calculator.GetScrolledCassetSurplus(Productivity);
                if (cassettSurplus == 0)
                {
                    var scrolledCassettAmount = _calculator.GetScrolledCassetAmount(Productivity);
                    _eventsManager.OnCassettSpinnedByClickableWorker(scrolledCassettAmount);
                    RefreshDurabillity();
                }
                else
                {
                    var scrolledCassettAmount = _calculator.GetScrolledCassetAmount(Productivity);
                    _eventsManager.OnCassettSpinnedByClickableWorker(scrolledCassettAmount);
                    RefreshDurabillity();
                    CurrentCassetDurabillity -= cassettSurplus;
                }
            }
            else
            {
                CurrentCassetDurabillity -= Productivity;
                if (CurrentCassetDurabillity <= 0)
                {
                    var scrolledCassettAmount = 1;
                    _eventsManager.OnCassettSpinnedByClickableWorker(scrolledCassettAmount);
                    RefreshDurabillity();
                }
            }
        }

        private void RefreshDurabillity()
        {
            CurrentCassetDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
        }
    }

    public class Calculator
    {
        public float GetScrolledCassetSurplus(float productivity)
        {
            var cassettDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
            var value = (int)(productivity % cassettDurabillity);
            return value;
        }

        public int GetScrolledCassetAmount(float productivity)
        {
            var cassettDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
            var value = (int)(productivity / cassettDurabillity);
            return value;
        }
    }
    
}
