public class Localization
{
    public string textRU; //Русский
    public string textEN; //Английский
    public string textFR; //Французский
    public string textIT; //Итальянский
    public string textDE; //Немецкий
    public string textES; //Испанский
    public string textZH; //Китайский
    public string textPT; //Португальский
    public string textKO; //Корейский
    public string textJA; //Японский
    public string textTR; //Турекций
    public string textAR; //Арабский
    public string textHI; //Хинди
    public string textID; //Индонезийский
    public string textPO; //Польский
    public string textSW; //Шведский

    public string GetText()
    {
        if (LanguageModel.currentLanguage == Languages.RUSSIAN) return textRU;
        else if (LanguageModel.currentLanguage == Languages.ENGLISH) return textEN;
        else if (LanguageModel.currentLanguage == Languages.TURKISH) return textTR;
        else if (LanguageModel.currentLanguage == Languages.FRENCH) return textFR;
        else if (LanguageModel.currentLanguage == Languages.ITALIAN) return textIT;
        else if (LanguageModel.currentLanguage == Languages.GERMAN) return textDE;
        else if (LanguageModel.currentLanguage == Languages.SPANISH) return textES;
        else if (LanguageModel.currentLanguage == Languages.CHINEESE) return textZH;
        else if (LanguageModel.currentLanguage == Languages.PORTUGUESE) return textPT;
        else if (LanguageModel.currentLanguage == Languages.KOREAN) return textKO;
        else if (LanguageModel.currentLanguage == Languages.JAPANESE) return textJA;
        else if (LanguageModel.currentLanguage == Languages.ARABIAN) return textAR;
        else if (LanguageModel.currentLanguage == Languages.INDONESIAN) return textID;
        else if (LanguageModel.currentLanguage == Languages.POLISH) return textPO;
        else if (LanguageModel.currentLanguage == Languages.SWEDISH) return textSW;
        return "null";
    }

    public Localization(
        string textRU,
        string textEN,
        string textFR,
        string textIT,
        string textDE,
        string textES,
        string textZH,
        string textPT,
        string textKO,
        string textJA,
        string textTR,
        string textAR,
        string textHI,
        string textID,
        string textPO,
        string textSW
    )
    {
        this.textRU = textRU;
        this.textEN = textEN;
        this.textFR = textFR;
        this.textIT = textIT;
        this.textDE = textDE;
        this.textES = textES;
        this.textZH = textZH;
        this.textPT = textPT;
        this.textKO = textKO;
        this.textJA = textJA;
        this.textTR = textTR;
        this.textAR = textAR;
        this.textHI = textHI;
        this.textID = textID;
        this.textPO = textPO;
        this.textSW = textSW;
    }
}
