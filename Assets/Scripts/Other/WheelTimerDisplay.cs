using System;
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
    
}
