using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Application = Assets.Scripts.Core.Application;

/// <summary>
/// View для магазина. Занимается тем, что при нажатии на предмет открывает информацию о нём.
/// </summary>
public class ShopView : MonoBehaviour
{
    public Sprite ItemSprite;
    public GameObject ToolInfoUI;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemProductivity;
    public Button BuyButton;
    
    private EventsManager _eventsManager;

    private Tool _currentTool;
    
    private void Start()
    {
        _eventsManager = Application.GetInstance().EventsManager;
        BuyButton.onClick.AddListener(OnBuy);
    }

    private void OnBuy()
    {
        _eventsManager.OnBuyButtonPressed(_currentTool);
    }
    
    public void OpenInfo(Tool item)
    {
        ToolInfoUI.SetActive(true);
        ItemName.text = item.Name;
        ItemProductivity.text = item.ProductivityBonus.ToString();
        _currentTool = item;
        ItemSprite = item.Sprite;
    }
}
