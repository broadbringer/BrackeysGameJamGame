﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Shop Item", order = 54)]
public class Tool : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public float ProductivityBonus;
    public float Price;
    public string Description;
    
    //от 1 до 100
    [Range(0,100)]
    public float ChanceToBreak;
    
    public bool TryBreak()
    {
        var random = Random.Range(0, 101);
        return random > ChanceToBreak;
    }
}
