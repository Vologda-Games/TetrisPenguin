using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class PenguinsModel : MonoBehaviour
{
    [Header("Scripts & Methods")]
    public static PenguinsModel instance;
    public List<PenguinObject> penguinObjectsForStart;
    public List<PenguinView> penguinViews;
    [SerializeField] public static List<LevelToChance> _levelToChances;
    [SerializeField] public List<LevelToChance> _levelToChancesInsp = new List<LevelToChance>();
    public PenguinView penguinInSpawn;
    public PenguinView penguinInSpawnMagnet;
    public List<PenguinCardInformation> penguinsCardsInformations;

    [Header("GameObjects")]
    public GameObject particleFog;
    public GameObject particleBomb;

    [Header("Transforms")]
    public Transform particleParent;

    [Header("Sprites")]
    public static Sprite[] spritesAllSoftPenguins;
    public static Sprite[] spritesAllUnknownPenguins;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        penguinObjectsForStart = new List<PenguinObject>();
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
    public List<PenguinCardInformation> penguinsCardsInformations;
}

[Serializable]
public class LevelToChance
{
    [SerializeField, HideInInspector] public string level;

    [Range(0, 100)]
    [SerializeField] public int chance;
}

public class PenguinCardInformation
{
    [JsonIgnore] public Sprite softSprite;
    [JsonIgnore] public Sprite unknownSprite;
    public int levelPenguin;
    public bool ready;
}