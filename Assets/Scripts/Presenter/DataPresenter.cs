using UnityEngine;
using Newtonsoft.Json;

public class DataPresenter
{
    public static void SaveAllData()
    {
        SavePlayerModel();
        SaveBafsModel();
        SavePenguinsModel();

    }

    public static void GetAllData()
    {
        GetPlayerModel();
        GetBafsModel();
        GetPenguinsModel();
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
        };
        string json = JsonConvert.SerializeObject(penguinsModel);
        SaveData(Models.PENGUINS_MODEL, json);
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
    }

    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        Debug.LogWarning("DELETE ALL DATA");
        Time.timeScale = 0f;
    }
}