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
                if (RatingsModel.instance.playersInformation.Count >= RatingsModel.instance.yourId)
                {
                    if (RatingsModel.instance.playersInformation[RatingsModel.instance.yourId - 1].id == RatingsModel.instance.yourId) RatingsModel.instance.playersInformation.RemoveAt(RatingsModel.instance.yourId - 1);
                }
                break;
            }
        }
    }
}