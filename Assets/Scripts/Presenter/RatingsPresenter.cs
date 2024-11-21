
using UnityEngine;

public class RatingsPresenter : MonoBehaviour
{
    [Header("Scripts")]
    public static RatingsPresenter instance;

    [SerializeField] private string _wordsNames;

    private void Start()
    {
        instance = this;
        RatingsModel.instance.usePlayersInformation = false;
        RatingsModel.instance._quantityFalseUsers = 50;
        LoadFalseUsers();
    }

    public void LoadYourInformationInRatings()
    {
        bool _haveYou = false;
        if (RatingsModel.instance.usePlayersInformation)
        {
            for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
            {
                if (RatingsModel.instance.playersInformation[i].name == RatingsModel.instance._yourName)
                {
                    RatingsModel.instance.playersInformation[i].score = RatingsModel.instance._yourScore;
                    _haveYou = true;
                    break;
                }
            }
            if (!_haveYou)
            {
                RatingsModel.instance.playersInformation.Add(
                new PlayerInformation()
                {
                    name = RatingsModel.instance._yourName,
                    score = RatingsModel.instance._yourScore,
                }
                );
            }
        }
        else
        {
            for (int i = 0; i < RatingsModel.instance._falseUsersInformation.Count; i++)
            {
                if (RatingsModel.instance._falseUsersInformation[i].name == RatingsModel.instance._yourName)
                {
                    RatingsModel.instance._falseUsersInformation[i].score = RatingsModel.instance._yourScore;
                    _haveYou = true;
                    break;
                }
            }
            if (!_haveYou)
            {
                RatingsModel.instance._falseUsersInformation.Add(
                new PlayerInformation()
                {
                    name = RatingsModel.instance._yourName,
                    score = RatingsModel.instance._yourScore,
                }
                );
            }
        }
    }

    public void LoadFalseUsers()
    {
        string[] _words = _wordsNames.Split(", ");
        for (int i = 0; i < RatingsModel.instance._quantityFalseUsers; i++)
        {
            RatingsModel.instance._falseUsersInformation.Add(new PlayerInformation()
            {
                name = $"{_words[Random.Range(0, _words.Length)]}",
                score = Random.Range(0, 5000),
            });
        }
    }
}