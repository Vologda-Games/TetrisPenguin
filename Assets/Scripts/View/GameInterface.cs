using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    public void OpenFirstLayout(string nameView)
    {
        activeViewString = nameView;
        GameObject prefab = GetViewByName(nameView);
        GameObject view = Instantiate(prefab, Vector3.zero, Quaternion.identity, _parent);
        _activeViewTransform = view.transform;
        if (activeView != null) StartCoroutine(ScaleShowAnimation(_activeViewTransform));
        _activeViewTransform.localPosition = Vector3.zero;
        activeView = view;
        isActiveInterface = true;
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

    public void EventOpenShop()
    {
        //Вешать только на Button
        OpenFirstLayout(Views.SHOP);
    }

    public void EventCloseFirstLayoutByBackground()
    {
        //Вешать только на Background
        CloseFirstLayout();
    }


    private GameObject GetViewByName(string name)
    {
        if (name == Views.SHOP) return ViewModel.instance.shop;
        return null;
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