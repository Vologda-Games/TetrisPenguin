using System.Collections;
using UnityEngine;

public class ScreenView : MonoBehaviour
{
    public static ScreenView instance;
    public bool homeSlider;
    public bool homeSliderPlay;
    public bool settingsSlider;
    public bool settingsSliderPlay;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform _homeSliderTransform;
    [SerializeField] private Transform _settingsSliderTransform;
    [SerializeField] private CanvasGroup _homeSliderCanvasGroup;
    [SerializeField] private CanvasGroup _settingsSliderCanvasGroup;


    private void Awake()
    {
        instance = this;
    }

    private void LateUpdate()
    {
        //Перемещение камеры с помощью клавиатуры
        MovingCameraKeyboard();
        //Перемещение камеры с помощью Touch
        // MovingCameraTouch();
    }

    public void Down()
    {
        CloseSliders();
        SetPos();
    }

    public void Move()
    {
        SetPos();
    }

    public void Up()
    {
        SetPos();

        if (BafsPresenter.GetSelectBaf() == 5) BafsPresenter.SetSelectBaf(0);
        //if (PenguinsModel.instance.penguinInSpawn == null) return;

        PenguinsPresenter.instance.StartPenguin();
    }

    private void SetPos()
    {
        if (BafsPresenter.GetSelectBaf() == 5) return;
        if (BafsView.instance.triggerBtn) return;

        float pos = cam.ScreenToWorldPoint(Input.mousePosition).x;
        if (pos < -2.2f) { pos = -2.2f; }
        else if (pos > 2.2f) { pos = 2.2f; }
        ScreenModel.instance.posTouch = pos;
    }

    private void MovingCameraTouch()
    {
        if (BafsPresenter.GetSelectBaf() == 5) return;
        if (BafsView.instance.triggerBtn) return;

        if (Input.GetMouseButtonDown(0))
        {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x;
            if (pos < -2.2f) { pos = -2.2f; }
            else if (pos > 2.2f) { pos = 2.2f; }
            ScreenModel.instance.posTouch = pos;
        }
        if (Input.GetMouseButton(0))
        {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x;
            if (pos < -2.2f) { pos = -2.2f; }
            else if (pos > 2.2f) { pos = 2.2f; }
            ScreenModel.instance.posTouch = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x;
            if (pos < -2.2f) { pos = -2.2f; }
            else if (pos > 2.2f) { pos = 2.2f; }
            ScreenModel.instance.posTouch = pos;
            if (PenguinsModel.instance.penguinInSpawn == null) return;

            PenguinsPresenter.instance.StartPenguin();
        }
    }

    private void MovingCameraKeyboard()
    {
        // if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) { _mapController.Up(); }
        // if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) { _mapController.Down(); }
        // if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) { _mapController.Left(); }
        // if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) { _mapController.Right(); }
    }

    private IEnumerator OpenHomeSlider()
    {
        homeSlider = true;
        homeSliderPlay = true;
        float stage = 0.5f;
        _homeSliderTransform.localPosition = new Vector3(-465, -82.5f, 0);
        _homeSliderTransform.localScale = Vector3.zero;
        _homeSliderCanvasGroup.alpha = 0;
        _homeSliderTransform.gameObject.SetActive(true);
        while (stage < 1)
        {
            stage += Time.fixedDeltaTime * 4;
            if (stage < 1)
            {
                _homeSliderTransform.localPosition = new Vector3(-465, Mathf.Lerp(0, -82.5f, stage), 0);
                _homeSliderTransform.localScale = new Vector3(stage, stage, 1);
                _homeSliderCanvasGroup.alpha = stage;
            }
            else
            {
                _homeSliderTransform.localPosition = new Vector3(-465, -82.5f, 0);
                _homeSliderTransform.localScale = new Vector3(1, 1, 1);
                _homeSliderCanvasGroup.alpha = 1;
            }
            yield return new WaitForFixedUpdate();
        }
        homeSliderPlay = false;
    }

