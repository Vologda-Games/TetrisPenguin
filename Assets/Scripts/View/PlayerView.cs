using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public static PlayerView instance;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] public TMP_Text _experienceTextInWindow;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RenderCoin();
        RenderLevel();
    }

    public void RenderLevel()
    {
        _levelText.text = PlayerModel.instance.level.ToString();
    }

    public void RenderCoin()
    {
        _experienceText.text = RenderingCoinText();
        if(_experienceTextInWindow != null) _experienceTextInWindow.text = RenderingCoinText();
    }

    public static string RenderingCoinText()
    {
        string formattedNumber = PlayerModel.instance.coins.ToString();

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