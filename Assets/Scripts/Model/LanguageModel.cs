using UnityEngine;
public class LanguageModel : MonoBehaviour
{
    public static Sprite[] _langegesSprites;
    public static string currentLanguage;

    public static void LoadSpritesLanguage()
    {
        _langegesSprites = Resources.LoadAll<Sprite>("Sprites/CountryFlags");
    }
}

public class SaveLanguageModel
{
    public string currentLanguage;
}