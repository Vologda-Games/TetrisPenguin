using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerModel : MonoBehaviour
{
    [Header("Scripts")]

    [SerializeField] public List<OpenPerLevel> listOpenPerLevel = new List<OpenPerLevel>();
    public static LevelManagerModel instance;

    private void Awake()
    {
        instance = this;
    }
}

[Serializable]
public class OpenPerLevel
{
    public Button buttonForOpen;
    public GameObject buttonBlock;
    public GameObject textBaff;
    public int level;
}