using UnityEngine;

public class GamePushPresenter : MonoBehaviour
{
    public static GamePushPresenter instance;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        DataPresenter.GetAllData();
        BafsView.instance.RenderCountBafs();
        NewDayEventModel._instance.LoadResourcesNewDay();
        SpawnReadyTaskOnMenuPresenter._instance.SpawnTodayTask();
        RatingsPresenter.instance.LoadYourInformationInRatings();
        RatingsPresenter.instance.LoadFalseUsers();
        PenguinsPresenter.instance.LoadSpritesPenguins();
        LanguageModel.LoadSpritesLanguage();
    }
}