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

    private void Start()
    {
        OutputInformationTask(Random.Range(0, DailyTasksModel._allTasksStatic.Count));

        for(int i = 0; i < DailyTasksModel._allTasksStatic.Count; i++)
        {
            Debug.Log($"Что нужно делать : {DailyTasksModel._allTasksStatic[i].TaskInformation()} Сколько раз нужно делать : {DailyTasksModel._allTasksStatic[i]._maximumQuantity} Сколько раз уже сделано : {DailyTasksModel._allTasksStatic[i]._currentQuantity}");
        }
    }

    public void OutputInformationTask(int _numberTask)
    {
        _imageReward.sprite = DailyTasksModel._allTasksStatic[_numberTask].SpriteReward();
        _quantityBonus.text = $"x{DailyTasksModel._allTasksStatic[_numberTask].QuantittyBonus()}";
        _taskInformation.text = $"{DailyTasksModel._allTasksStatic[_numberTask].TaskInformation()}";
        _quantityCompleted.text = $"{DailyTasksModel._allTasksStatic[_numberTask]._currentQuantity}/{DailyTasksModel._allTasksStatic[_numberTask]._maximumQuantity}";
        _bar.fillAmount = (float) DailyTasksModel._allTasksStatic[_numberTask]._currentQuantity / DailyTasksModel._allTasksStatic[_numberTask]._maximumQuantity;
    }
}