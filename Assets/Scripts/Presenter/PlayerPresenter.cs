using System.Collections;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] private GameObject _textAddExperience;

    [SerializeField] public static PlayerPresenter instance;
    private bool AddedExperience = false;
    private bool AddedCoins = false;
    public int FutureExperience = 0;
    public int FutureCoins = 0;

    public void Awake()
    {
        instance = this;
    }

    public void AddCoin(int value)
    {
        GameObject _newText;
        if (PlayerView.instance._coinsTextInWindow != null) _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsTextInWindow.transform);
        else _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(value);
        if (FutureCoins == 0) FutureCoins = PlayerModel.instance.coins;
        PlayerModel.instance.coins += value;
        if (!AddedCoins) StartCoroutine(AddCoins(true));
    }

    public static void AddLevel()
    {
        PlayerModel.instance.level++;
        PlayerView.instance.RenderLevel();
    }

    public void ReduceCoin(int value)
    {
        GameObject _newText;
        if (PlayerView.instance._coinsTextInWindow != null) _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsTextInWindow.transform);
        else _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(value);
        if (FutureCoins == 0) FutureCoins = PlayerModel.instance.coins;
        PlayerModel.instance.coins -= value;
        if (!AddedCoins) StartCoroutine(AddCoins(false));
    }
    public void AddExperience(int value)
    {
        GameObject _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance.experienceText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(value);
        if (FutureExperience == 0) FutureExperience = PlayerModel.instance.experience;
        PlayerModel.instance.experience += value;
        if (!AddedExperience) StartCoroutine(AddEXP());
    }

    public static void CheckLevel()
    {
        if (PlayerModel.instance.experience >= Levels.levels[PlayerModel.instance.level].experience)
        {
            PlayerModel.instance.experience -= Levels.levels[PlayerModel.instance.level].experience;
            instance.FutureExperience = PlayerModel.instance.experience;
            AddLevel();
        }
    }

    private IEnumerator AddEXP()
    {
        AddedExperience = true;
        float speed = 1f;
        while (FutureExperience < PlayerModel.instance.experience)
        {
            FutureExperience++;
            PlayerView.instance.RenderExperience(FutureExperience);
            speed -= 0.005f;
            yield return new WaitForSeconds(0.08f * speed);
        }
        CheckLevel();
        AddedExperience = false;
    }

    private IEnumerator AddCoins(bool multiplier)
    {
        AddedCoins = true;
        float speed = 1f;
        if (multiplier)
        {
            while (FutureCoins < PlayerModel.instance.coins)
            {
                FutureCoins++;
                PlayerView.instance.RenderCoin(FutureCoins);
                speed -= 0.005f;
                yield return new WaitForSeconds(0.03f * speed);
            }
        }
        else
        {
            while (FutureCoins < PlayerModel.instance.coins)
            {
                FutureCoins--;
                PlayerView.instance.RenderCoin(FutureCoins);
                speed -= 0.005f;
                yield return new WaitForSeconds(0.03f * speed);
            }
        }

        AddedCoins = false;
    }
}