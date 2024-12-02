using System.Collections;
using UnityEngine;

public class LeveManagerView : MonoBehaviour
{
    [SerializeField] private WindowWithInformationLevelView _windowWithLevelEXPInformation;
    [SerializeField] private Transform _parentWondowLevel;
    [HideInInspector] public WindowWithInformationLevelView _currentWindowLevel;
    [HideInInspector] public bool _openedWindow;
    [HideInInspector] public bool _statusOfIncrease;
    [HideInInspector] public static LeveManagerView instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CheckLevelForOpenButton();
        _statusOfIncrease = false;
    }

    public void CheckLevelForOpenButton()
    {
        for (int i = 0; i < LevelManagerModel._instance._listOpenPerLevel.Count; i++)
        {
            LevelManagerModel._instance._listOpenPerLevel[i]._buttonForOpen.interactable = false;
            if (Levels.CurrentLevel >= LevelManagerModel._instance._listOpenPerLevel[i]._level) LevelManagerModel._instance._listOpenPerLevel[i]._buttonForOpen.interactable = true;
        }
    }

    public void SpawnWindowWithLevelEXPInformation()
    {
        if (_currentWindowLevel == null)
        {
            _currentWindowLevel = Instantiate(_windowWithLevelEXPInformation, _parentWondowLevel);
            _currentWindowLevel.transform.localScale = Vector3.zero;
            _currentWindowLevel.OutputInformationWithLevelEXP();
        }
        _statusOfIncrease = !_statusOfIncrease;
        if (!_openedWindow) StartCoroutine(OpenWindow(_currentWindowLevel.transform, new Vector3(1.3f, 1.3f, 1.3f)));
    }

    public IEnumerator OpenWindow(Transform window, Vector3 maxScale)
    {
        _openedWindow = true;
        bool maxScaleReady = false;
        while (true)
        {
            if (_statusOfIncrease)
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
        _openedWindow = false;
    }
}