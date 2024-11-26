using System;
using UnityEngine;

public class LanguagePresenter : MonoBehaviour
{
    public static event Action changeLanguageEvent;

    public static void ChangeLanguge()
    {
        changeLanguageEvent?.Invoke();
    }

    public static void InitLanguage(string language)
    {
        switch (language)
        {
            case Languages.ENGLISH:
                // Английский
                LanguageModel.currentLanguage = Languages.ENGLISH;
                break;
            case Languages.RUSSIAN:
                // Русский
                LanguageModel.currentLanguage = Languages.RUSSIAN;
                break;
            case Languages.GERMAN:
                // Немецкий
                LanguageModel.currentLanguage = Languages.GERMAN;
                break;
            case Languages.ITALIAN:
                // Итальянский
                LanguageModel.currentLanguage = Languages.ITALIAN;
                break;
            case Languages.FRENCH:
                // Французский
                LanguageModel.currentLanguage = Languages.FRENCH;
                break;
            case Languages.SWEDISH:
                // Шведский
                LanguageModel.currentLanguage = Languages.SWEDISH;
                break;
            case Languages.PORTUGUESE:
                // Португальский
                LanguageModel.currentLanguage = Languages.PORTUGUESE;
                break;
            case Languages.INDONESIAN:
                // Индонезийский
                LanguageModel.currentLanguage = Languages.INDONESIAN;
                break;
            case Languages.TURKISH:
                // Турецкий
                LanguageModel.currentLanguage = Languages.TURKISH;
                break;
            //case Languages.NORWEGIAN:
                // Норвежский
            //    LanguageModel.currentLanguage = Languages.NORWEGIAN;
            //    break;
            //case Languages.HINDI:
            //    // Хинди
            //    LanguageModel.currentLanguage = Languages.HINDI;
            //    break;
            case Languages.JAPANESE:
                // Японский
                LanguageModel.currentLanguage = Languages.JAPANESE;
                break;
            case Languages.DUTCH:
                // Нидерландский
                LanguageModel.currentLanguage = Languages.DUTCH;
                break;
            case Languages.POLISH:
                //Польский
                LanguageModel.currentLanguage = Languages.POLISH;
                break;
            //case Languages.LATVIAN:
            //    // Латышский
            //    LanguageModel.currentLanguage = Languages.LATVIAN;
            //    break;
            case Languages.ARABIAN:
                // Арабский
                LanguageModel.currentLanguage = Languages.ARABIAN;
                break;
            case Languages.CHINEESE:
                // Китайский
                LanguageModel.currentLanguage = Languages.CHINEESE;
                break;
            case Languages.KOREAN:
                // Китайский
                LanguageModel.currentLanguage = Languages.KOREAN;
                break;
            case Languages.SPANISH:
                // Китайский
                LanguageModel.currentLanguage = Languages.SPANISH;
                break;
            default:
                LanguageModel.currentLanguage = Languages.RUSSIAN;
                break;
        }
        ChangeLanguge();
        DataPresenter.SaveLanguageModel();
    }
}