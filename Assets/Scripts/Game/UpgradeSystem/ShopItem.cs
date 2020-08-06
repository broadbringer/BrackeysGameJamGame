using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem: MonoBehaviour, IPointerClickHandler
{
    public Tool Info;
    public ShopView ShopView;
    public Image Sprite;
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ShopView.OpenInfo(Info);
    }
}
