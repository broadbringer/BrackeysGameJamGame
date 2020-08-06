using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public bool IsEmpty;
    public Tool ItemTool;
    public Image ItemImage;
    public InventoryView View;
    
    
    /// <summary>
    /// Разобраться с этим методом полностью, нужно повыносить логику по отдельным классам, а то ты тут пиздец натворил такой, что на голову не натянешь.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemTool != null)
        {
            IsEmpty = true;
            ItemImage.sprite = null;
            View.Inventory.Controller.DeleteItem(ItemTool);
            if (View.CurrentWorkerTool != null)
            {
                var tempItem = ItemTool;
                ItemTool = View.CurrentWorkerTool;
                View.Inventory.Controller.AddNewItem(ItemTool);
                View.CurrentWorkersInvetory.SetWorkItem(tempItem);
                View.DrawWorkerItem();
            }
            else
            {
                View.CurrentWorkersInvetory.SetWorkItem(ItemTool);
                View.DrawWorkerItem();
                ItemTool = null;
            }
        }
    }
}
