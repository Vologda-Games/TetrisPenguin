using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheelTimerDisplay : MonoBehaviour
{
    TimeSpan timeDiffrence;
    [Header("UI")]

    [SerializeField] private TextMeshProUGUI _textTimeUntilNextSpin;

    private void FixedUpdate() 
    {
        UpdateText();
        CheckNewDay();
    }

    private void UpdateText()
    {
        if (_textTimeUntilNextSpin != null) 
        {
            if (PlayerPrefs.GetInt("WheelSpunToday") == 1) 
            {
                _textTimeUntilNextSpin.text = $"Колесо обновится через {DailyTasksModel.TimeDifference()}";
            }
            else 
            {
                _textTimeUntilNextSpin.text = "Колесо доступно для вращения!";
            }
        }
    }
    private void CheckNewDay() 
    {
        if (TimeSpan.TryParse(DailyTasksModel.TimeDifference(), out timeDiffrence)) 
        {
            if (timeDiffrence == TimeSpan.Zero) 
            {
                PlayerPrefs.SetInt("WheelSpunToday", 0);
            Debug.Log("Новый день, флаг сброшен. Колесо дсотупно для вращения");
            }
        }
    }
}
