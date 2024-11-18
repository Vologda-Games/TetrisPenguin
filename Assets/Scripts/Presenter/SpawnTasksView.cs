using TMPro;
using UnityEngine;

public class SpawnTasksView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] public TMP_Text _textCoins;


    [Header("Transform")]
    [SerializeField] private Transform _parentTasks;

    [Header("GameObjects")]
    [SerializeField] private GameObject _taskObject;

    private void Start()
    {
        PlayerView.instance._coinsTextInWindow = _textCoins;
        PlayerView.instance.RenderCoin();
        SpawnTask();
    }

    public void SpawnTask()
    {
        for (int i = 0; i < NewDayEventModel._instance._tasksOnToday.Count; i++)
        {
            GameObject _newTask = Instantiate(_taskObject, _parentTasks.transform.position, Quaternion.identity, _parentTasks);
            DailyTasksView _dailyTasksView = _newTask.GetComponent<DailyTasksView>();
            if (_dailyTasksView != null) _dailyTasksView.OutputInformationTask(NewDayEventModel._instance._tasksOnToday[i], i);
        }
    }
}
