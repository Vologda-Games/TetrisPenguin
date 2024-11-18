using System;
using System.Collections.Generic;
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
       // PlayerPrefs.DeleteAll();
    }

    public void LoadResourcesNewDay()
    {
        DateTime _lastEnterToGame = DailyTasksModel._instance.LastEnterToGame;
        if(GamePush.GP_Server.Time().Date > _lastEnterToGame || _lastEnterToGame == null)
        {
            _tasksOnToday = new List<DailyTasksInfoValue>();
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
                int _randomNumberTasks = DailyTasksModel._instance.RandomNumberTask();
                if(!_tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_randomNumberTasks])) _tasksOnToday.Add(DailyTasksModel._instance._allTasks[_randomNumberTasks]);
                _tasksOnToday[_tasksOnToday.Count - 1]._currentQuantity = 0;
            }
            DailyTasksModel._instance.LastEnterToGame = GamePush.GP_Server.Time().Date;
            DataPresenter.SaveDailyTasksModel();
            DataPresenter.SaveNewDayEventModel();
        }
    }
}

public class SaveNewDayEventModel
{
    public List<DailyTasksInfoValue> _tasksOnToday;
}