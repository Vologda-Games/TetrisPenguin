using System.Collections;
using TMPro;
using UnityEngine;

public class BafsView : MonoBehaviour
{
    public static BafsView instance;
    [SerializeField] private TMP_Text[] _countTexts;
    public bool triggerBtn;

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
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 1)
                {
                    BafsPresenter.CancelMulticolor();
                }
                break;
            case 1:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetSpringBafs() > 0)
                    {
                        BafsPresenter.Spring();
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 2)
                {
                    BafsPresenter.CancelSpring();
                }
                break;
            case 2:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetBombBafs() > 0)
                    {
                        BafsPresenter.Bomb();
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 3)
                {
                    BafsPresenter.CancelBomb();
                }
                break;
            case 3:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetTornadoBafs() > 0)
                    {
                        // можно дописать условие if пингвинов > 1
                        BafsPresenter.Tornado();
                        BafsPresenter.ReduceTornadoBafs(1);
                        DailyTasksModel._instance.CheckUsedBaffForTask(4);
                        MusicAndSoundsManager._instance.PlaySound("Tornado", 4f);
                    }
                }
                break;
            case 4:
                if (BafsPresenter.GetSelectBaf() == 0)
                {
                    if (BafsPresenter.GetMagnetBafs() > 0)
                    {
                        BafsPresenter.Magnet();
                    }
                }
                else if (BafsPresenter.GetSelectBaf() == 5)
                {
                    BafsPresenter.CancelMagnet();
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