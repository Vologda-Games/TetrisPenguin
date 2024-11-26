using UnityEngine;
using Newtonsoft.Json;
using GamePush;

public class DataPresenter
{
    public static void SaveAllData()
    {
        SavePlayerModel();
        SaveBafsModel();
        SavePenguinsModel();
        SaveNewDayEventModel();
        SaveDailyTasksModel();
        SaveScreenModel();
        SaveSoundsModel();
        SaveRatingsModel();
        SaveLanguageModel();
    }

    public static void GetAllData()
    {
        GetPlayerModel();
        GetBafsModel();
        GetPenguinsModel();
        GetNewDayEventModel();
        GetDailyTasksModel();
        GetScreenModel();
        GetSoundsModel();
        GetRatingsModel();
        GetLanguageModel();
    }

    private static void SaveData(string nameModel, string json)
    {
        // if (PlayerModel.instance.platform == Platform.None)
        // {
        PlayerPrefs.SetString(nameModel, json);
        // }
        // else
        // {
        //     GP_Player.Set(nameModel, json);
        // }
    }

    public static string GetData(string nameModel)
    {
        string json;
        // if (PlayerModel.instance.platform == Platform.None)
        // {
        json = PlayerPrefs.GetString(nameModel);
        // }
        // else
        // {
        //     json = GP_Player.GetString(nameModel);
        // }
        Debug.Log("Пришел JSON-" + nameModel + ": " + json);
        return json;
    }

    public static void SavePlayerModel()
    {
        SavePlayerModel playerModel = new SavePlayerModel()
        {
            level = PlayerModel.instance.level,
            coins = PlayerModel.instance.coins,
            experience = PlayerModel.instance.experience,
        };
        string json = JsonConvert.SerializeObject(playerModel);
        SaveData(Models.PLAYER_MODEL, json);
    }

    public static void SaveBafsModel()
    {
        SaveBafsModel bafsModel = new SaveBafsModel()
        {
            multicolorBafs = BafsModel.instance.multicolorBafs,
            springBafs = BafsModel.instance.springBafs,
            bombBafs = BafsModel.instance.bombBafs,
            tornadoBafs = BafsModel.instance.tornadoBafs,
            magnetBafs = BafsModel.instance.magnetBafs,
        };
        string json = JsonConvert.SerializeObject(bafsModel);
        SaveData(Models.BAFS_MODEL, json);
    }

    public static void SavePenguinsModel()
    {
        SavePenguinsModel penguinsModel = new SavePenguinsModel()
        {
            penguinObjects = PenguinsModel.instance.GetPenguins(),
            penguinsCardsInformations = PenguinsModel.instance.penguinsCardsInformations
        };
        string json = JsonConvert.SerializeObject(penguinsModel);
        SaveData(Models.PENGUINS_MODEL, json);
    }

    public static void SaveDailyTasksModel()
    {
        SaveDailyTasksModel dailyTasksModel = new SaveDailyTasksModel()
        {
            LastEnterToGame = DailyTasksModel._instance.LastEnterToGame,
        };
        string json = JsonConvert.SerializeObject(dailyTasksModel);
        SaveData(Models.DAILY_TASKS_MODEL, json);
    }

    public static void SaveNewDayEventModel()
    {
        SaveNewDayEventModel newDayEventModel = new SaveNewDayEventModel()
        {
            tasksOnToday = NewDayEventModel._instance.tasksOnToday,
        };
        string json = JsonConvert.SerializeObject(newDayEventModel);
        SaveData(Models.NEW_DAY_EVENT_MODEL, json);
    }

    public static void SaveScreenModel()
    {
        SaveScreenModel screenModel = new SaveScreenModel()
        {
            TypeControl = ScreenModel.instance.TypeControl,
        };
        string json = JsonConvert.SerializeObject(screenModel);
        SaveData(Models.SCREEN_MODEL, json);
    }

    public static void SaveSoundsModel()
    {
        SaveSoundsModel soundsModel = new SaveSoundsModel()
        {
            _playMusic = SoundsModel.instance._playMusic,
            _playSouds = SoundsModel.instance._playSouds,
        };
        string json = JsonConvert.SerializeObject(soundsModel);
        SaveData(Models.SOUNDS_MODEL, json);
    }

    public static void SaveRatingsModel()
    {
        SaveRatingsModel ratingsModel = new SaveRatingsModel()
        {
            playersInformation = RatingsModel.instance.playersInformation
        };
        string json = JsonConvert.SerializeObject(ratingsModel);
        SaveData(Models.RATINGS_MODEL, json);
    }

    public static void SaveLanguageModel()
    {
        SaveLanguageModel languageModel = new SaveLanguageModel()
        {
            currentLanguage = LanguageModel.currentLanguage
        };
        string json = JsonConvert.SerializeObject(languageModel);
        SaveData(Models.LANGUAGE_MODEL, json);
    }

