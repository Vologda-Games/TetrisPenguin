using System.Collections;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] private GameObject _textAddExperience;

    [SerializeField] public static PlayerPresenter instance;
    private bool _addedExperience = false;
    private bool _addedCoins = false;
    private int _futureExperience = 0;
    private int _futureCoins = 0;
    private int _currentExperience = 0;
    private bool _loadSecondLevel = false;

    private int _forChit = 0;

    public void Awake()
    {
        instance = this;
    }

    // Читы
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            _forChit++;
            if(_forChit == 3)
            {
                AddExperience(999);
                _forChit = 0;
            }
        };
    }
    
    public void AddCoin(int value)
    {
        GameObject _newText;
        if (PlayerView.instance._coinsTextInWindow != null) _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsTextInWindow.transform);
        else _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(value);
        if (_futureCoins == 0) _futureCoins = PlayerModel.instance.coins;
        PlayerModel.instance.coins += value;
        if (!_addedCoins) StartCoroutine(AddCoins(true));
    }

    public void AddLevel()
    {
        PlayerModel.instance.level++;
    }

    public void ReduceCoin(int value)
    {
        GameObject _newText;
        if (PlayerView.instance._coinsTextInWindow != null) _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsTextInWindow.transform);
        else _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(value);
        if (_futureCoins == 0) _futureCoins = PlayerModel.instance.coins;
        PlayerModel.instance.coins -= value;
        if (!_addedCoins) StartCoroutine(AddCoins(false));
    }
    public void AddExperience(int value)
    {
        GameObject _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance.experienceText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(value);
        if (_futureExperience == 0) _futureExperience = PlayerModel.instance.experience;
        PlayerModel.instance.experience += value;
        if(_currentExperience < PlayerModel.instance.experience) _currentExperience = PlayerModel.instance.experience;
        CheckLevel();
        if (!_addedExperience) StartCoroutine(AddEXP());
    }

    public static void CheckLevel()
    {
        if (PlayerModel.instance.experience >= Levels.levels[PlayerModel.instance.level].experience)
        {
            PlayerModel.instance.experience -= Levels.levels[PlayerModel.instance.level].experience;
            instance.AddLevel();
            instance._loadSecondLevel = true;
        }
        if (instance._futureExperience == Levels.levels[PlayerModel.instance.level - 1].experience && instance._loadSecondLevel)
        {
            instance._futureExperience = 0;
            instance._currentExperience = PlayerModel.instance.experience;
            PlayerView.instance.RenderLevel();
            instance._loadSecondLevel = false;
        }
    }

    private IEnumerator AddEXP()
    {
        _addedExperience = true;
        float speed = 1f;
        while (_futureExperience < _currentExperience)
        {
            _futureExperience++;
            CheckLevel();
            PlayerView.instance.RenderExperience(_futureExperience);
            speed -= 0.005f;
            yield return new WaitForSeconds(0.08f * speed);
        }
        _addedExperience = false;
    }

    private IEnumerator AddCoins(bool multiplier)
    {
        _addedCoins = true;
        float speed = 1f;
        if (multiplier)
        {
            while (_futureCoins < PlayerModel.instance.coins)
            {
                _futureCoins++;
                PlayerView.instance.RenderCoin(_futureCoins);
                speed -= 0.005f;
                yield return new WaitForSeconds(0.03f * speed);
            }
        }
        else
        {
            while (_futureCoins < PlayerModel.instance.coins)
            {
                _futureCoins--;
                PlayerView.instance.RenderCoin(_futureCoins);
                speed -= 0.005f;
                yield return new WaitForSeconds(0.03f * speed);
            }
        }

        _addedCoins = false;
    }
}