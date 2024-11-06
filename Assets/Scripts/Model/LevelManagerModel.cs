using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerModel : MonoBehaviour
{
    public static List<OpenPerLevel> _listOpenPerLevel = new List<OpenPerLevel>()
    {
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.Baff1, 1),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.Baff2, 2),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.Baff3, 3),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.Baff4, 4),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.Baff5, 5),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.Shop, 6),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.DailyTasks, 7),
        new OpenPerLevel(OpenPerLevel.ObjectForOpen.LuckWheel, 8)
    };

    private void Start()
    {
        for(int i = 0; i < _listOpenPerLevel.Count; i++)
        {
            if(PlayerPrefs.GetInt($"LevelForOpen{_listOpenPerLevel[i]._objectForOpen}") != _listOpenPerLevel[i]._level) PlayerPrefs.SetInt($"LevelForOpen{_listOpenPerLevel[i]._objectForOpen}", _listOpenPerLevel[i]._level);
        }
    }
}

public class OpenPerLevel
{
    public enum ObjectForOpen
    {
        Baff1,
        Baff2,
        Baff3,
        Baff4,
        Baff5,
        DailyTasks,
        LuckWheel,
        Shop
    }

    public ObjectForOpen _objectForOpen;
    public int _level;

    public OpenPerLevel(ObjectForOpen _objectForOpen, int _level)
    {
        this._objectForOpen = _objectForOpen;
        this._level = _level;
    }
}