    private IEnumerator OpenSettingsSlider()
    {
        settingsSliderPlay = true;
        settingsSlider = true;
        float stage = 0.5f;
        _settingsSliderTransform.localPosition = new Vector3(465, -75, 0);
        _settingsSliderTransform.localScale = Vector3.zero;
        _settingsSliderCanvasGroup.alpha = 0;
        _settingsSliderTransform.gameObject.SetActive(true);
        while (stage < 1)
        {
            if (stage < 1)
            {
                stage += Time.fixedDeltaTime * 4;
                _settingsSliderTransform.localPosition = new Vector3(465, Mathf.Lerp(0, -82.5f, stage), 0);
                _settingsSliderTransform.localScale = new Vector3(stage, stage, 1);
                _settingsSliderCanvasGroup.alpha = stage;
            }
            else
            {
                _settingsSliderTransform.localPosition = new Vector3(465, -82.5f, 0);
                _settingsSliderTransform.localScale = new Vector3(1, 1, 1);
                _settingsSliderCanvasGroup.alpha = 1;
            }
            yield return new WaitForFixedUpdate();
        }

        settingsSliderPlay = false;
    }

    private IEnumerator CloseHomeSlider()
    {
        homeSliderPlay = true;
        homeSlider = false;
        float stage = 1;
        _homeSliderTransform.localPosition = new Vector3(-465, -82.5f, 0);
        _homeSliderTransform.localScale = new Vector3(1, 1, 1);
        _homeSliderCanvasGroup.alpha = 1;
        while (stage > 0.5f)
        {
            stage -= Time.fixedDeltaTime * 4;
            _homeSliderTransform.localPosition = new Vector3(-465, Mathf.Lerp(0, -82.5f, stage), 0);
            _homeSliderTransform.localScale = new Vector3(stage, stage, 1);
            _homeSliderCanvasGroup.alpha = stage;
            yield return new WaitForFixedUpdate();
        }
        _homeSliderTransform.localPosition = new Vector3(-465, 0, 0);
        _homeSliderTransform.localScale = Vector3.zero;
        _homeSliderCanvasGroup.alpha = 0;
        _homeSliderTransform.gameObject.SetActive(false);
        homeSliderPlay = false;
    }

    private IEnumerator CloseSettingsSlider()
    {
        settingsSliderPlay = true;
        settingsSlider = false;
        float stage = 1;
        _settingsSliderTransform.localPosition = new Vector3(465, -82.5f, 0);
        _settingsSliderTransform.localScale = new Vector3(1, 1, 1);
        _settingsSliderCanvasGroup.alpha = 1;
        while (stage > 0.5f)
        {
            stage -= Time.fixedDeltaTime * 4;
            _settingsSliderTransform.localPosition = new Vector3(465, Mathf.Lerp(0, -82.5f, stage), 0);
            _settingsSliderTransform.localScale = new Vector3(stage, stage, 1);
            _settingsSliderCanvasGroup.alpha = stage;
            yield return new WaitForFixedUpdate();
        }
        _settingsSliderTransform.localPosition = new Vector3(465, 0, 0);
        _settingsSliderTransform.localScale = Vector3.zero;
        _settingsSliderCanvasGroup.alpha = 0;
        _settingsSliderTransform.gameObject.SetActive(false);
        settingsSliderPlay = false;
    }

    public void EventHomeSlider()
    {
        BafsView.instance.StartTriggerBtn();
        if (homeSliderPlay == false)
        {
            if (homeSlider)
            {
                StartCoroutine(CloseHomeSlider());
            }
            else
            {
                if (settingsSlider)
                {
                    StartCoroutine(CloseSettingsSlider());
                }
                StartCoroutine(OpenHomeSlider());
            }
        }
    }

    public void EventSettingsSlider()
    {
        BafsView.instance.StartTriggerBtn();
        if (settingsSliderPlay == false)
        {
            if (settingsSlider)
            {
                StartCoroutine(CloseSettingsSlider());
            }
            else
            {
                if (homeSlider)
                {
                    StartCoroutine(CloseHomeSlider());
                }
                StartCoroutine(OpenSettingsSlider());
            }
        }
    }

    public void CloseSliders()
    {
        if (homeSlider)
        {
            BafsView.instance.StartTriggerBtn();
            StartCoroutine(CloseHomeSlider());
        }
        if (settingsSlider)
        {
            BafsView.instance.StartTriggerBtn();
            StartCoroutine(CloseSettingsSlider());
        }
    }
}