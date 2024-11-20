using System;
using System.Collections.Generic;
using UnityEngine;

public class RatingsModel : MonoBehaviour
{
    [Header("Scripts")]
    public static RatingsModel instance;

    [Header("PlayersInformation")]

    public List<PlayerInformation> playersInformation = new List<PlayerInformation>();
    [HideInInspector] public List<RatingItemView> _raitingItemsView = new List<RatingItemView>();
    public List<PlayerInformation> _falseUsersInformation = new List<PlayerInformation>();

    public Sprite _defaultIcon, _topOne, _topTwo, _topThree;

    [Header("YourInformation")]
    [HideInInspector] public int _yourScore;
    [HideInInspector] public string _yourName;
    [HideInInspector] public Sprite _yourIcon;

    [Header("InformationFalseUsers")]
    [SerializeField] public bool usePlayersInformation;
    [SerializeField] public int _quantityFalseUsers;


    private void Awake()
    {
        instance = this;
    }

    public void GetYourInformation()
    {
        _yourScore = 0;
        for (int i = 0; i <= PlayerModel.instance.level; i++)
        {
            if (PlayerModel.instance.level < Levels.levels[i].level) _yourScore += Levels.levels[i].experience;
            else if (PlayerModel.instance.level == Levels.levels[i].level) _yourScore += PlayerModel.instance.experience;
        }
        if (_yourName == null || _yourName == "") _yourName = "Вы";
        if (_yourIcon == null) _yourIcon = _defaultIcon;
    }
}

[Serializable]
public class PlayerInformation
{
    [Header("Information")]

    public Sprite _icon;
    public string _name;
    public int _score;
    [HideInInspector] public int _topPosition;
}