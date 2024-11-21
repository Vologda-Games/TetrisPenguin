using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRatingsInWindowPresenter : MonoBehaviour
{
    [Header("AllForSpawnItem")]

    [SerializeField] public Transform _parentRatingItems;
    [SerializeField] public RatingItemView _ratingItem;

    private int _maxScore = -1;
    private int _numberPlayer = -1;

    private void Start()
    {
        RatingsPresenter.instance.LoadYourInformationInRatings();

        SpawnRatingItems();

        ScrollToYou();
    }

    private void ScrollToYou()
    {

        if (RatingsModel.instance.usePlayersInformation)
        {
            for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
            {
                if (RatingsModel.instance.playersInformation[i].name == RatingsModel.instance._yourName)
                {
                    _parentRatingItems.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (RatingsModel.instance.playersInformation[i].topPosition * 200) + (RatingsModel.instance.playersInformation[i].topPosition - 1) * 50);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < RatingsModel.instance._falseUsersInformation.Count; i++)
            {
                if (RatingsModel.instance._falseUsersInformation[i].name == RatingsModel.instance._yourName)
                {
                    _parentRatingItems.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (RatingsModel.instance._falseUsersInformation[i].topPosition * 200) + (RatingsModel.instance._falseUsersInformation[i].topPosition - 1) * 50);
                    break;
                }
            }
        }
    }

    private void SpawnRatingItems()
    {
        if (RatingsModel.instance.usePlayersInformation)
        {
            List<PlayerInformation> _readyPlayers = new List<PlayerInformation>();
            for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
            {
                _maxScore = -1;
                _numberPlayer = -1;
                for (int j = 0; j < RatingsModel.instance.playersInformation.Count; j++)
                {
                    if (RatingsModel.instance.playersInformation[j].score > _maxScore && !_readyPlayers.Contains(RatingsModel.instance.playersInformation[j]))
                    {
                        _maxScore = RatingsModel.instance.playersInformation[j].score;
                        _numberPlayer = j;
                    }
                }
                _readyPlayers.Add(RatingsModel.instance.playersInformation[_numberPlayer]);
                GameObject _newItem = Instantiate(_ratingItem.gameObject, _parentRatingItems);
                RatingItemView _ratingItemView = _newItem.GetComponent<RatingItemView>();
                _ratingItemView.OutputInformationRatingItem(i, _numberPlayer);
                RatingsModel.instance.playersInformation[_numberPlayer].topPosition = i;
                RatingsModel.instance.playersInformation[_numberPlayer].ratingItemView = _ratingItemView;
            }
        }
        else
        {
            List<PlayerInformation> _readyPlayers = new List<PlayerInformation>();
            for (int i = 0; i < RatingsModel.instance._falseUsersInformation.Count; i++)
            {
                _maxScore = -1;
                _numberPlayer = -1;
                for (int j = 0; j < RatingsModel.instance._falseUsersInformation.Count; j++)
                {
                    if (RatingsModel.instance._falseUsersInformation[j].score > _maxScore && !_readyPlayers.Contains(RatingsModel.instance._falseUsersInformation[j]))
                    {
                        _maxScore = RatingsModel.instance._falseUsersInformation[j].score;
                        _numberPlayer = j;
                    }
                }
                _readyPlayers.Add(RatingsModel.instance._falseUsersInformation[_numberPlayer]);
                GameObject _newItem = Instantiate(_ratingItem.gameObject, _parentRatingItems);
                RatingItemView _ratingItemView = _newItem.GetComponent<RatingItemView>();
                _ratingItemView.OutputInformationRatingItem(i, _numberPlayer);
                RatingsModel.instance._falseUsersInformation[_numberPlayer].topPosition = i;
                RatingsModel.instance._falseUsersInformation[_numberPlayer].ratingItemView = _ratingItemView;
            }
        }
    }
}