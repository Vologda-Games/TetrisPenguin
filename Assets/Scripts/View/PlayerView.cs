using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [Header("Scripts")]
    public static PlayerView instance;

    [Header("UI")]
    [SerializeField] private Image _buttonLanguage;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] public TMP_Text experienceText;
    [SerializeField] public TMP_Text _coinsText;
    [HideInInspector] public TMP_Text _coinsTextInWindow;
    [SerializeField] private TMP_Text _textRatings;
    [SerializeField] private TMP_Text _textShop;
    [SerializeField] private TMP_Text _textDailyTasks;
    [SerializeField] private TMP_Text _textDailyRewards;
    [SerializeField] private TMP_Text _textWheelOfLuck;
    [SerializeField] private TMP_Text _textTablePenguin;
    [SerializeField] private TMP_Text _textMusic;
    [SerializeField] private TMP_Text _textSounds;
    [SerializeField] private TMP_Text _textControl;
    [SerializeField] private TMP_Text _textReplay;
    [SerializeField] private TMP_Text _textLanguage;
    private bool scaleBool;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LanguagePresenter.changeLanguageEvent += RenderTypeControl;
        LanguagePresenter.changeLanguageEvent += RenderTextMenu;
        LanguagePresenter.changeLanguageEvent += RenderIconLanguage;
        RenderCoin();
        RenderLevel();
        RenderExperience();
        RenderTypeControl();
        RenderTextMenu();
        RenderIconLanguage();
        PlayerPresenter.instance.AddValueExperienceBar(PlayerModel.instance.experience);
    }

    public void RenderLevel()
    {
        _levelText.text = PlayerModel.instance.level.ToString();
    }

    public void RenderLevel(int reduceLevel)
    {
        _levelText.text = (PlayerModel.instance.level - reduceLevel).ToString();
    }

    public void RenderExperience(int experience)
    {
        experienceText.text = RenderingCurrencyText(experience);
    }

    public void RenderExperience()
    {
        experienceText.text = RenderingCurrencyText(PlayerModel.instance.experience);
        if (!scaleBool) StartCoroutine(UpScaleTextEXP(experienceText.gameObject, new Vector2(1.2f, 1.2f), experienceText.transform.localScale));
    }

    public void RenderCoin(int coins)
    {
        _coinsText.text = RenderingCurrencyText(coins);
        if (_coinsTextInWindow != null) _coinsTextInWindow.text = RenderingCurrencyText(coins);
    }

    public void RenderCoin()
    {
        _coinsText.text = RenderingCurrencyText(PlayerModel.instance.coins);
        if (_coinsTextInWindow != null) _coinsTextInWindow.text = RenderingCurrencyText(PlayerModel.instance.coins);
    }

    public void RenderTypeControl()
    {
        _textControl.text = ScreenModel.GetNameTypeControl();
    }

    public void RenderTextMenu()
    {
        if (_textRatings != null) _textRatings.text = LibraryWords.reatings.GetText();
        if (_textShop != null) _textShop.text = LibraryWords.shop.GetText();
        if (_textDailyTasks != null) _textDailyTasks.text = LibraryWords.dailyTasks.GetText();
        if (_textDailyRewards != null) _textDailyRewards.text = LibraryWords.dailyRewards.GetText();
        if (_textWheelOfLuck != null) _textWheelOfLuck.text = LibraryWords.wheelOfLuck.GetText();
        if (_textTablePenguin != null) _textTablePenguin.text = LibraryWords.penguinTable.GetText();
        if (_textMusic != null) _textMusic.text = LibraryWords.music.GetText();
        if (_textSounds != null) _textSounds.text = LibraryWords.sounds.GetText();
        if (_textReplay != null) _textReplay.text = LibraryWords.startOver.GetText();
        if (_textLanguage != null) _textLanguage.text = LibraryWords.language.GetText();
    }

    public void RenderIconLanguage()
    {
        for (int j = 0; j < LanguageModel._langegesSprites.Length; j++)
        {
            if (LanguageModel._langegesSprites[j].name.Contains(LanguageModel.currentLanguage))
            {
                if (_buttonLanguage != null) _buttonLanguage.sprite = LanguageModel._langegesSprites[j];
                break;
            }
        }
    }

    public static string RenderingCurrencyText(int _currency)
    {
        string formattedNumber = _currency.ToString();

        if (formattedNumber.Length > 0)
        {
            if (formattedNumber.Length == 4)
            {
                formattedNumber = formattedNumber.Insert(1, " ");
            }
            else if (formattedNumber.Length == 5)
            {
                formattedNumber = formattedNumber.Insert(2, " ");
            }
            else if (formattedNumber.Length == 6)
            {
                formattedNumber = formattedNumber.Insert(3, " ");
            }
        }

        return formattedNumber;
    }

    private IEnumerator UpScaleTextEXP(GameObject go, Vector2 maxScale, Vector2 normalScale)
    {
        scaleBool = true;
        while (go.transform.localScale.x < maxScale.x && go.transform.localScale.y < maxScale.y)
        {
            go.transform.localScale = new Vector2(go.transform.localScale.x + 0.05f, go.transform.localScale.y + 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        while (go.transform.localScale.x > normalScale.x && go.transform.localScale.y > normalScale.y)
        {
            go.transform.localScale = new Vector2(go.transform.localScale.x - 0.05f, go.transform.localScale.y - 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        go.transform.localScale = normalScale;
        scaleBool = false;
    }
}