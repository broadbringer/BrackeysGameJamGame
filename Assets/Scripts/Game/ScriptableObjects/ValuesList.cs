using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New ValuesList", menuName = "Values", order = 52)]
    public class ValuesList : ScriptableObject
    {
        [SerializeField] private List<float> _values;

        public List<float> Values => _values;
    }
}
