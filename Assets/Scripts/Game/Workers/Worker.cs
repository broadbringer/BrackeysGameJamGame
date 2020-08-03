using Assets.Scripts.Game.Workers.Customization;
using UnityEngine;

namespace Assets.Scripts.Game.Workers
{
    public class Worker : MonoBehaviour
    {
        public int Level;
        public float Productivity;
        public float ProductivityBonus;
    
        [SerializeField] private WorkerParts _parts;
    
        private Settings _partSettings;
   
        private void Start()
        {
            _partSettings = new Settings(_parts.CustomizationVariants);
            var customizer = new WorkerCustomizer(_parts, _partSettings);
        }
    
        private class Settings
        {
            public Color TShortColor;
            public Color ShortsColor;
            public Color BodyColor;
        
            public Sprite Hair;

            public Settings(CustomizationStorage storage)
            {
                TShortColor = storage.Colors.PickRandom();
                ShortsColor = storage.Colors.PickRandom();
                BodyColor = storage.Colors.PickRandom();
                //Hair = storage.Hairs.PickRandom();
            }
        }

        private class WorkerCustomizer
        {
            public WorkerCustomizer(WorkerParts worker, Settings settings)
            {
                SetBodyColor(worker.Face, settings.BodyColor);
                SetTShirtColor(worker.TShirt, settings.TShortColor);
                SetShortsColor(worker.Shorts, settings.ShortsColor);
                //SetHair(worker.Hair, settings.Hair);
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
    }
}
