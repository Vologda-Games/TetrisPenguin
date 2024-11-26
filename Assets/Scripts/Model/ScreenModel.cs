using System.Collections.Generic;
using GamePush;
using TMPro;
using UnityEngine;

public class ScreenModel : MonoBehaviour
{
    [Header("Scripts & Methods")]
    public static ScreenModel instance;


    [Header("Float")]
    public float posTouch;


    [Header("String")]
    [SerializeField] public static List<string> _typesControl = new List<string>() { "Precise", "Flexible" };
    [HideInInspector] public string TypeControl;


    [Header("Sprites")]
    [SerializeField] public Sprite _trueSpriteButton;
    [SerializeField] public Sprite _falseSpriteButton;

    private void Awake()
    {
        if (TypeControl == "" || TypeControl != null) TypeControl = _typesControl[0];
        posTouch = 0;
        instance = this;
    }

    public void SetControl(string _typeControl)
    {
        TypeControl = _typeControl;
        DataPresenter.SaveScreenModel();
    }

    public static string GetNameTypeControl()
    {
        string _nameTypeControl = "";
        switch (instance.TypeControl)
        {
            case "Precise":
                _nameTypeControl = LibraryWords.preciseControl.GetText();
                break;
            case "Flexible":
                _nameTypeControl = LibraryWords.flexibleManagement.GetText();
                break;
        }
        return _nameTypeControl;
    }
}

public class SaveScreenModel
{
    public string TypeControl;
}