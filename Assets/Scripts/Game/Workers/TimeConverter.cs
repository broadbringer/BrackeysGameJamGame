using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Application = Assets.Scripts.Core.Application;

public class TimeConverter : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private float dayTime;

    private void Start()
    {
        dayTime = Application.GetInstance().GameSessionData.OnDayInSecond;
    }
    public void Update()
    {
        if (dayTime > 0)
        {
            TimeSpan time = TimeSpan.FromSeconds(dayTime);
            string str = time.ToString(@"mm\:ss");
            _text.text = str;
            dayTime -= Time.deltaTime;
        }
    }
}
