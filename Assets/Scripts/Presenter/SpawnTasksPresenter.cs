using UnityEngine;

public class SpawnTasksPresenter : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform _parentTasks;

    [Header("GameObjects")]
    [SerializeField] private GameObject _taskObject;

    private void Start()
    {
        SpawnTask();
    }

    public void SpawnTask()
    {
        for (int i = 0; i < NewDayEventModel._instance.tasksOnToday.Count; i++)
        {
            GameObject _newTask = Instantiate(_taskObject, _parentTasks);
            DailyTasksView _dailyTasksView = _newTask.GetComponent<DailyTasksView>();
            if (_dailyTasksView != null) _dailyTasksView.OutputInformationTask(NewDayEventModel._instance.tasksOnToday[i], i);
        }
    }
}
