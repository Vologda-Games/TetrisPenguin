using System.Collections;
using TMPro;
using UnityEngine;

public class BafsView : MonoBehaviour
{
    public static BafsView instance;
    [SerializeField] private TMP_Text[] _countTexts;
    public bool triggerBtn;
    [SerializeField] public GameObject[] _blackBackgroundButtons;
    public bool isBlackBackground;
    public bool isMulticolor;
    public bool isSpring;
    public bool isBomb;
    private void Awake()
    {
        instance = this;
    }

    public void RenderCountBafs()
    {
        _countTexts[0].text = BafsPresenter.GetMulticolorBafs().ToString();
        _countTexts[1].text = BafsPresenter.GetSpringBafs().ToString();
        _countTexts[2].text = BafsPresenter.GetBombBafs().ToString();
        _countTexts[3].text = BafsPresenter.GetTornadoBafs().ToString();
        _countTexts[4].text = BafsPresenter.GetMagnetBafs().ToString();
    }

    public void StartTriggerBtn()
    {
        triggerBtn = true;
        StartCoroutine(Trigger());
    }

    public void EventOnClickBaf(int index)
    {
        triggerBtn = true;
        StartCoroutine(Trigger());
        ScreenView.instance.CloseSliders();
        Debug.Log($"GetSelectBaf({index})");
        switch (index)
        {
            case 0:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    Debug.Log("Появление мультияйца");
                    if (BafsPresenter.GetMulticolorBafs() > 0)
                    {
                        BafsPresenter.Multicolor();
                        _blackBackgroundButtons[0].SetActive(true);
                        isBlackBackground = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 1)
                {
                    Debug.Log("Отмена мультияйца");
                    BafsPresenter.CancelMulticolor();
                    _blackBackgroundButtons[0].SetActive(false);
                    isMulticolor = false;
                }
                else if (isSpring && isMulticolor) 
                {
                    Debug.Log("Мультияйцо: условие isSprig и isMulticolor");
                    BafsPresenter.CancelMulticolor();
                    _blackBackgroundButtons[0].SetActive(false);
                    isMulticolor = false;
                }
                else if (BafsPresenter.GetSelectBaf() == 2) 
                {
                    isMulticolor = true;
                    isSpring = true;
                    Debug.Log("Мультияйцо + перчатка");
                    BafsPresenter.Multicolor();
                    BafsPresenter.Spring();
                    if (PenguinsModel.instance.penguinInSpawn != null)
                    {
                        ProjectionView.instance.RedProjection();
                    }
                    _blackBackgroundButtons[0].SetActive(true);
                    _blackBackgroundButtons[1].SetActive(true);
                    isBlackBackground = true;
                }
                else if (BafsPresenter.GetSelectBaf() != 1 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    Debug.Log("Мультияйцо: отмена всех бафов");
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    _blackBackgroundButtons[0].SetActive(true);
                    EventOnClickBaf(0);
                }
                break;
            case 1:
                if (BafsPresenter.GetSelectBaf() == 0 )
                {
                    if (BafsPresenter.GetSpringBafs() > 0)
                    {
                        Debug.Log("Появление перчатки");
                        BafsPresenter.Spring();
                        _blackBackgroundButtons[1].SetActive(true);
                        isBlackBackground = true;
                        isSpring = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 2)
                {
                    Debug.Log("Отмена перчатки");
                    BafsPresenter.CancelSpring();
                    _blackBackgroundButtons[1].SetActive(false);
                    //BafsPresenter.SetActiveBlackbackgroundBtn();
                    isSpring = false;
                }
                else if (BafsPresenter.GetSelectBaf() == 1 || BafsPresenter.GetSelectBaf() == 3) 
                {
                    isSpring = true;
                    Debug.Log("Перчатка + (мультияйцо или бомба)");
                    if (BafsPresenter.GetSelectBaf() == 1) 
                    {
                        BafsPresenter.Multicolor();
                        BafsPresenter.Spring();
                        if (PenguinsModel.instance.penguinInSpawn != null)
                        {
                            ProjectionView.instance.RedProjection();
                        }
                        _blackBackgroundButtons[0].SetActive(true);
                        _blackBackgroundButtons[1].SetActive(true);
                        isBlackBackground = true;
                        isMulticolor = true;
                    }
                    else if (BafsPresenter.GetSelectBaf() == 3) 
                    {
                        BafsPresenter.Bomb();
                        BafsPresenter.Spring();
                        if (PenguinsModel.instance.penguinInSpawn != null)
                        {
                            ProjectionView.instance.RedProjection();
                        }
                        _blackBackgroundButtons[1].SetActive(true);
                        _blackBackgroundButtons[2].SetActive(true);
                        isBlackBackground = true;
                        isBomb = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() != 2 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    Debug.Log("Перчатка: отмена всех бафов");
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    EventOnClickBaf(1);
                    _blackBackgroundButtons[1].SetActive(true);
                }
                break;
            case 2:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetBombBafs() > 0)
                    {
                        isSpring = true;
                        BafsPresenter.Bomb();
                        _blackBackgroundButtons[2].SetActive(true);
                        isBlackBackground = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 3)
                {
                    BafsPresenter.CancelBomb();
                    _blackBackgroundButtons[2].SetActive(false);
                    //BafsPresenter.SetActiveBlackbackgroundBtn();
                    isBomb = false;
                }
                else if (isSpring && isBomb) 
                {
                    Debug.Log("Бомба: условие isSprig и isBomb");
                    BafsPresenter.CancelBomb();
                    _blackBackgroundButtons[2].SetActive(false);
                    isBomb = false;
                }
                else if (BafsPresenter.GetSelectBaf() == 2) 
                {
                    isSpring = true;
                    isBomb = true;
                    BafsPresenter.Bomb();
                    BafsPresenter.Spring();
                    if (PenguinsModel.instance.penguinInSpawn != null)
                    {
                        ProjectionView.instance.RedProjection();
                    }
                    _blackBackgroundButtons[1].SetActive(true);
                    _blackBackgroundButtons[2].SetActive(true);
                    isBlackBackground = true;
                    return;
                }
                else if (BafsPresenter.GetSelectBaf() != 3 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    _blackBackgroundButtons[2].SetActive(true);
                    EventOnClickBaf(2);
                }
                break;
            case 3:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetTornadoBafs() > 0)
                    {
                        // можно дописать условие if пингвинов > 1
                        BafsPresenter.Tornado();
                        _blackBackgroundButtons[3].SetActive(true);
                        isBlackBackground = true;
                        BafsPresenter.ReduceTornadoBafs(1);
                        DailyTasksPresenter.CheckUsedBaffForTask(4);
                        MusicAndSoundsManager._instance.PlaySound("Tornado", 4f);
                        BafsPresenter.SetActiveBlackbackgroundBtn();
                    }
                }
                else if (BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    _blackBackgroundButtons[3].SetActive(true);
                    EventOnClickBaf(3);
                }
                break;
            case 4:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetMagnetBafs() > 0)
                    {
                        BafsPresenter.Magnet();
                        _blackBackgroundButtons[4].SetActive(true);
                        isBlackBackground = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 5)
                {
                    BafsPresenter.CancelMagnet();
                    _blackBackgroundButtons[4].SetActive(false);
                }
                else if (BafsPresenter.GetSelectBaf() != 5 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    _blackBackgroundButtons[4].SetActive(true);
                    EventOnClickBaf(4);
                }
                break;
        }
    }

    private IEnumerator Trigger()
    {
        yield return new WaitForSeconds(0.2f);
        triggerBtn = false;
    }

    public void CancelAllBaff() 
    {
        BafsPresenter.CancelMulticolor();
        BafsPresenter.CancelSpring();
        BafsPresenter.CancelBomb();
        BafsPresenter.CancelMagnet();
        isMulticolor = false;
        isBomb = false;
        isSpring = false;
    }
}