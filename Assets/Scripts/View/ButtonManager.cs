using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void ClickButton()
    {
        MusicAndSoundsManager._instance.PlaySoundClickOnButton();
    }
}