    public static void GetPlayerModel()
    {
        string json = GetData(Models.PLAYER_MODEL);
        if (json == "" || json == null)
        {
            return;
        }
        SavePlayerModel saveResourcesModel = JsonConvert.DeserializeObject<SavePlayerModel>(json);
        PlayerModel.instance.level = saveResourcesModel.level;
        PlayerModel.instance.coins = saveResourcesModel.coins;
        PlayerModel.instance.experience = saveResourcesModel.experience;
    }

    public static void GetBafsModel()
    {
        string json = GetData(Models.BAFS_MODEL);
        if (json == "" || json == null)
        {
            return;
        }
        SaveBafsModel saveBafsModel = JsonConvert.DeserializeObject<SaveBafsModel>(json);
        BafsModel.instance.multicolorBafs = saveBafsModel.multicolorBafs;
        BafsModel.instance.springBafs = saveBafsModel.springBafs;
        BafsModel.instance.bombBafs = saveBafsModel.bombBafs;
        BafsModel.instance.tornadoBafs = saveBafsModel.tornadoBafs;
        BafsModel.instance.magnetBafs = saveBafsModel.magnetBafs;
    }

    public static void GetPenguinsModel()
    {
        string json = GetData(Models.PENGUINS_MODEL);
        if (json == "" || json == null)
        {
            return;
        }
        SavePenguinsModel savePenguinsModel = JsonConvert.DeserializeObject<SavePenguinsModel>(json);
        PenguinsModel.instance.penguinObjectsForStart = savePenguinsModel.penguinObjects;
        PenguinsModel.instance.penguinsCardsInformations = savePenguinsModel.penguinsCardsInformations;
    }

    public static void GetDailyTasksModel()
    {
        string json = GetData(Models.DAILY_TASKS_MODEL);
        if (json == "" || json == null)
        {
            return;
        }
        SaveDailyTasksModel saveResourcesModel = JsonConvert.DeserializeObject<SaveDailyTasksModel>(json);
        DailyTasksModel._instance.LastEnterToGame = saveResourcesModel.LastEnterToGame;
    }

    public static void GetNewDayEventModel()
    {
        string json = GetData(Models.NEW_DAY_EVENT_MODEL);
        if (json == "" || json == null)
        {
            return;
        }
        SaveNewDayEventModel saveResourcesModel = JsonConvert.DeserializeObject<SaveNewDayEventModel>(json);
        NewDayEventModel._instance.tasksOnToday = saveResourcesModel.tasksOnToday;
    }

    public static void GetScreenModel()
    {
        string json = GetData(Models.SCREEN_MODEL);
        if (json == "" || json == null)
        {
            return;
        }
        SaveScreenModel saveResourcesModel = JsonConvert.DeserializeObject<SaveScreenModel>(json);
        ScreenModel.instance.TypeControl = saveResourcesModel.TypeControl;
    }

    public static void GetSoundsModel()
    {
        string json = GetData(Models.SOUNDS_MODEL);
        if (json == "" || json == null)
        {
            SoundsModel.instance._playMusic = true;
            SoundsModel.instance._playSouds = true;
            return;
        }
        SaveSoundsModel saveResourcesModel = JsonConvert.DeserializeObject<SaveSoundsModel>(json);
        SoundsModel.instance._playMusic = saveResourcesModel._playMusic;
        SoundsModel.instance._playSouds = saveResourcesModel._playSouds;
    }

    public static void GetRatingsModel()
    {
        string json = GetData(Models.RATINGS_MODEL);
        if (json == "" || json == null)
        {
            RatingsPresenter.instance.LoadFalseUsers();
            return;
        }
        SaveRatingsModel saveResourcesModel = JsonConvert.DeserializeObject<SaveRatingsModel>(json);
        RatingsModel.instance.playersInformation = saveResourcesModel.playersInformation;
    }

    public static void GetLanguageModel()
    {
        string json = GetData(Models.LANGUAGE_MODEL);
        if (json == "" || json == null)
        {
            LanguagePresenter.InitLanguage(GP_Language.Current().ToString());
            Debug.Log(GP_Language.Current());
            return;
        }
        SaveLanguageModel saveLanguageModel = JsonConvert.DeserializeObject<SaveLanguageModel>(json);
        LanguageModel.currentLanguage = saveLanguageModel.currentLanguage;
    }

    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        Debug.LogWarning("DELETE ALL DATA");
        Time.timeScale = 0f;
    }

    public static void DeleteDataPenguins()
    {
        SaveData(Models.PENGUINS_MODEL, "");
        Debug.LogWarning("DELETE ALL DATA");
        Time.timeScale = 0f;
    }
}