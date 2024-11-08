using UnityEngine;

public class LeveManagerView : MonoBehaviour
{
    private void Start()
    {
        CheckLevelForOpenButton();
    }

    public void CheckLevelForOpenButton()
    {
        for (int i = 0; i < LevelManagerModel._instance._listOpenPerLevel.Count; i++)
        {
            LevelManagerModel._instance._listOpenPerLevel[i]._buttonForOpen.interactable = false;
            if (Levels.CurrentLevel >= LevelManagerModel._instance._listOpenPerLevel[i]._level) LevelManagerModel._instance._listOpenPerLevel[i]._buttonForOpen.interactable = true;
        }
    }
}