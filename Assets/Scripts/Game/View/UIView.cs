using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class UIView : MonoBehaviour
{
    public TextMeshProUGUI Money;
    public TextMeshProUGUI DayTime;
    public TextMeshProUGUI CurrentDay;
    public TextMeshProUGUI SpinnedCassetsGoal;
    public TextMeshProUGUI SpinnedCassets;

    private void Update()
    {
        Money.text = Application.GetInstance().GameSessionData.Money.ToString();
        CurrentDay.text = Application.GetInstance().GameSessionData.CurrentDay.ToString();
        SpinnedCassetsGoal.text = Application.GetInstance().GameSessionData.SpinnedCassettsGoal.ToString();
        SpinnedCassets.text = Application.GetInstance().GameSessionData.SpinnedCassetts.ToString();
        TimerView();
    }

    private void TimerView()
    {
        TimeSpan time = TimeSpan.FromSeconds(Application.GetInstance().GameSessionData.TimeLeft);
        string str = time.ToString(@"mm\:ss");
        DayTime.text = str;
    }
}
