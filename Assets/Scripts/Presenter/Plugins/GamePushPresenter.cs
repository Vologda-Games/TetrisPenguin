using UnityEngine;

public class GamePushPresenter : MonoBehaviour
{
    public static GamePushPresenter instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        AdsGPPresenter.instance.ShowFullscreen();
        DataPresenter.GetAllData();
        BafsView.instance.RenderCountBafs();
        NewDayEventModel.instance.LoadResourcesNewDay();
        SpawnReadyTaskOnMenuPresenter.instance.SpawnTodayTask();
        RatingsPresenter.instance.LoadYourInformationInRatings();
        RatingsPresenter.instance.LoadFalseUsers();
        PenguinsPresenter.instance.LoadSpritesPenguins();
        PenguinsPresenter.instance.SpawnPenguinOnStart();
        LanguageModel.LoadSpritesLanguage();
    }
}