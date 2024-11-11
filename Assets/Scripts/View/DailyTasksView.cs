using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyTasksView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _imageReward;
    [SerializeField] private Image _bar;
    [SerializeField] private Image _barReady;
    [SerializeField] private TextMeshProUGUI _quantityBonus;
    [SerializeField] private TextMeshProUGUI _taskInformation;
    [SerializeField] private TextMeshProUGUI _quantityCompleted;

    [Header("Scripts")]
    public static DailyTasksView _instance;

    [Header("Boolians")]
    [SerializeField] public bool _readyTask;

    private void Awake()
    {
        _instance = this;
    }

    public void OutputInformationTask(DailyTasksInfoValue _infoTask)
    {
        _imageReward.sprite = _infoTask.SpriteReward();
        _quantityBonus.text = $"x{_infoTask.QuantittyBonus()}";
        _taskInformation.text = $"{_infoTask.TaskInformation()}";
        if(_infoTask._currentQuantity != _infoTask._maximumQuantity)
        {
            _bar.fillAmount = (float) _infoTask._currentQuantity / _infoTask._maximumQuantity;
            _quantityCompleted.text = $"{_infoTask._currentQuantity}/{_infoTask._maximumQuantity}";
        }
        else
        {
            _quantityCompleted.text = $"Выполнено";;
            _bar.enabled = false;
            _barReady.enabled = true;
        }
    }
}