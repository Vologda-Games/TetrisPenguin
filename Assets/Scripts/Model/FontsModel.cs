using TMPro;
using UnityEngine;

public class FontsModel : MonoBehaviour
{
    public static FontsModel instance;

    [Header("Fonts")]
    public TMP_FontAsset fontRU; //Русский
    public TMP_FontAsset fontEN; //Английский
    public TMP_FontAsset fontFR; //Французский
    public TMP_FontAsset fontIT; //Итальянский
    public TMP_FontAsset fontDE; //Немецкий
    public TMP_FontAsset fontES; //Испанский
    public TMP_FontAsset fontZH; //Китайский
    public TMP_FontAsset fontPT; //Португальский
    public TMP_FontAsset fontKO; //Корейский
    public TMP_FontAsset fontJA; //Японский
    public TMP_FontAsset fontTR; //Турекций
    public TMP_FontAsset fontAR; //Арабский
    public TMP_FontAsset fontHI; //Хинди
    public TMP_FontAsset fontID; //Индонезийский
    public TMP_FontAsset fontPO; //Польский
    public TMP_FontAsset fontSW; //Шведский

    private void Awake()
    {
        instance = this;
    }

    public static TMP_FontAsset GetFont()
    {
        if (LanguageModel.currentLanguage == Languages.RUSSIAN) return instance.fontRU;
        else if (LanguageModel.currentLanguage == Languages.ENGLISH) return instance.fontEN;
        else if (LanguageModel.currentLanguage == Languages.TURKISH) return instance.fontTR;
        else if (LanguageModel.currentLanguage == Languages.FRENCH) return instance.fontFR;
        else if (LanguageModel.currentLanguage == Languages.ITALIAN) return instance.fontIT;
        else if (LanguageModel.currentLanguage == Languages.GERMAN) return instance.fontDE;
        else if (LanguageModel.currentLanguage == Languages.SPANISH) return instance.fontES;
        else if (LanguageModel.currentLanguage == Languages.CHINEESE) return instance.fontZH;
        else if (LanguageModel.currentLanguage == Languages.PORTUGUESE) return instance.fontPT;
        else if (LanguageModel.currentLanguage == Languages.KOREAN) return instance.fontKO;
        else if (LanguageModel.currentLanguage == Languages.JAPANESE) return instance.fontJA;
        else if (LanguageModel.currentLanguage == Languages.ARABIAN) return instance.fontAR;
        else if (LanguageModel.currentLanguage == Languages.INDONESIAN) return instance.fontID;
        else if (LanguageModel.currentLanguage == Languages.POLISH) return instance.fontPO;
        else if (LanguageModel.currentLanguage == Languages.SWEDISH) return instance.fontSW;
        return null;
    }
}