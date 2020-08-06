using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Workers;
using TMPro;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;


public enum ItemType
{
    Finger,
    Bycycle,
    Cassett,
    Drill,
    Loom,
    MeatGrinder,
    Mixer,
    Pencil
}

public class Inventory
{
    private int MaxItemsCount = 5;
    public int ItemsCount { get; set; }
    public List<Tool> Items;

    private InventoryView _inventoryView;
    public InventoryChanger Controller;

    public event Action<ItemType, Tool> ItemAdded; 
    
    public Inventory()
    {
        Items = new List<Tool>();
        Controller = new InventoryChanger(this);
    }

    public void Open(IWorker worker)
    {
        if (_inventoryView == null) _inventoryView =  Application.GetInstance().InventoryView;
        _inventoryView.CurrentWorkersInvetory = worker;
        _inventoryView.gameObject.SetActive(true);
    }
    
    public bool IsHaveEmptySlot => ItemsCount < MaxItemsCount;
}

public class InventoryChanger
{
    private Inventory _inventory;
    public event Action<Tool> ItemAdded;
    public InventoryChanger(Inventory inventory)
    {
        _inventory = inventory;
    }
    
    public void AddNewItem(Tool item)
    {
        _inventory.ItemsCount++;
        _inventory.Items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public void DeleteItem(Tool item)
    {
        _inventory.ItemsCount--;
        _inventory.Items.RemoveAt(_inventory.Items.IndexOf(item));
    }
}