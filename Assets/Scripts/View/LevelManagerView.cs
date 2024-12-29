using System;
using System.Collections;
using UnityEngine;

public class LeveManagerView : MonoBehaviour
{
    [SerializeField] private WindowWithInformationLevelView _windowWithLevelEXPInformation;
    [SerializeField] private Transform _parentWondowLevel;
    [HideInInspector] public WindowWithInformationLevelView currentWindowLevel;
    [HideInInspector] public bool openedWindow;
    [HideInInspector] public bool statusOfIncrease;
    [HideInInspector] public static LeveManagerView instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CheckLevelForOpenButton();
        statusOfIncrease = false;
    }

    public void CheckLevelForOpenButton()
    {
        for (int i = 0; i < LevelManagerModel.instance.listOpenPerLevel.Count; i++)
        {
            LevelManagerModel.instance.listOpenPerLevel[i].buttonForOpen.interactable = false;
            LevelManagerModel.instance.listOpenPerLevel[i].buttonBlock.SetActive(true);
            if (LevelManagerModel.instance.listOpenPerLevel[i].textBaff != null) LevelManagerModel.instance.listOpenPerLevel[i].textBaff.SetActive(false);
            if (Levels.CurrentLevel >= LevelManagerModel.instance.listOpenPerLevel[i].level)
            {
                LevelManagerModel.instance.listOpenPerLevel[i].buttonForOpen.interactable = true;
                LevelManagerModel.instance.listOpenPerLevel[i].buttonBlock.SetActive(false);
                if (LevelManagerModel.instance.listOpenPerLevel[i].textBaff != null) LevelManagerModel.instance.listOpenPerLevel[i].textBaff.SetActive(true);
            }
        }
    }

    public void SpawnWindowWithLevelEXPInformation()
    {
        if (currentWindowLevel == null)
        {
            currentWindowLevel = Instantiate(_windowWithLevelEXPInformation, _parentWondowLevel);
            currentWindowLevel.transform.localScale = Vector3.zero;
            currentWindowLevel.OutputInformationWithLevelEXP();
        }
        statusOfIncrease = !statusOfIncrease;
        if (!openedWindow) StartCoroutine(OpenWindow(currentWindowLevel.transform, new Vector3(1.3f, 1.3f, 1.3f)));
    }

    public IEnumerator OpenWindow(Transform window, Vector3 maxScale)
    {
        openedWindow = true;
        bool maxScaleReady = false;
        while (true)
        {
            if (statusOfIncrease)
            {
                if (window.localScale.x < maxScale.x && !maxScaleReady)
                {
                    window.localScale += maxScale / 10;
                }
                else if (window.localScale.x >= maxScale.x)
                {
                    if (!maxScaleReady) maxScaleReady = true;
                }
                if (maxScaleReady)
                {
                    if (window.localScale.x > 1)
                    {
                        window.localScale -= Vector3.one / 10;
                    }
                    else
                    {
                        window.localScale = Vector3.one;
                        break;
                    }
                }
            }
            else
            {
                if (maxScaleReady) maxScaleReady = false;
                if (window.localScale.x > 0)
                {
                    window.localScale -= maxScale / 10;
                }
                else
                {
                    window.localScale = Vector3.zero;
                    Destroy(window.gameObject);
                    break;
                }
            }
            yield return new WaitForFixedUpdate();
        }
        openedWindow = false;
    }
}