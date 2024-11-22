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
<<<<<<< HEAD
       //PlayerPrefs.DeleteAll();
=======
        //PlayerPrefs.DeleteAll();
>>>>>>> upstream/main
    }

    public void LoadResourcesNewDay()
    {
<<<<<<< HEAD
        for(int i = 0; i < DailyTasksModel._instance._allTasks.Count; i++)
        {
            if(!DailyTasksModel._instance._allReadyNumbersTasks.Contains(i)) DailyTasksModel._instance._allReadyNumbersTasks.Add(i);
        }

        // DailyTasksModel.spritesForRewardBaff = Resources.LoadAll<Sprite>("Sprites/Reward/Bafs");
        // DailyTasksModel.spriteForRewardSoftCurrency = Resources.Load<Sprite>("Sprites/Reward/Currency/SoftCurrency");
        // SoundsModel.music = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Music");
        // SoundsModel.sounds = Resources.LoadAll<GameObject>("Prefabs/SoundsAndMusic/Sounds");

        DateTime _lastEnterToGame = DailyTasksModel._instance.LastEnterToGame;
        if(GamePush.GP_Server.Time().Date > _lastEnterToGame || _lastEnterToGame == null)
        {
            ResetFlagsForNewDay();
            GameInterface.instance.EventOpenDailyRewards();
            DailyRewardsPresenter.instance.NewDay();
            _tasksOnToday = new List<DailyTasksInfoValue>();
            while(_tasksOnToday.Count < DailyTasksModel._instance._maxQuantityTaskOfDay)
=======
        for (int i = 0; i < DailyTasksModel._instance._allTasks.Count; i++)
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
>>>>>>> upstream/main
            {
                int _randomNumberTasks = DailyTasksModel._instance.RandomNumberTask();
                if (!tasksOnToday.Contains(DailyTasksModel._instance._allTasks[_randomNumberTasks])) tasksOnToday.Add(DailyTasksModel._instance._allTasks[_randomNumberTasks]);
                tasksOnToday[tasksOnToday.Count - 1]._currentQuantity = 0;
            }
            DailyTasksModel._instance.LastEnterToGame = GamePush.GP_Server.Time().Date;
            DataPresenter.SaveDailyTasksModel();
            DataPresenter.SaveNewDayEventModel();
        }
    }

    public void ResetFlagsForNewDay()
    {
        PlayerPrefs.SetInt("WheelSpunToday", 0);
        PlayerPrefs.SetInt("isUpScale", 0);
    }
}
public class SaveNewDayEventModel
{
    public List<DailyTasksInfoValue> tasksOnToday;
}