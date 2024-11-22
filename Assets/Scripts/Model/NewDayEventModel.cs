using System;
using System.Collections.Generic;
using UnityEngine;

public class NewDayEventModel : MonoBehaviour
{
    [Header("Massive")]
    [HideInInspector] public List<DailyTasksInfoValue> tasksOnToday;

    [Header("Scripts")]
    public static NewDayEventModel _instance;

    private void Awake()
    {
        _instance = this;
        //PlayerPrefs.DeleteAll();
    }

    public void LoadResourcesNewDay()
    {
        for (int i = 0; i < DailyTasksModel.allTasks.Count; i++)
        {
            if (!DailyTasksModel._instance._allReadyNumbersTasks.Contains(i)) DailyTasksModel._instance._allReadyNumbersTasks.Add(i);
        }

        DailyTasksModel.spritesForRewardBaff = Resources.LoadAll<Sprite>("Sprites/Reward/Bafs");
        DailyTasksModel.spriteForRewardSoftCurrency = Resources.Load<Sprite>("Sprites/Reward/Currency/SoftCurrency");
        SoundsModel.music = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Music");
        SoundsModel.sounds = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Sounds");

        DateTime _lastEnterToGame = DailyTasksModel._instance.LastEnterToGame;
        if (GamePush.GP_Server.Time().Date > _lastEnterToGame || _lastEnterToGame == null)
        {
            tasksOnToday = new List<DailyTasksInfoValue>();
            while (tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
            {
                int _randomNumberTasks = DailyTasksModel._instance.RandomNumberTask();
                if (!tasksOnToday.Contains(DailyTasksModel.allTasks[_randomNumberTasks])) tasksOnToday.Add(DailyTasksModel.allTasks[_randomNumberTasks]);
                tasksOnToday[tasksOnToday.Count - 1]._currentQuantity = 0;
            }
            DailyTasksModel._instance.LastEnterToGame = GamePush.GP_Server.Time().Date;
            DataPresenter.SaveDailyTasksModel();
            DataPresenter.SaveNewDayEventModel();
        }
    }
}
public class SaveNewDayEventModel
{
    public List<DailyTasksInfoValue> tasksOnToday;
}