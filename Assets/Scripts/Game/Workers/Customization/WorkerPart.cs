using UnityEngine;

namespace Assets.Scripts.Game.Workers.Customization
{
    public class WorkerPart : MonoBehaviour
    {
        public SpriteRenderer SpriteRender { get; set; }

        private void Awake()
        {
            SpriteRender = GetComponent<SpriteRenderer>();
        }
    }
}
