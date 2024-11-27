using System.Collections.Generic;
using UnityEngine;

public class SpawnRatingsInWindowPresenter : MonoBehaviour
{
    [Header("AllForSpawnItem")]

    [SerializeField] public RectTransform _parentRatingItems;
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
        for (int i = 0; i < RatingsModel.instance.playersInformation.Count; i++)
        {
            if (RatingsModel.instance.playersInformation[i].name == LibraryWords.you.GetText())
            {
                _parentRatingItems.anchoredPosition = new Vector2(0f, (RatingsModel.instance.playersInformation[i].topPosition * 200) + (RatingsModel.instance.playersInformation[i].topPosition - 1) * 50);
                break;
            }
        }
    }

    private void SpawnRatingItems()
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
            GameObject _newItem = Instantiate(_ratingItem.gameObject, _parentRatingItems.transform);
            RatingItemView _ratingItemView = _newItem.GetComponent<RatingItemView>();
            _ratingItemView.OutputInformationRatingItem(i, _numberPlayer);
            RatingsModel.instance.playersInformation[_numberPlayer].topPosition = i;
            RatingsModel.instance.playersInformation[_numberPlayer].ratingItemView = _ratingItemView;
        }
    }
}