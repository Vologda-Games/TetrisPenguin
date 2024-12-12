using System.Collections;
using TMPro;
using UnityEngine;

public class NewLevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textLevel;
    private int _timerCansel = 0;
    private bool startTimer = false;

    private void Start()
    {
        if (!startTimer) StartCoroutine(TimerCansel());
        RenderLevel();
    }

    private void RenderLevel()
    {
        _textLevel.text = $"{Levels.CurrentLevel}";
    }

    public void CloseWindowNewLevel()
    {
        if (!startTimer) GameInterface.instance.CloseFirstLayout();
    }

    private IEnumerator TimerCansel()
    {
        startTimer = true;
        _timerCansel = 0;
        while (_timerCansel < 2)
        {
            _timerCansel++;
            yield return new WaitForSeconds(1f);
        }
        startTimer = false;
    }
}