using UnityEngine;

public class ScreenModel : MonoBehaviour
{
    public static ScreenModel instance;
    public float posTouch;

    private void Awake()
    {
        posTouch = 0;
        instance = this;
    }
}