using System.Collections;
using UnityEngine;

public class SpawnReadyTaskOnMenuPresenter : MonoBehaviour
{
    [Header("InformationToTaskObject")]

    [SerializeField] private GameObject _prefabRadyTask;
    [SerializeField] private Transform _parentObject;

    [Header("Scripts")]
    
    [SerializeField] public static SpawnReadyTaskOnMenuPresenter _instance;

    private void Start()
    {
        _instance = this;
    }

    public void SpawnReadyTask(int _numberReadyTask)
    {
        bool _readySimulationTask = false;
        for(int i = 0; i < _parentObject.childCount; i++)
        {
            if (_parentObject.GetChild(i).GetComponent<DailyTasksView>()._numberTask == _numberReadyTask)
            {
                _parentObject.GetChild(i).GetComponent<DailyTasksView>().OutputInformationTask(NewDayEventModel._instance._tasksOnToday[_numberReadyTask], _numberReadyTask);
                _parentObject.GetChild(i).GetComponent<DailyTasksView>()._secondsDealayTask = 3;
                _parentObject.GetChild(i).GetComponent<DailyTasksView>()._typeTask = "InMenu";
                _readySimulationTask = true;
                break;
            }
        }
        if(_parentObject.childCount <= 0 || !_readySimulationTask)
        {
            GameObject _taskReady = Instantiate(_prefabRadyTask, _parentObject);
            RectTransform _transformTask = _taskReady.GetComponent<RectTransform>();
            _taskReady.GetComponent<DailyTasksView>().OutputInformationTask(NewDayEventModel._instance._tasksOnToday[_numberReadyTask], _numberReadyTask);
            if(_taskReady.GetComponent<DailyTasksView>()._typeTask != "InMenu") _taskReady.GetComponent<DailyTasksView>()._typeTask = "InMenu";
        }
    }
}