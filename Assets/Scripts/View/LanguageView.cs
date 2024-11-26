using UnityEngine;

public class LanguageView : MonoBehaviour
{
    public void Changelanguage()
    {
        for (int i = 0; i < Languages.languages.Count; i++)
        {
            if (LanguageModel.currentLanguage == Languages.languages[i])
            {
                if (i == Languages.languages.Count - 1) LanguagePresenter.InitLanguage(Languages.languages[0]);
                else LanguagePresenter.InitLanguage(Languages.languages[i + 1]);
                break;
            }
        }
    }
}