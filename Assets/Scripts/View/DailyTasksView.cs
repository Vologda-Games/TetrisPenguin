using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyTasksView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _imageReward;
    [SerializeField] private Image _bar;
    [SerializeField] private Image _barReady;
    [SerializeField] private Image _barCollected;
    [SerializeField] private TextMeshProUGUI _quantityBonus;
    [SerializeField] private TextMeshProUGUI _taskInformation;
    [SerializeField] private TextMeshProUGUI _quantityCompleted;

    [Header("Scripts")]
    public static DailyTasksView _instance;

    [Header("TaskInformation")]
    private int _numberTask;
    private string _conditionTask;

    private void Awake()
    {
        _instance = this;
    }

    public void OutputInformationTask(DailyTasksInfoValue _infoTask, int _numberInfoTask)
    {
        if(!PlayerPrefs.HasKey($"ConditionTask{_numberInfoTask}")) PlayerPrefs.SetString($"ConditionTask{_numberInfoTask}", "NotReady");
        _conditionTask = PlayerPrefs.GetString($"ConditionTask{_numberInfoTask}");
        _numberTask = _numberInfoTask;
        _imageReward.sprite = _infoTask.SpriteReward();
        _quantityBonus.text = $"x{_infoTask.QuantittyBonus()}";
        _taskInformation.text = $"{_infoTask.TaskInformation()}";
        if(_infoTask._currentQuantity < _infoTask._maximumQuantity)
        {
            _bar.fillAmount = (float) _infoTask._currentQuantity / _infoTask._maximumQuantity;
            _quantityCompleted.text = $"{_infoTask._currentQuantity}/{_infoTask._maximumQuantity}";
        }
        else if(_infoTask._currentQuantity >= _infoTask._maximumQuantity &&  _conditionTask != "Collected")
        {
            _quantityCompleted.text = $"Собрать";
            _bar.enabled = false;
            _barReady.enabled = true;
        }
        else if( _conditionTask == "Collected")
        {
            _quantityCompleted.text = $"Собрано";
            _bar.enabled = false;
            _barReady.enabled = false;
            _barCollected.enabled = true;
        }
    }

    public void CollectReward()
    {
        DailyTasksInfoValue _taskToday = NewDayEventModel._instance._tasksOnToday[_numberTask];
        if(_taskToday._currentQuantity >= _taskToday._maximumQuantity &&  _conditionTask != "Collected")
        {
            switch(_taskToday._typeRewardEnum)
            {
                case TypeReward.SoftCurrency:
                    PlayerPresenter.AddCoin(_taskToday._quantityAddCurrency);
                break;
                case TypeReward.Baff:
                    BafsPresenter.AddBaffsByNumber(_taskToday._numberAddBaff, _taskToday._quantityAddBaff);
                break;
            }
            PlayerPrefs.SetString($"ConditionTask{_numberTask}", "Collected");
            _quantityCompleted.text = $"Собрано";
            _barReady.enabled = false;
            _barCollected.enabled = true;
        }
    }
}