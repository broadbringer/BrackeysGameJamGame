using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core;
using Assets.Scripts.Game.Workers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Application = Assets.Scripts.Core.Application;

//Этот класс находится на каждом персонаже
public class InventoryView : MonoBehaviour
{
      public IWorker CurrentWorkersInvetory; 
      public Tool CurrentWorkerTool;
      public Image CurrentWorkerToolImage;
      public Inventory Inventory;
      public InventoryItem[] InventorySlots;

      private bool IsFirstPlay = true;

      private EventsManager _eventsManager;

    [SerializeField] private TextMeshProUGUI _toolName;
    [SerializeField] private TextMeshProUGUI _toolProductivity;
    [SerializeField] private TextMeshProUGUI _toolExpences;


    private void Start()
      {
       InventorySlots = GetComponentsInChildren<InventoryItem>();
       foreach (var slot in InventorySlots)
       {
           slot.IsEmpty = true;
       }
       Inventory = Application.GetInstance().GameSessionData.Equipment;
       gameObject.SetActive(false);
       IsFirstPlay = false;
       Inventory.Controller.ItemAdded += DrawNewItemInInventrory;
       isFirstPlay = false;
      }

      private bool isFirstPlay = true;
      private void OnEnable()
      {
          if (isFirstPlay) return;
          DrawWorkerItem();
      }
      private void OnDisable()
      {
          CurrentWorkersInvetory = null;
      }
     
     public void DrawNewItemInInventrory(Tool item)
     {
         var emptySlot = InventorySlots.First(x => x.IsEmpty);
         emptySlot.ItemImage.sprite = item.Sprite;
         emptySlot.IsEmpty = false;
         emptySlot.ItemTool = item;
     }
     
     public void DrawWorkerItem()
     {
         CurrentWorkerTool = CurrentWorkersInvetory.WorkItem;
         if (CurrentWorkerTool != null)
         {
             CurrentWorkerToolImage.sprite = CurrentWorkerTool.Sprite;
            _toolName.text = CurrentWorkerTool.Name;
            _toolProductivity.text = CurrentWorkerTool.ProductivityBonus.ToString();
            _toolExpences.text = (CurrentWorkerTool.ProductivityBonus * 3 * 0.1f).ToString();
         }
         else
         {
             CurrentWorkerToolImage.sprite = null;
         }
     }
     
    
    
}
