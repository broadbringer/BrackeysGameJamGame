using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Shop Item", order = 54)]
public class Tool : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public float ProductivityBonus;
    public float Durability;
    public ItemType Type;
    public float Price;
     
    //от 1 до 100
    public float ChanceToBreak { get; set; }
    
    public bool TryBreak()
    {
        var random = Random.Range(0, 101);
        return random > ChanceToBreak;
    }
}
