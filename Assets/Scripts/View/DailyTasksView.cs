using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyTasksView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _imageReward;
    [SerializeField] private Image _bar;
    [SerializeField] private TextMeshProUGUI _quantityBonus;
    [SerializeField] private TextMeshProUGUI _taskInformation;
    [SerializeField] private TextMeshProUGUI _quantityCompleted;

    [Header("Scriptsa")]
    public static DailyTasksView _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void OutputInformationTask(int _numberTask)
    {
        _imageReward.sprite = DailyTasksModel._instance._allTasks[_numberTask].SpriteReward();
        _quantityBonus.text = $"x{DailyTasksModel._instance._allTasks[_numberTask].QuantittyBonus()}";
        _taskInformation.text = $"{DailyTasksModel._instance._allTasks[_numberTask].TaskInformation()}";
        _quantityCompleted.text = $"{DailyTasksModel._instance._allTasks[_numberTask]._currentQuantity}/{DailyTasksModel._instance._allTasks[_numberTask]._maximumQuantity}";
        _bar.fillAmount = (float) DailyTasksModel._instance._allTasks[_numberTask]._currentQuantity / DailyTasksModel._instance._allTasks[_numberTask]._maximumQuantity;
    }
}