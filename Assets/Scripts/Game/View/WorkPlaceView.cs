using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.GameSession;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Application = Assets.Scripts.Core.Application;

public class WorkPlaceView : MonoBehaviour
{
    public WorkPlace _workPlace;
    public TextMeshProUGUI PriceText;
    public Button _Button;
    public TextMeshProUGUI _needableDay;
    private GameSessionData _gameData;
    private void Start()
    {
        _workPlace = GetComponentInParent<WorkPlace>();
        PriceText.text = _workPlace.Price.ToString();
        _needableDay.text = _workPlace.DayToOpen.ToString();
        _gameData = Application.GetInstance().GameSessionData;
        _Button.onClick.AddListener(_workPlace.ChangeState);
        gameObject.SetActive(false);
        _isFirstPlay = false;
    }

    private bool _isFirstPlay = true;
    private void OnEnable()
    {
        if (_isFirstPlay) return;
        //CheckPossibleToBuy();
    }

    private void CheckPossibleToBuy()
    {
        if (_gameData.CurrentDay == _workPlace.DayToOpen)
        {
            //В идеале просто будем менять цвет.
            _Button.gameObject.SetActive(true);
        }
    }
}
