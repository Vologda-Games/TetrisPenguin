using System.Collections;
using TMPro;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    [Header("UI")]

    [SerializeField] private TextMeshProUGUI _textTimeDifference;

    private void Start()
    {
        StartCoroutine(SaveTimeText());
    }

    public void ClickButton()
    {
        MusicAndSoundsManager._instance.PlaySoundClickOnButton();
    }

    private IEnumerator SaveTimeText()
    {
        while (true)
        {
            _textTimeDifference.text = $"Обновится через {DailyTasksModel.TimeDifference()}";
            yield return new WaitForSeconds(1);
        }
    }
}