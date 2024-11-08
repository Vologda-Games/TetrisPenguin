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
        //PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("LastEnterToGame"))
        {
            PlayerPrefs.SetString("LastEnterToGame", GamePush.GP_Server.Time().Date.ToString("u", CultureInfo.InvariantCulture));
        }
        LoadResourcesNewDay();
    }

    private void LoadResourcesNewDay()
    {
        DateTime _lastEnterToGame = DateTime.ParseExact(PlayerPrefs.GetString("LastEnterToGame"), "u", CultureInfo.InvariantCulture);
        List<string> _todayNumbersTaskSTR = new List<string>(PlayerPrefs.GetString("TodayNumbersTask").Split('.'));
        List<int> _todayNumbersTask = new List<int>();
        for(int i = 0; i < _todayNumbersTaskSTR.Count - 1; i++)
        {
            _todayNumbersTask.Add(int.Parse(_todayNumbersTaskSTR[i]));
        }
        if(GamePush.GP_Server.Time().Date > _lastEnterToGame || !PlayerPrefs.HasKey("LastEnterToGame"))
        {
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
                int _randomNumberTask = DailyTasksModel._instance.RandomNumberTask();
                if(!_tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_randomNumberTask])) _tasksOnToday.Add(DailyTasksModel._instance._allTasks[_randomNumberTask]);
                PlayerPrefs.SetString("TodayNumbersTask", $"{_randomNumberTask}.{PlayerPrefs.GetString("TodayNumbersTask")}");
            }
            PlayerPrefs.SetString("LastEnterToGame", GamePush.GP_Server.Time().Date.ToString("u", CultureInfo.InvariantCulture));
        }
        else
        {
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
               for(int i = 0; i < _todayNumbersTask.Count; i++)
                {
                    if(!_tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_todayNumbersTask[i]]))  _tasksOnToday.Add(DailyTasksModel._instance._allTasks[_todayNumbersTask[i]]);
                }
            }
        }
    }
}