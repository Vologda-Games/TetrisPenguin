using System;
using System.Collections.Generic;
using UnityEngine;

public class PenguinsModel : MonoBehaviour
{
    public static PenguinsModel instance;
    public List<PenguinObject> penguinObjectsForStart;
    public List<PenguinView> penguinViews;
    [SerializeField] public static List<LevelToChance> _levelToChances;
    [SerializeField] public List<LevelToChance> _levelToChancesInsp = new List<LevelToChance>();
    public PenguinView penguinInSpawn;

    private void Awake()
    {
        penguinObjectsForStart = new List<PenguinObject>();
        instance = this;
        _levelToChances = _levelToChancesInsp;
    }

    public List<PenguinObject> GetPenguins()
    {
        List<PenguinObject> penguins = new List<PenguinObject>();
        for (int i = 0; i < penguinViews.Count; i++)
        {
            penguins.Add(new PenguinObject(penguinViews[i].level, penguinViews[i].objTransform.localPosition));
        }
        return penguins;
    }
}

public class SavePenguinsModel
{
    public List<PenguinObject> penguinObjects;
}

[Serializable]
public class LevelToChance
{
    [SerializeField] [HideInInspector] public string level;

    [Range(0, 100)]
    [SerializeField] public int chance;
}