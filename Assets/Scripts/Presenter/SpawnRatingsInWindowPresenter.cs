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
        RatingsModel.instance.GetYourInformation();
        RatingsPresenter.instance.LoadYourInformationInRatings();

        SpawnRatingItems();
    }

    public void SpawnRatingItems()
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
                    if (RatingsModel.instance.playersInformation[j]._score > _maxScore && !_readyPlayers.Contains(RatingsModel.instance.playersInformation[j]))
                    {
                        _maxScore = RatingsModel.instance.playersInformation[j]._score;
                        _numberPlayer = j;
                    }
                }
                _readyPlayers.Add(RatingsModel.instance.playersInformation[_numberPlayer]);
                GameObject _newItem = Instantiate(_ratingItem.gameObject, _parentRatingItems);
                RatingItemView _ratingItemView = _newItem.GetComponent<RatingItemView>();
                _ratingItemView.OutputInformationRatingItem(i, _numberPlayer);
                RatingsModel.instance._raitingItemsView.Add(_ratingItemView);
                RatingsModel.instance.playersInformation[_numberPlayer]._topPosition = i;
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
                    if (RatingsModel.instance._falseUsersInformation[j]._score > _maxScore && !_readyPlayers.Contains(RatingsModel.instance._falseUsersInformation[j]))
                    {
                        _maxScore = RatingsModel.instance._falseUsersInformation[j]._score;
                        _numberPlayer = j;
                    }
                }
                _readyPlayers.Add(RatingsModel.instance._falseUsersInformation[_numberPlayer]);
                GameObject _newItem = Instantiate(_ratingItem.gameObject, _parentRatingItems);
                RatingItemView _ratingItemView = _newItem.GetComponent<RatingItemView>();
                _ratingItemView.OutputInformationRatingItem(i, _numberPlayer);
                RatingsModel.instance._raitingItemsView.Add(_ratingItemView);
                RatingsModel.instance._falseUsersInformation[_numberPlayer]._topPosition = i;
            }
        }
    }
}