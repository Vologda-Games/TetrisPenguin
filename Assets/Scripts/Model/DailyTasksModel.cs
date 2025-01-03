using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyTasksModel : MonoBehaviour
{
    [Header("Structure")]
    public static List<DailyTasksInfoValue> allTasks = new List<DailyTasksInfoValue>()
    {
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 5,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 200,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 7,
            _numberUseBaff = 0,
            _maximumQuantity = 2,
            _typeRewardEnum = TypeReward.Baff,
            _numberAddBaff = 2,
            _quantityAddBaff = 5,
            _quantityAddCurrency = 0,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 8,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 300,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 4,
            _numberUseBaff = 0,
            _maximumQuantity = 4,
            _typeRewardEnum = TypeReward.Baff,
            _numberAddBaff = 1,
            _quantityAddBaff = 4,
            _quantityAddCurrency = 0,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 9,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 500,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 8,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.Baff,
            _numberAddBaff = 2,
            _quantityAddBaff = 3,
            _quantityAddCurrency = 0,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 11,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 1000,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 12,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 1100,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Create,
            _objectLevel = 14,
            _numberUseBaff = 0,
            _maximumQuantity = 1,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 1500,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.UseBaff,
            _objectLevel = 0,
            _numberUseBaff = 1,
            _maximumQuantity = 8,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 550,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.UseBaff,
            _objectLevel = 0,
            _numberUseBaff = 2,
            _maximumQuantity = 6,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 300,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.UseBaff,
            _objectLevel = 0,
            _numberUseBaff = 3,
            _maximumQuantity = 8,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 600,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.UseBaff,
            _objectLevel = 0,
            _numberUseBaff = 4,
            _maximumQuantity = 10,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 500,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.UseBaff,
            _objectLevel = 0,
            _numberUseBaff = 5,
            _maximumQuantity = 8,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 800,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Click,
            _objectLevel = 0,
            _numberUseBaff = 0,
            _maximumQuantity = 150,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 300,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Click,
            _objectLevel = 0,
            _numberUseBaff = 0,
            _maximumQuantity = 350,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 750,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Click,
            _objectLevel = 0,
            _numberUseBaff = 0,
            _maximumQuantity = 450,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 850,
            ConditionTask = ""
        },
        new DailyTasksInfoValue()
        {
            _typeTaskEnum = TypeTask.Click,
            _objectLevel = 0,
            _numberUseBaff = 0,
            _maximumQuantity = 550,
            _typeRewardEnum = TypeReward.SoftCurrency,
            _numberAddBaff = 0,
            _quantityAddBaff = 0,
            _quantityAddCurrency = 1000,
            ConditionTask = ""
        }
    };
    public static DailyTasksModel instance;
    public List<int> _allReadyNumbersTasks;
    [SerializeField] public int _maxQuantityTaskOfDay;

    [Header("Sprites")]
    public static Sprite[] spritesForRewardBaff;
    public static Sprite spriteForRewardSoftCurrency;

    [Header("String")]
    [HideInInspector] public DateTime LastEnterToGame;

    private void Awake()
    {
        instance = this;
    }

    public static string TimeDifference()
    {
        TimeSpan _difference = DateTime.MaxValue - GamePush.GP_Server.Time();
        DateTime _result = new DateTime();
        string _differenceTimeString = $"{(_result + _difference).ToString("HH")}:{(_result + _difference).ToString("mm")}:{(_result + _difference).ToString("ss")}";
        return _differenceTimeString;
    }

    public int RandomNumberTask()
    {
        int _randomNumber;
        int _rand = UnityEngine.Random.Range(0, _allReadyNumbersTasks.Count);
        _randomNumber = _allReadyNumbersTasks[_rand];
        if (_allReadyNumbersTasks.Contains(_allReadyNumbersTasks[_rand])) _allReadyNumbersTasks.Remove(_allReadyNumbersTasks[_rand]);
        return _randomNumber;
    }
}

public class SaveDailyTasksModel
{
    public DateTime LastEnterToGame;
}

[Serializable]
public class DailyTasksInfoValue
{
    [Header("Type")]
    public TypeTask _typeTaskEnum;

    [Header("For Create, Range(0, 14)")]
    public int _objectLevel;
    [Header("Number aff For Use Baff, Range(1, 5)")]
    public int _numberUseBaff = 1;

    [Header("Intagers Or Floats")]
    public int _maximumQuantity = 1;
    [HideInInspector] public int _currentQuantity;

    [Header("Type Reward")]
    public TypeReward _typeRewardEnum;

    [Header("Number Baff For Add Baff, Range(1, 5)")]
    public int _numberAddBaff = 1;
    public int _quantityAddBaff = 1;

    [Header("Quantity Currency For Add Currency")]
    public int _quantityAddCurrency = 1;

    [HideInInspector] public string ConditionTask = "";

    public string TaskInformation()
    {
        string returnValue = "This task is gone!";

        if (_typeTaskEnum == TypeTask.Create)
        {
            if (_objectLevel != 0) returnValue = $"{LibraryWords.createPenguinTask[_objectLevel].GetText()}";
        }
        else if (_typeTaskEnum == TypeTask.UseBaff)
        {
            if (_numberUseBaff > 0) returnValue = $"{LibraryWords.useBaffTask[_numberUseBaff - 1].GetText()}";
        }
        else if (_typeTaskEnum == TypeTask.Click)
        {
            returnValue = $"{LibraryWords.clickTask.GetText()}";
        }
        return $"{returnValue}";
    }

    public Sprite SpriteReward()
    {
        Sprite _spriteReward = null;
        if (_typeRewardEnum == TypeReward.Baff)
        {
            for (int i = 0; i < DailyTasksModel.spritesForRewardBaff.Length; i++)
            {
                if (DailyTasksModel.spritesForRewardBaff[i].name.Contains($"{_numberAddBaff}"))
                {
                    _spriteReward = DailyTasksModel.spritesForRewardBaff[i];
                    break;
                }
            }
        }
        else if (_typeRewardEnum == TypeReward.SoftCurrency)
        {
            _spriteReward = DailyTasksModel.spriteForRewardSoftCurrency;
        }
        return _spriteReward;
    }

    public int QuantittyBonus()
    {
        if (_typeRewardEnum == TypeReward.Baff)
        {
            return _quantityAddBaff;
        }
        else if (_typeRewardEnum == TypeReward.SoftCurrency)
        {
            return _quantityAddCurrency;
        }
        else return 0;
    }

    public void SaveProgressTask(int _numberTask, int _supplementToProgress)
    {
        _currentQuantity += _supplementToProgress;
        DataPresenter.SaveNewDayEventModel();
        DailyTasksInfoValue _taskValue = NewDayEventModel.instance.tasksOnToday[_numberTask];
        if (
            _taskValue._typeTaskEnum != TypeTask.Click && _taskValue._currentQuantity <= _taskValue._maximumQuantity ||
            _taskValue._typeTaskEnum == TypeTask.Click && _taskValue._currentQuantity == _taskValue._maximumQuantity
        ) SpawnReadyTaskOnMenuPresenter.instance.SpawnReadyTask(_numberTask);
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