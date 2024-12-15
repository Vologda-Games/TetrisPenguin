using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerModel : MonoBehaviour
{
    [Header("Scripts")]

    [SerializeField] public List<OpenPerLevel> _listOpenPerLevel = new List<OpenPerLevel>();
    public static LevelManagerModel instance;

    private void Awake()
    {
        instance = this;
    }
}

[Serializable]
public class OpenPerLevel
{
    public Button _buttonForOpen;
    public int _level;
}