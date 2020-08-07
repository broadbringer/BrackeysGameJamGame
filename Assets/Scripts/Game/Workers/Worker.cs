using System.Collections;
using Assets.Scripts.Core;
using Assets.Scripts.Game.Workers.Customization;
using UnityEngine;
using UnityEngine.EventSystems;
using Application = Assets.Scripts.Core.Application;

namespace Assets.Scripts.Game.Workers
{
    public class Worker : MonoBehaviour, IPointerClickHandler, IWorker
    {
        public int Level;
        public float Productivity { get; set; }
        public float CurrentCassetDurabillity { get; set; }
        public Tool WorkItem { get; set; }
        public float ProductivityBonus;
        private Calculator _calculator;
        
        [SerializeField] private WorkerParts _parts;
    
        private Settings _partSettings;
        private EventsManager _eventsManager;

        public float DayIncome;
        private void Start()
        {
            _partSettings = new Settings(_parts.CustomizationVariants);
            var customizer = new WorkerCustomizer(_parts, _partSettings);
            Productivity = 4.5f;
            ProductivityBonus = 10;
            _eventsManager = Application.GetInstance().EventsManager;
            _calculator = new Calculator();
            CurrentCassetDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
        }
        
        public void SetWorkItem(Tool item)
        {
            WorkItem = item;
            Productivity = item.ProductivityBonus * 3;
        }
        
        public void SpinCassette()
        {
            if (Productivity > Application.GetInstance().GameSessionData.CassetDurabillity)
            {
                var cassettSurplus = _calculator.GetScrolledCassetSurplus(Productivity);
                if ((int)cassettSurplus == 0)
                {
                    var scrolledCassettAmount = _calculator.GetScrolledCassetAmount(Productivity);
                    DayIncome += scrolledCassettAmount;
                    _eventsManager.OnCassettSpinnedByClickableWorker(scrolledCassettAmount);
                    RefreshDurabillity();
                }
                else
                {
                    var scrolledCassettAmount = _calculator.GetScrolledCassetAmount(Productivity);
                    DayIncome += scrolledCassettAmount;
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
                    DayIncome += scrolledCassettAmount;
                    _eventsManager.OnCassettSpinnedByClickableWorker(scrolledCassettAmount);
                    RefreshDurabillity();
                }
            }

            if (WorkItem.TryBreak())
            {
                WorkItem = null;
                Debug.Log("Item Broken");
            }
        }

        private void RefreshDurabillity()
        {
            CurrentCassetDurabillity = Application.GetInstance().GameSessionData.CassetDurabillity;
        }
        
        private class Settings
        {
            public Color TShortColor;
            public Color ShortsColor;
            public Color BodyColor;
            public Color HairColor;
            
            public Sprite Hair;

            public Settings(CustomizationStorage storage)
            {
                TShortColor = storage.ClothesColors.PickRandom();
                ShortsColor = storage.ClothesColors.PickRandom();
                BodyColor = storage.BodyColors.PickRandom();
                HairColor = storage.HairColors.PickRandom();
                Hair = storage.Hairs.PickRandom();
            }
        }

        private class WorkerCustomizer
        {
            public WorkerCustomizer(WorkerParts worker, Settings settings)
            {
                SetBodyColor(worker.Face, settings.BodyColor);
                SetTShirtColor(worker.TShirt, settings.TShortColor);
                SetShortsColor(worker.Shorts, settings.ShortsColor);
                SetHair(worker.Hair, settings.Hair);
                SetHairColor(worker.Hair, settings.HairColor);
            }
            
            private void SetHair(WorkerPart part, Sprite hair)
            {
                part.SpriteRender.sprite = hair;
            }

            private void SetBodyColor(WorkerPart part, Color color)
            {
                part.SpriteRender.color = color;
            }

            private void SetTShirtColor(WorkerPart part, Color color)
            {
                part.SpriteRender.color = color;
            }

            private void SetShortsColor(WorkerPart part, Color color)
            {
                part.SpriteRender.color = color;
            }

            private void SetHairColor(WorkerPart part, Color color)
            {
                part.SpriteRender.color = color;
            }
        }

        [System.Serializable]
        private class WorkerParts
        {
            public CustomizationStorage CustomizationVariants;
            public WorkerPart Hair;
            public WorkerPart Face;
            public WorkerPart TShirt;
            public WorkerPart Shorts;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Application.GetInstance().GameSessionData.Equipment.Open(this);
                
            }
        }
    }
}
