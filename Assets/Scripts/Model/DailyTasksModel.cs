using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyTasksModel : MonoBehaviour
{
    [Header("Structure")]
    [SerializeField] public List<DailyTasksInfoValue> _allTasks = new List<DailyTasksInfoValue>();
    public static DailyTasksModel _instance;
    public List<int> _allReadyNumbersTasks;
    [SerializeField] public int _maxQuantityTaskOfDay;
    
    public static Sprite[] _spritesForRewardBaff;
    public static Sprite _spriteForRewardSoftCurrency;
    private void Awake()
    {
        _instance = this;
        _spritesForRewardBaff = Resources.LoadAll<Sprite>("Sprites/Reward/Bafs");
        _spriteForRewardSoftCurrency = Resources.Load<Sprite>("Sprites/Reward/Currency/SoftCurrency");
        for(int i = 0; i < _allTasks.Count; i++)
        {
            if(!_allReadyNumbersTasks.Contains(i)) _allReadyNumbersTasks.Add(i);
        }
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("StartedDailyTasks")) PlayerPrefs.SetInt("StartedDailyTasks", 1);
    }

    public static string TimeDifference()
    {
        TimeSpan _difference = DateTime.MaxValue - GamePush.GP_Server.Time();
        string _differenceTimeString = $"{_difference.Hours}:{_difference.Minutes}:{_difference.Seconds}";
        return _differenceTimeString;
    }

    public int RandomNumberTask()
    {
        int _randomNumber;
        int _rand = UnityEngine.Random.Range(0, _allReadyNumbersTasks.Count);
        _randomNumber = _allReadyNumbersTasks[_rand];
        if(_allReadyNumbersTasks.Contains(_allReadyNumbersTasks[_rand])) _allReadyNumbersTasks.Remove(_allReadyNumbersTasks[_rand]);
        return _randomNumber;
    }
}

[Serializable]
public class DailyTasksInfoValue
{
    [Header("Type")]
    [SerializeField] private TypeTask _typeTaskEnum;

    [Header("For Create")]
    [SerializeField] private PenguinView _object;

    [Header("Number Baff For Use Baff, MAX - 5")]
    [SerializeField] private int _numberUseBaff = 1;

    [Header("Intagers Or Floats")]
    [SerializeField] public int _maximumQuantity = 1;
    [SerializeField] public int _currentQuantity;

    [Header("Type Reward")]
    [SerializeField] private TypeReward _typeRewardEnum;

    [Header("Number Baff For Add Baff , MAX - 5")]
    [SerializeField] private int _numberAddBaff = 1;
    [SerializeField] private int _quantityAddBaff = 1;

    [Header("Quantity Currency For Add Currency")]
    [SerializeField] private int _quantityAddCurrency = 1;

    public string TaskInformation()
    {
        string _typeAction;
        string _nameObject = "Это задание к сожалению скрыто:(";
        string _nameBaff = "Это задание к сожалению скрыто:(";

        if(_typeTaskEnum == TypeTask.Create)
        {
            _typeAction = "Создать";
            if(_object != null)
            {
                _nameObject = $"пингвина {_object.level + 1}-го уровня";
            }
            return $"{_typeAction} {_nameObject}";
        }else if(_typeTaskEnum == TypeTask.UseBaff)
        {
            _typeAction = "Использовать";
            if(_numberUseBaff > 0)
            {
                switch(_numberUseBaff)
                {
                    case 1: _nameBaff = $"усилитель \"мульти пингвин\""; break;
                    case 2: _nameBaff = $"усилитель \"супер удар\""; break;
                    case 3: _nameBaff = $"усилитель \"бомба\""; break;
                    case 4: _nameBaff = $"усилитель \"ураган\""; break;
                    case 5: _nameBaff = $"усилитель \"магнит\""; break;
                }
            }
            return $"{_typeAction} {_nameBaff}";
        }else if(_typeTaskEnum == TypeTask.Click)
        {
            _typeAction = "Кликнуть на экран, при создании пингвинов";
            return $"{_typeAction}";
        }else  return $"Это задание к сожалению скрыто:(((";
    }

    public Sprite SpriteReward()
    {
        Sprite _spriteReward = null;
        if(_typeRewardEnum == TypeReward.Baff)
        {
            for(int i = 0; i < DailyTasksModel._spritesForRewardBaff.Length; i++)
            {
                if(DailyTasksModel._spritesForRewardBaff[i].name.Contains($"{_numberAddBaff}"))
                {
                    _spriteReward = DailyTasksModel._spritesForRewardBaff[i];
                    break;
                }
            }
        }
        else if(_typeRewardEnum == TypeReward.SoftCurrency)
        {
            _spriteReward = DailyTasksModel._spriteForRewardSoftCurrency;
        }
        return _spriteReward;
    }

    public int QuantittyBonus()
    {
        if(_typeRewardEnum == TypeReward.Baff)
        {
            return _quantityAddBaff;
        }
        else if(_typeRewardEnum == TypeReward.SoftCurrency)
        {
            return _quantityAddCurrency;
        }else return 0;
    }
}

public enum TypeTask
{
    Create,
    UseBaff,
    Click
}

public enum TypeReward
{
    Baff,
    SoftCurrency
}