
using UnityEngine;

public class RatingsPresenter : MonoBehaviour
{
    [Header("Scripts")]
    public static RatingsPresenter instance;

    [SerializeField] private string _wordsNames;

    private void Start()
    {
        instance = this;
        RatingsModel.instance.usePlayersInformation = true;
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
                if (RatingsModel.instance.playersInformation[i]._name == RatingsModel.instance._yourName)
                {
                    RatingsModel.instance.playersInformation[i]._score = RatingsModel.instance._yourScore;
                    _haveYou = true;
                    break;
                }
            }
            if (!_haveYou)
            {
                RatingsModel.instance.playersInformation.Add(
                new PlayerInformation()
                {
                    _name = RatingsModel.instance._yourName,
                    _score = RatingsModel.instance._yourScore,
                }
                );
            }
        }
        else
        {
            for (int i = 0; i < RatingsModel.instance._falseUsersInformation.Count; i++)
            {
                if (RatingsModel.instance._falseUsersInformation[i]._name == RatingsModel.instance._yourName)
                {
                    RatingsModel.instance._falseUsersInformation[i]._score = RatingsModel.instance._yourScore;
                    _haveYou = true;
                    break;
                }
            }
            if (!_haveYou)
            {
                RatingsModel.instance._falseUsersInformation.Add(
                new PlayerInformation()
                {
                    _name = RatingsModel.instance._yourName,
                    _score = RatingsModel.instance._yourScore,
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
                _name = $"{_words[Random.Range(0, _words.Length)]}",
                _score = Random.Range(0, 8000),
            });
        }
    }
}