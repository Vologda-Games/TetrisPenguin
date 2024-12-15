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
        RatingsModel.instance.usePlayersInformation = false;
        RatingsModel.instance.quantityFalseUsers = 50;
    }


    public void LoadYourInformationInRatings()
    {
        bool _haveYou = false;
        RatingsModel.instance.GetYourInformation();

        for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
        {
            if (RatingsModel.instance.playersInformation[i].name == LibraryWords.you.GetText())
            {
                RatingsModel.instance.playersInformation[i].score = RatingsModel.instance.yourScore;
                RatingsModel.instance.playersInformation[i].id = RatingsModel.instance.yourId;
                _haveYou = true;
                break;
            }
        }
        if (!_haveYou)
        {
            RatingsModel.instance.playersInformation.Add(
            new PlayerInformation()
            {
                name = LibraryWords.you.GetText(),
                score = RatingsModel.instance.yourScore,
                id = RatingsModel.instance.yourId
            }
            );
        }
    }

    public void AddRandomExperienceYoureOpponent()
    {
        for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
        {
            if (RatingsModel.instance.playersInformation[i].id != RatingsModel.instance.yourId)
            {
                if (Levels.CurrentLevel <= 11) RatingsModel.instance.playersInformation[i].score += Random.Range(650 * Levels.CurrentLevel, 1000 * Levels.CurrentLevel);
                else RatingsModel.instance.playersInformation[i].score += Random.Range(150 * Levels.CurrentLevel, 400 * Levels.CurrentLevel);
            }
        }
        DataPresenter.SaveRatingsModel();
    }

    public void LoadFalseUsers()
    {
        if (!RatingsModel.instance.usePlayersInformation && RatingsModel.instance.playersInformation == null)
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