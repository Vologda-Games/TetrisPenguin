using System.Collections;
using TMPro;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    [Header("UI")]

    [SerializeField] private TMP_Text _textTimeDifference;
    [SerializeField] public TMP_Text _textCoins;

    private void Start()
    {
        if(_textCoins != null)
        {
            PlayerView.instance._coinsTextInWindow = _textCoins;
            PlayerView.instance.RenderCoin();
        }
        if(_textTimeDifference != null) StartCoroutine(SaveTimeText());
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