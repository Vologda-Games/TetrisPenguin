using System.Collections;
using TMPro;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager instance;
    [Header("UI")]
    [SerializeField] private TMP_Text _textTimeDifference;
    [SerializeField] public TMP_Text _textCoins;
    [SerializeField] private TMP_Text _textRatings;
    [SerializeField] private TMP_Text _textShop;
    [SerializeField] private TMP_Text _textDailyTasks;
    [SerializeField] private TMP_Text _textDailyRewards;
    [SerializeField] private TMP_Text _textWheelOfLuck;
    [SerializeField] private TMP_Text _textSpin;
    [SerializeField] private TMP_Text _textAttempt;
    [SerializeField] private TMP_Text _textGet;
    [SerializeField] private TMP_Text _textLoginToGame;
    [SerializeField] private TMP_Text _priceAttemptText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RenderTextWindow();
    }

    public void ClickButton()
    {
        MusicAndSoundsManager._instance.PlaySoundClickOnButton();
    }

    public void EventCloseWindow()
    {
        GameInterface.instance.CloseFirstLayout();
    }

    public void RenderTextWindow()
    {
        if (_textRatings != null) _textRatings.text = LibraryWords.reatings.GetText();
        if (_textShop != null) _textShop.text = LibraryWords.shop.GetText();
        if (_textDailyTasks != null) _textDailyTasks.text = LibraryWords.dailyTasks.GetText();
        if (_textDailyRewards != null) _textDailyRewards.text = LibraryWords.dailyRewards.GetText();
        if (_textWheelOfLuck != null) _textWheelOfLuck.text = LibraryWords.wheelOfLuck.GetText();
        if (_textAttempt != null) _textAttempt.text = LibraryWords.buyAttempt.GetText();
        if (_textSpin != null) _textSpin.text = LibraryWords.spin.GetText();
        if (_textGet != null) _textGet.text = LibraryWords.get.GetText();
        if (_textLoginToGame != null) _textLoginToGame.text = LibraryWords.loginToGame.GetText();
        if (_priceAttemptText != null) _priceAttemptText.text = $"{LuckWheelView.instance._priceAttempt}";

        if (_textCoins != null)
        {
            PlayerView.instance._coinsTextInWindow = _textCoins;
            PlayerView.instance.RenderCoin();
        }
        if (_textTimeDifference != null) StartCoroutine(SaveTimeText());
    }

    private IEnumerator SaveTimeText()
    {
        while (true)
        {
            _textTimeDifference.text = $"{LibraryWords.updatingVia.GetText()} {DailyTasksModel.TimeDifference()}";
            yield return new WaitForSeconds(1);
        }
    }
}