using UnityEngine;

public class SpawnRandomTasksView : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform _parentTasks;

    [Header("GameObjects")]
    [SerializeField] private GameObject _taskObject;

    private void Start()
    {
        SpawnRandomTask();
    }

    public void SpawnRandomTask()
    {
        //Debug.Log(DailyTasksModel._instance._maxQuantityTaskOfDay);
        while(_parentTasks.childCount < 3)
        {
            GameObject _newTask = Instantiate(_taskObject, _parentTasks.transform.position, Quaternion.identity, _parentTasks);
            DailyTasksView _dailyTasksView = _newTask.GetComponent<DailyTasksView>();
            if(_dailyTasksView != null) _dailyTasksView.OutputInformationTask(DailyTasksModel._instance.RandomNumberTask());
        }
    }
}
