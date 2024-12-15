using System.Collections;
using TMPro;
using UnityEngine;

public class BafsView : MonoBehaviour
{
    public static BafsView instance;
    [SerializeField] private TMP_Text[] _countTexts;
    public bool triggerBtn;
    public GameObject[] blackBackgroundButtons;
    public bool isBlackBackground;
    public bool isMulticolor;
    public bool isSpring;
    public bool isBomb;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LanguagePresenter.changeLanguageEvent += RenderCountBafs;
    }

    public void RenderCountBafs()
    {
        _countTexts[0].text = BafsPresenter.GetMulticolorBafs().ToString();
        _countTexts[0].font = FontsModel.GetFont();
        _countTexts[1].text = BafsPresenter.GetSpringBafs().ToString();
        _countTexts[1].font = FontsModel.GetFont();
        _countTexts[2].text = BafsPresenter.GetBombBafs().ToString();
        _countTexts[2].font = FontsModel.GetFont();
        _countTexts[3].text = BafsPresenter.GetTornadoBafs().ToString();
        _countTexts[3].font = FontsModel.GetFont();
        _countTexts[4].text = BafsPresenter.GetMagnetBafs().ToString();
        _countTexts[4].font = FontsModel.GetFont();
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
                    if (BafsPresenter.GetMulticolorBafs() > 0)
                    {
                        if (PenguinsModel.instance.penguinInSpawn != null) BafsPresenter.Multicolor();
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 1) BafsPresenter.CancelMulticolor();
                else if (BafsPresenter.GetSelectBaf() != 1 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    blackBackgroundButtons[0].SetActive(true);
                    EventOnClickBaf(0);
                }
                break;
            case 1:
                if (BafsPresenter.GetSelectBaf() == 0 )
                {
                    if (BafsPresenter.GetSpringBafs() > 0) BafsPresenter.Spring();
                }
                else if (BafsPresenter.GetSelectBaf() == 2) BafsPresenter.CancelSpring();
                else if (BafsPresenter.GetSelectBaf() != 2 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    EventOnClickBaf(1);
                    blackBackgroundButtons[1].SetActive(true);
                }
                break;
            case 2:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetBombBafs() > 0) BafsPresenter.Bomb();
                }
                else if (BafsPresenter.GetSelectBaf() == 3) BafsPresenter.CancelBomb(); 
                else if (BafsPresenter.GetSelectBaf() != 3 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    blackBackgroundButtons[2].SetActive(true);
                    EventOnClickBaf(2);
                }
                break;
            case 3:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetTornadoBafs() > 0) BafsPresenter.Tornado();
                }
                else if (BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    blackBackgroundButtons[3].SetActive(true);
                    EventOnClickBaf(3);
                }
                break;
            case 4:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetMagnetBafs() > 0) BafsPresenter.Magnet();
                }
                else if (BafsPresenter.GetSelectBaf() == 5) BafsPresenter.CancelMagnet();
                else if (BafsPresenter.GetSelectBaf() != 5 && BafsPresenter.GetSelectBaf() != 0) 
                {
                    CancelAllBaff();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                    blackBackgroundButtons[4].SetActive(true);
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