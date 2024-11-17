using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NewDayEventModel : MonoBehaviour
{
    [Header("Massive")]
    [HideInInspector] public List<DailyTasksInfoValue> _tasksOnToday;

    [Header("string")]
    [SerializeField] public string TodayNumbersTasks;

    [Header("Scripts")]
    public static NewDayEventModel _instance;

    private void Awake()
    {
        _instance = this;
       // PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        LoadResourcesNewDay();
        SpawnReadyTaskOnMenuPresenter._instance.SpawnTodayTask();
    }

    private void LoadResourcesNewDay()
    {
        DateTime _lastEnterToGame = DailyTasksModel._instance.LastEnterToGame;
        List<string> _todayNumbersTaskSTR = new List<string>(NumbersTasksOnToday.Split('.'));
        List<int> _todayNumbersTasks = new List<int>();
        print(_lastEnterToGame);
        for(int i = 0; i < _todayNumbersTaskSTR.Count; i++)
        {
            _todayNumbersTasks.Add(int.Parse(_todayNumbersTaskSTR[i]));
        }
        if(GamePush.GP_Server.Time().Date > _lastEnterToGame || DailyTasksModel._instance.LastEnterToGame == null)
        {
            _tasksOnToday = new List<DailyTasksInfoValue>();
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
                DeleteInformationTask();
                int _randomNumberTasks = DailyTasksModel._instance.RandomNumberTask();
                if(!_tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_randomNumberTasks])) _tasksOnToday.Add(DailyTasksModel._instance._allTasks[_randomNumberTasks]);
                _tasksOnToday[_tasksOnToday.Count - 1]._currentQuantity = 0;
                NumbersTasksOnToday = _randomNumberTasks.ToString();
            }
            DailyTasksModel._instance.LastEnterToGame = GamePush.GP_Server.Time().Date;
        }/*else
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
        }*/
    }

    public string NumbersTasksOnToday
    {
        get
        {
            return TodayNumbersTasks;
        }
        set
        {
            if (TodayNumbersTasks != "" && TodayNumbersTasks != null) TodayNumbersTasks = $"{value}.{NumbersTasksOnToday}";
            else TodayNumbersTasks = $"{value}";
        }
    }

    public void DeleteInformationTask()
    {
        TodayNumbersTasks = "";
        DataPresenter.SaveNewDayEventModel();
    }
}

public class SaveNewDayEventModel
{
    public string TodayNumbersTasks;
    public List<DailyTasksInfoValue> _tasksOnToday;
}