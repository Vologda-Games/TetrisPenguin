using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenModel : MonoBehaviour
{
    [Header("Scripts & Methods")]
    public static ScreenModel instance;


    [Header("Float")]
    public float posTouch;


    [Header("String")]
    [SerializeField] public static string _typeControl;
    [SerializeField] public static List<string> _typesControl = new List<string>() {"Precise", "Flexible"};


    [Header("Sprites")]
    [SerializeField] public Sprite _trueSpriteButton;
    [SerializeField] public Sprite _falseSpriteButton;


    [Header("UI")]
    [SerializeField] public TextMeshProUGUI _textTypeControl;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("TypeControl")) SetControl(_typesControl[0]);
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

    public static string GetNameTypeControl()
    {
        string _nameTypeControl = "";
        switch(instance.GetControl())
        {
            case "Precise":
                _nameTypeControl = "точное";
                break;
            case "Flexible":
                _nameTypeControl = "гибкое";
                break;
        }
        return _nameTypeControl;
    }
}