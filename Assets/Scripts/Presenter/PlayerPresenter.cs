using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPresenter : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] private GameObject _textAddExperience;
    [SerializeField] private Slider _experienceBar;

    [SerializeField] public static PlayerPresenter instance;
    private bool _addedExperience = false;
    private bool _addedCoins = false;
    private bool _reducedCoins = false;
    private bool _multiplierMoney = true;
    private int _futureExperience = 0;
    private int _futureCoins = 0;
    private int _currentExperience = 0;
    int _quantityLoadSecondLevel = 0;

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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _forChit++;
            if (_forChit == 3)
            {
                AddCoin(999);
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
        Debug.Log("После добавки должно быть " + PlayerModel.instance.coins);
        if (!_multiplierMoney) _multiplierMoney = true;
        if (!_addedCoins) StartCoroutine(AddCoins());
    }

    public void AddLevel()
    {
        PlayerModel.instance.level++;
        RatingsPresenter.instance.AddRandomExperienceYoureOpponent();
    }

    public void ReduceCoin(int value)
    {
        GameObject _newText;
        if (PlayerView.instance._coinsTextInWindow != null) _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsTextInWindow.transform);
        else _newText = Instantiate(_textAddExperience.gameObject, PlayerView.instance._coinsText.transform);
        _newText.GetComponent<AnimationTextAdd>().MoveDownAndLoad(-value);
        if (_futureCoins == 0) _futureCoins = PlayerModel.instance.coins;
        PlayerModel.instance.coins -= value;
        Debug.Log("После убавки должно быть " + PlayerModel.instance.coins);
        if (_multiplierMoney) _multiplierMoney = false;
        if (!_reducedCoins) StartCoroutine(ReduceCoins());
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
        if (PlayerModel.instance.experience >= Levels.levels[Levels.CurrentLevel].experience)
        {
            PlayerModel.instance.experience -= Levels.levels[Levels.CurrentLevel].experience;
            instance.AddLevel();
            instance._quantityLoadSecondLevel++;
        }
        if (instance._futureExperience == Levels.levels[Levels.CurrentLevel - instance._quantityLoadSecondLevel].experience)
        {
            instance._quantityLoadSecondLevel--;
            instance._futureExperience = 0;
            if(instance._quantityLoadSecondLevel == 0) instance._currentExperience = PlayerModel.instance.experience;
            PlayerView.instance.RenderLevel(instance._quantityLoadSecondLevel);
        }
    }

    public void AddValueExperienceBar(int value)
    {
        _experienceBar.value = (float) value / Levels.levels[Levels.CurrentLevel - _quantityLoadSecondLevel].experience;
    }

    private IEnumerator AddEXP()
    {
        _addedExperience = true;
        float speed = 1f;
        while (_futureExperience < _currentExperience)
        {
            _futureExperience++;
            CheckLevel();
            AddValueExperienceBar(_futureExperience);
            PlayerView.instance.RenderExperience(_futureExperience);
            speed -= 0.005f;
            yield return new WaitForSeconds(0.08f * speed);
        }
        _addedExperience = false;
    }

    private IEnumerator AddCoins()
    {
        _addedCoins = true;
        float speed = 1f;
        while (_futureCoins < PlayerModel.instance.coins)
        {
            _futureCoins++;
            PlayerView.instance.RenderCoin(_futureCoins);
            speed -= 0.01f;
            yield return new WaitForSeconds(0.03f * speed);
        }
        _addedCoins = false;
    }

    private IEnumerator ReduceCoins()
    {
        _reducedCoins = true;
        float speed = 1f;
        while (_futureCoins > PlayerModel.instance.coins)
        {
            _futureCoins--;
            PlayerView.instance.RenderCoin(_futureCoins);
            speed -= 0.01f;
            yield return new WaitForSeconds(0.03f * speed);
        }

        _reducedCoins = false;
    }
}