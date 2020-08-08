using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Core;
using Application = Assets.Scripts.Core.Application;

namespace Assets.Scripts.Game.Workers
{
    public class ClickableWorker : MonoBehaviour, IPointerClickHandler, IWorker
    {
        private EventsManager _eventsManager;
        private Calculator _calculator;

        public Tool WorkItem { get; set; } = null;
        public float Productivity { get; set; }
        public float CurrentCassetDurabillity { get; set; }

        public AudioSource audioSource;

        private void Start()
        {
            Productivity = 1.5f;
            CurrentCassetDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
            _calculator = new Calculator();
            _eventsManager = Application.GetInstance().EventsManager;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Application.GetInstance().GameSessionData.Equipment.Open(this);
                return;
            }
            SpinCassette();
            
        }

        public void SetWorkItem(Tool item)
        {
            WorkItem = item;
            Productivity = item.ProductivityBonus;
        }
        
        public void SpinCassette()
        {
            if (Productivity > Application.GetInstance().GameSessionData.CassetDurabillity)
            {
                var cassettSurplus = _calculator.GetScrolledCassetSurplus(Productivity);
                if ((int)cassettSurplus == 0)
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
            audioSource.Play();
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
