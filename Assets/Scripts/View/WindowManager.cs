using TMPro;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    [Header("UI")]

    [SerializeField] private TextMeshProUGUI _textTimeDifference;
    
    public void ClickButton()
    {
        MusicAndSoundsManager._instance.PlaySoundClickOnButton();
    }

    private void FixedUpdate()
    {
        if(_textTimeDifference != null && PlayerPrefs.GetInt("StartedDailyTasks") == 1) _textTimeDifference.text = $"Обновится через {DailyTasksModel.TimeDifference()}";
    }
}