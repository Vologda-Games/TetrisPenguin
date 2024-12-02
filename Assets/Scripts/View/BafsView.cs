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
        switch (index)
        {
            case 0:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetMulticolorBafs() > 0)
                    {
                        BafsPresenter.Multicolor();
                        _blackBackgroundButtons[0].SetActive(true);
                        isBlackBackground = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 1)
                {
                    BafsPresenter.CancelMulticolor();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                }
                break;
            case 1:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetSpringBafs() > 0)
                    {
                        BafsPresenter.Spring();
                        _blackBackgroundButtons[1].SetActive(true);
                        isBlackBackground = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 2)
                {
                    BafsPresenter.CancelSpring();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                }
                break;
            case 2:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetBombBafs() > 0)
                    {
                        BafsPresenter.Bomb();
                        _blackBackgroundButtons[2].SetActive(true);
                        isBlackBackground = true;
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 3)
                {
                    BafsPresenter.CancelBomb();
                    BafsPresenter.SetActiveBlackbackgroundBtn();
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
                    BafsPresenter.SetActiveBlackbackgroundBtn();
                }
                break;
        }
    }

    private IEnumerator Trigger()
    {
        yield return new WaitForSeconds(0.2f);
        triggerBtn = false;
    }
}