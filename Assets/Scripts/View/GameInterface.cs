using System.Collections;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    public static GameInterface instance;
    // [SerializeField] private CanvasScaler _mainInterface;
    // [SerializeField] private CanvasScaler _secondInterface;
    [SerializeField] private Transform _parent;
    private Transform _activeViewTransform;
    public string activeViewString;
    public GameObject activeView;
    public bool isActiveInterface;

    private void Awake()
    {
        instance = this;
    }

    // private void Start()
    // {
    //     if (Camera.main.aspect < 0.56f)
    //     {
    //         _mainInterface.matchWidthOrHeight = 0f;
    //         _secondInterface.matchWidthOrHeight = 0f;
    //     }
    //     else
    //     {
    //         _mainInterface.matchWidthOrHeight = 1f;
    //         _secondInterface.matchWidthOrHeight = 1f;
    //     }
    // }

    // void Start() 
    // {
    //     Invoke("EventOpenDailyRewards", 0.3f);
    // }
    void Start()
    {
        if (DailyRewardsPresenter.instance.isReward())
        {
            EventOpenDailyRewards();
        }
        //DailyRewardsPresenter.instance.NewDay();
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.X)) 
    //     {
    //         if (DailyRewardsPresenter.instance.GetIsWindowDailtRewardsBool()) 
    //         {
    //             DailyRewardsView.instance.CloseWindow();
    //         }
    //         StartCoroutine(openDailyRewardss());
    //     }
    // }

    IEnumerator openDailyRewardss() 
    {
        yield return new WaitForSeconds(0.3f);
        EventOpenDailyRewards();
        DailyRewardsPresenter.instance.NewDay();
    }

    public void OpenFirstLayout(string nameView)
    {
        if (_parent.childCount == 0)
        {
            activeViewString = nameView;
            GameObject prefab = GetViewByName(nameView);
            GameObject view = Instantiate(prefab, Vector3.zero, Quaternion.identity, _parent);
            _activeViewTransform = view.transform;
            _activeViewTransform.localPosition = Vector3.zero;
            activeView = view;
            isActiveInterface = true;
            if (activeView != null) StartCoroutine(ScaleShowAnimation(_activeViewTransform));
        }

    }

    public void CloseFirstLayout()
    {
        if (activeView != null)
        {
            // Destroy(activeView);
            StartCoroutine(ScaleHideAnimation(_activeViewTransform));
            activeView = null;
            activeViewString = "";
        }
        if (activeView == null)
        {
            isActiveInterface = false;
        }
    }

    public void EventOpenDailyRewards()
    {
        //Вешать только на button
        OpenFirstLayout(Views._dailyRewards);
    }

    public void EventOpenShop()
    {
        //Вешать только на Button
        OpenFirstLayout(Views._shop);
    }

    public void EventOpenWheelOfLuck()
    {
        //Вешать только на Button
        OpenFirstLayout(Views._wheelOfLuck);
    }

    public void EventOpenRatings()
    {
        //Вешать только на Button
        OpenFirstLayout(Views._ratings);
    }

    public void EventOpenDailyTasks()
    {
        //Вешать только на Button
        OpenFirstLayout(Views._dailyTasks);
    }

    public void EventOpenTablePenguins()
    {
        //Вешать только на Button
        OpenFirstLayout(Views._tablePenguins);
    }

    public void EventCloseFirstLayoutByBackground()
    {
        //Вешать только на Background
        CloseFirstLayout();
    }


    private GameObject GetViewByName(string name)
    {
        GameObject _object = null;
        if (name == Views._shop)
        {
            _object = ViewModel.instance._shop;
        }
        else if (name == Views._dailyTasks)
        {
            _object = ViewModel.instance._dailyTasks;
        }
        else if (name == Views._wheelOfLuck)
        {
            _object = ViewModel.instance._wheelOfLuck;
        }
        else if (name == Views._ratings)
        {
            _object = ViewModel.instance._ratings;
        }
        else if (name == Views._dailyRewards)
        {
            _object = ViewModel.instance._dailyRewards;
        }
        else if (name == Views._tablePenguins)
        {
            _object = ViewModel.instance._tablePenguins;
        }
        else _object = null;

        return _object;
    }

    private IEnumerator ScaleShowAnimation(Transform viewTransform)
    {
        float stage = 0f;
        float scale = 0f;
        while (stage < 1f)
        {
            stage += Time.fixedDeltaTime * 3;
            scale = Mathf.Lerp(0, 1, stage);
            viewTransform.localScale = new Vector3(scale, scale, 0);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator ScaleHideAnimation(Transform viewTransform)
    {
        float stage = 0f;
        float scale = 0f;
        while (stage < 1f)
        {
            stage += Time.fixedDeltaTime * 4;
            scale = Mathf.Lerp(1, 0, stage);
            viewTransform.localScale = new Vector3(scale, scale, 0);
            yield return new WaitForFixedUpdate();
        }
        Destroy(viewTransform.gameObject);
    }
}