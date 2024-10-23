using UnityEngine;
using UnityEngine.UI;

public class ScreenModel : MonoBehaviour
{
    [Header("Scripts")]
    public static ScreenModel instance;

    [Header("Float")]
    public float posTouch;

    [Header("String")]
    [SerializeField] public static string _typeControl;

    [Header("Sprites")]
    [SerializeField] public Sprite _trueSpriteButton;
    [SerializeField] public Sprite _falseSpriteButton;

    [Header("UI")]
    [SerializeField] public Image _buttonTypeControl;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("TypeControl")) SetControl("Precise");
        posTouch = 0;
        instance = this;
    }

    public void SetControl(string _typeControl)
    {
        PlayerPrefs.SetString("TypeControl", _typeControl);
    }

    public string GetControl()
    {
        _typeControl = PlayerPrefs.GetString("TypeControl");
        return _typeControl;
    }
}