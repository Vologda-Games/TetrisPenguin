using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RatingsModel : MonoBehaviour
{
    [Header("Scripts")]
    public static RatingsModel instance;

    [Header("PlayersInformation")]

    public List<PlayerInformation> playersInformation = new List<PlayerInformation>();

    public Sprite defaultIcon, topOne, topTwo, topThree;

    [Header("YourInformation")]
    [HideInInspector] public int yourScore;
    [HideInInspector] public Sprite yourIcon;

    [Header("InformationFalseUsers")]
    [SerializeField] public bool usePlayersInformation;
    [SerializeField] public int quantityFalseUsers;


    private void Awake()
    {
        instance = this;
    }

    public void GetYourInformation()
    {
        yourScore = 0;
        for (int i = 0; i <= PlayerModel.instance.level; i++)
        {
            if (PlayerModel.instance.level > Levels.levels[i].level) yourScore += Levels.levels[i].experience;
            else if (PlayerModel.instance.level == Levels.levels[i].level) yourScore += PlayerModel.instance.experience;
        }
        if (yourIcon == null) yourIcon = defaultIcon;
    }
}

[Serializable]
public class PlayerInformation
{
    [Header("Information")]
    [JsonIgnore] public Sprite icon;
    public string name;
    public int score;
    [HideInInspector] public int topPosition;
    [HideInInspector, JsonIgnore] public RatingItemView ratingItemView;
}

public class SaveRatingsModel
{
    public List<PlayerInformation> playersInformation;
}