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
    [SerializeField] private Button _thisButton;

    [Header("TaskInformation")]
    [HideInInspector] public int _numberTask;
    [HideInInspector] public RectTransform _rectTransform;
    [HideInInspector] public float _secondsDealayTask;
    [HideInInspector] public bool _right;
    [HideInInspector] public bool _taskInMenu = false;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _secondsDealayTask = 0;
    }

    public void OutputInformationTask(DailyTasksInfoValue _infoTask, int _numberInfoTask)
    {
        string Condition = NewDayEventModel._instance.tasksOnToday[_numberInfoTask].ConditionTask;
        if (Condition == "" || Condition == null) NewDayEventModel._instance.tasksOnToday[_numberInfoTask].ConditionTask = "NotReady";
        _numberTask = _numberInfoTask;
        _imageReward.sprite = _infoTask.SpriteReward();
        _quantityBonus.text = $"x{_infoTask.QuantittyBonus()}";
        _taskInformation.text = $"{_infoTask.TaskInformation()}";
        _bar.enabled = true;
        _barCollected.enabled = false;
        _barReady.enabled = false;
        _thisButton.interactable = true;
        if (_infoTask._currentQuantity < _infoTask._maximumQuantity)
        {
            _bar.fillAmount = (float)_infoTask._currentQuantity / _infoTask._maximumQuantity;
            _quantityCompleted.text = $"{_infoTask._currentQuantity}/{_infoTask._maximumQuantity}";
        }
        else if (_infoTask._currentQuantity >= _infoTask._maximumQuantity && Condition != "Collected")
        {
            _quantityCompleted.text = $"Собрать";
            _bar.enabled = false;
            _barReady.enabled = true;
        }
        else if (Condition == "Collected")
        {
            _quantityCompleted.text = $"Собрано";
            _bar.enabled = false;
            _barCollected.enabled = true;
            _thisButton.interactable = false;
        }
    }

    public void CollectReward()
    {
        string Condition = NewDayEventModel._instance.tasksOnToday[_numberTask].ConditionTask;
        DailyTasksInfoValue _taskToday = NewDayEventModel._instance.tasksOnToday[_numberTask];
        if (_taskToday._currentQuantity >= _taskToday._maximumQuantity && Condition != "Collected")
        {
            switch (_taskToday._typeRewardEnum)
            {
                case TypeReward.SoftCurrency:
                    PlayerPresenter.instance.AddCoin(_taskToday._quantityAddCurrency);
                    break;
                case TypeReward.Baff:
                    BafsPresenter.AddBaffsByNumber(_taskToday._numberAddBaff, _taskToday._quantityAddBaff);
                    break;
            }
            NewDayEventModel._instance.tasksOnToday[_numberTask].ConditionTask = "Collected";
            DataPresenter.SaveNewDayEventModel();
            _quantityCompleted.text = $"Собрано";
            _barReady.enabled = false;
            _barCollected.enabled = true;
            GetComponent<Button>().interactable = false;
        }
    }

    public void ClickButton()
    {
        MusicAndSoundsManager._instance.PlaySoundClickOnButton();
    }

    private void FixedUpdate()
    {
        if (_taskInMenu)
        {
            if (_right)
            {
                _secondsDealayTask = 4f;
                if (_rectTransform.localPosition.x < 0f) _rectTransform.localPosition = Vector2.MoveTowards(_rectTransform.localPosition, new Vector2(0f, _rectTransform.localPosition.y), 25f);
                else if (_rectTransform.localPosition.x >= 0f) _right = false;
            }
            else
            {
                if (_secondsDealayTask > 0f) _secondsDealayTask -= Time.fixedDeltaTime;
                if (_secondsDealayTask <= 0f)
                {
                    _rectTransform.localPosition = Vector2.MoveTowards(_rectTransform.localPosition, new Vector2(-_rectTransform.sizeDelta.x, _rectTransform.localPosition.y), 25f);
                }
            }
        }
    }
}