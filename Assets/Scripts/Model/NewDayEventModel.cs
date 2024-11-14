using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NewDayEventModel : MonoBehaviour
{
    [Header("Massive")]
    [HideInInspector] public List<DailyTasksInfoValue> _tasksOnToday;

    [Header("Scripts")]
    public static NewDayEventModel _instance;

    private void Awake()
    {
        _instance = this;
        PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("LastEnterToGame"))
        {
            PlayerPrefs.SetString("LastEnterToGame", GamePush.GP_Server.Time().Date.ToString("u", CultureInfo.InvariantCulture));
        }
        LoadResourcesNewDay();
        SpawnReadyTaskOnMenuPresenter._instance.SpawnTodayTask();
    }

    private void LoadResourcesNewDay()
    {
        DateTime _lastEnterToGame = DateTime.ParseExact(PlayerPrefs.GetString("LastEnterToGame"), "u", CultureInfo.InvariantCulture);
        List<string> _todayNumbersTaskSTR = new List<string>(NumbersTasksOnToday.Split('.'));
        List<int> _todayNumbersTasks = new List<int>();
        for(int i = 0; i < _todayNumbersTaskSTR.Count; i++)
        {
            _todayNumbersTasks.Add(int.Parse(_todayNumbersTaskSTR[i]));
        }
        if(GamePush.GP_Server.Time().Date > _lastEnterToGame || !PlayerPrefs.HasKey("LastEnterToGame"))
        {
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
                DeleteInformationTask(_tasksOnToday.Count);
                int _randomNumberTasks = DailyTasksModel._instance.RandomNumberTask();
                if(!_tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_randomNumberTasks])) _tasksOnToday.Add(DailyTasksModel._instance._allTasks[_randomNumberTasks]);
                _tasksOnToday[_tasksOnToday.Count - 1]._currentQuantity = 0;
                NumbersTasksOnToday = _randomNumberTasks.ToString();
            }
            PlayerPrefs.SetString("LastEnterToGame", GamePush.GP_Server.Time().Date.ToString("u", CultureInfo.InvariantCulture));
        }
        else
        {
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
                for(int i = 0; i < _todayNumbersTasks.Count; i++)
                {
                    if(!_tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_todayNumbersTasks[i]]))
                    {
                        _tasksOnToday.Add(DailyTasksModel._instance._allTasks[_todayNumbersTasks[i]]);
                        _tasksOnToday[_tasksOnToday.Count - 1]._currentQuantity = PlayerPrefs.GetInt($"ProgressTask{i}");
                    } 
                }
            }
        }
    }

    public static string NumbersTasksOnToday
    {
        get
        {
            return PlayerPrefs.GetString("TodayNumbersTasks");
        }
        set
        {
            if (PlayerPrefs.HasKey("TodayNumbersTasks")) PlayerPrefs.SetString("TodayNumbersTasks", $"{value}.{NumbersTasksOnToday}");
            else PlayerPrefs.SetString("TodayNumbersTasks", $"{value}");
        }
    }

    public void DeleteInformationTask(int _numberTask)
    {
        PlayerPrefs.DeleteKey($"ConditionTask{_numberTask}");
        PlayerPrefs.DeleteKey($"ProgressTask{_numberTask}");
        PlayerPrefs.DeleteKey($"TodayNumbersTasks");
    }
}