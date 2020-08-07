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
    public TextMeshProUGUI ItemPrice;
    public Button BuyButton;
    
    private EventsManager _eventsManager;

    private Tool _currentTool;
    
    private void Start()
    {
        _eventsManager = Application.GetInstance().EventsManager;
        BuyButton.onClick.AddListener(OnBuy);
        ToolInfoUI.SetActive(false);
    }

    private void OnBuy()
    {
        _eventsManager.OnBuyButtonPressed(_currentTool);
        ToolInfoUI.SetActive(false);
    }
    
    public void OpenInfo(Tool item)
    {
        ToolInfoUI.SetActive(true);
        ItemName.text = item.Name;
        ItemPrice.text = item.Price.ToString();
        ItemProductivity.text = item.ProductivityBonus.ToString();
        ItemDescription.text = item.Description;
        _currentTool = item;
        ItemSprite = item.Sprite;
    }
}
