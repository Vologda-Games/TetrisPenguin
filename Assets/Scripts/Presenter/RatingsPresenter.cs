using System.Collections.Generic;
using UnityEngine;

public class RatingsPresenter : MonoBehaviour
{
    public static RatingsPresenter instance;

    [SerializeField] private string _wordsNames;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RatingsModel.instance.usePlayersInformation = true;
        RatingsModel.instance.quantityFalseUsers = 99;
        LoadFalseUsers();
    }

    public void LoadYourInformationInRatings()
    {
        bool _haveYou = false;
        RatingsModel.instance.GetYourInformation();

        for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
        {
            if (RatingsModel.instance.playersInformation[i].name == RatingsModel.instance.yourName)
            {
                RatingsModel.instance.playersInformation[i].score = RatingsModel.instance.yourScore;
                _haveYou = true;
                break;
            }
        }
        if (!_haveYou)
        {
            RatingsModel.instance.playersInformation.Add(
            new PlayerInformation()
            {
                name = RatingsModel.instance.yourName,
                score = RatingsModel.instance.yourScore,
            }
            );
        }
    }

    public void LoadFalseUsers()
    {
        if (!RatingsModel.instance.usePlayersInformation)
        {
            string[] _words = _wordsNames.Split(", ");
            RatingsModel.instance.playersInformation = new List<PlayerInformation>();
            for (int i = 0; i < RatingsModel.instance.quantityFalseUsers; i++)
            {
                RatingsModel.instance.playersInformation.Add(new PlayerInformation()
                {
                    name = $"{_words[Random.Range(0, _words.Length)]}",
                    score = Random.Range(0, 10000),
                });
            }
        }
    }
}