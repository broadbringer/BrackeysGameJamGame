using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Workers.Customization
{
  [CreateAssetMenu(fileName = "New Customization", menuName = "Customization Storage", order = 51)]
  public class CustomizationStorage : ScriptableObject
  {
    [SerializeField] private List<Sprite> _hairs;
    [SerializeField] private List<Color> _bodyColors;
    [SerializeField] private List<Color> _hairColors;
    [SerializeField] private List<Color> _clothesColors;
    
    public List<Sprite> Hairs => _hairs;
    public List<Color> BodyColors => _bodyColors;
    public List<Color> HairColors => _hairColors;
    public List<Color> ClothesColors => _clothesColors;
  }
}
