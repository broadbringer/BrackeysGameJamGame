using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Workers.Customization
{
  [CreateAssetMenu(fileName = "New Customization", menuName = "Customization Storage", order = 51)]
  public class CustomizationStorage : ScriptableObject
  {
    [SerializeField] private List<Sprite> _hairs;
    [SerializeField] private List<Color> _colors;
  
    public List<Sprite> Hairs => _hairs;
    public List<Color> Colors => _colors;
  }
}
