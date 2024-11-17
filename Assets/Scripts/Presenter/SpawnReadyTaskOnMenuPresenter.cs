using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReadyTaskOnMenuPresenter : MonoBehaviour
{
    [Header("TasksInMenu")]

    private List<DailyTasksView> _dailyTasksViewMenu = new List<DailyTasksView>();
    [Header("InformationToTaskObject")]

    [SerializeField] private GameObject _prefabRadyTask;
    [SerializeField] private Transform _parentObject;

    [Header("Scripts")]
    
    [SerializeField] public static SpawnReadyTaskOnMenuPresenter _instance;

    private void Start()
    {
        _instance = this;
    }

    public void SpawnTodayTask()
    {
        for(int i = 0; i < NewDayEventModel._instance._tasksOnToday.Count; i++)
        {
            GameObject _taskReady = Instantiate(_prefabRadyTask, _parentObject);
            _dailyTasksViewMenu.Add(_taskReady.GetComponent<DailyTasksView>());
            _dailyTasksViewMenu[i].OutputInformationTask(NewDayEventModel._instance._tasksOnToday[i], i);
        }
    }

    public void SpawnReadyTask(int _numberReadyTask)
    {
        for(int i = 0; i < _dailyTasksViewMenu.Count; i++)
        {
            DailyTasksView _task = _dailyTasksViewMenu[i];
            if (_task._numberTask == _numberReadyTask && i == 0)
            {
                _task.OutputInformationTask(NewDayEventModel._instance._tasksOnToday[_numberReadyTask], _numberReadyTask);
                if(!_task._right && _task._secondsDealayTask > 0f) _task._secondsDealayTask = 4f;
                else if(!_task._right && _task._secondsDealayTask <= 0f) _task._right = true;
            }else if (_task._numberTask == _numberReadyTask)
            {
                if(_task._rectTransform.localPosition.x <= -_task._rectTransform.sizeDelta.x)
                {
                    for(int j = 0; j < _dailyTasksViewMenu.Count; j++)
                    {
                        DailyTasksView _objectTask = _dailyTasksViewMenu[j];
                        if(_objectTask._rectTransform.localPosition.x <= -_objectTask._rectTransform.sizeDelta.x)
                        {
                            int _infoOne = _objectTask._numberTask;
                            _dailyTasksViewMenu[j].OutputInformationTask(NewDayEventModel._instance._tasksOnToday[_numberReadyTask], _numberReadyTask);
                            if(!_objectTask._right && _objectTask._secondsDealayTask > 0f) _objectTask._secondsDealayTask = 4f;
                            else if(!_objectTask._right && _objectTask._secondsDealayTask <= 0f) _objectTask._right = true;
                            _dailyTasksViewMenu[i].OutputInformationTask(NewDayEventModel._instance._tasksOnToday[_infoOne], _infoOne);
                            break;
                        }
                    }
                }else
                {
                    _task.OutputInformationTask(NewDayEventModel._instance._tasksOnToday[_numberReadyTask], _numberReadyTask);
                    if(!_task._right && _task._secondsDealayTask > 0f) _task._secondsDealayTask = 4f;
                    else if(!_task._right && _task._secondsDealayTask <= 0f) _task._right = true;
                }
            }
        }
    }
}