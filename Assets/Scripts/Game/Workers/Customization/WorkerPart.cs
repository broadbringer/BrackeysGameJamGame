using UnityEngine;

namespace Assets.Scripts.Game.Workers.Customization
{
    public class WorkerPart : MonoBehaviour
    {
        public SpriteRenderer SpriteRender { get; private set; }

        private void Start()
        {
            SpriteRender = GetComponent<SpriteRenderer>();
        }
    }
}
