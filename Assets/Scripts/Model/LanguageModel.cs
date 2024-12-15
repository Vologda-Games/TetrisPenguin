using UnityEngine;
public class LanguageModel : MonoBehaviour
{
    public static Sprite[] langegesSprites;
    public static string currentLanguage;

    public static void LoadSpritesLanguage()
    {
        langegesSprites = Resources.LoadAll<Sprite>("Sprites/CountryFlags");
    }
}

public class SaveLanguageModel
{
    public string currentLanguage;
}