using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatingItemView : MonoBehaviour
{
    [Header("UI")]
    public Image icon, topPositionImage;
    public TMP_Text textName, textScore, textTopPosition;
    private int _topPositionPlayer;

    public void OutputInformationRatingItem(int _numberPlayer, int _topPosition)
    {
        PlayerInformation _playerInformation = RatingsModel.instance.playersInformation[_topPosition];
        if (_playerInformation.icon != null) icon.sprite = _playerInformation.icon;
        else icon.sprite = RatingsModel.instance.defaultIcon;
        textName.text = _playerInformation.name;
        textScore.text = _playerInformation.score.ToString();
        textTopPosition.text = (_numberPlayer + 1).ToString();
        _topPositionPlayer = _numberPlayer;
        LoadSpecialIconForPlayer();
    }

    private void LoadSpecialIconForPlayer()
    {
        if (_topPositionPlayer == 0) topPositionImage.sprite = RatingsModel.instance.topOne;
        else if (_topPositionPlayer == 1) topPositionImage.sprite = RatingsModel.instance.topTwo;
        else if (_topPositionPlayer == 2) topPositionImage.sprite = RatingsModel.instance.topThree;
        else topPositionImage.enabled = false;
    }
}