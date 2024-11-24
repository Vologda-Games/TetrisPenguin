using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public static PlayerView instance;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] public TMP_Text experienceText;
    [SerializeField] public TMP_Text _coinsText;
    [HideInInspector] public TMP_Text _coinsTextInWindow;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RenderCoin();
        RenderLevel();
        RenderExperience();
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
}