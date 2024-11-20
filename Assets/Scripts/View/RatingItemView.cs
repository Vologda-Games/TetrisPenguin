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
        PlayerInformation _playerInformation;
        if(RatingsModel.instance.usePlayersInformation) _playerInformation = RatingsModel.instance.playersInformation[_topPosition];
        else _playerInformation = RatingsModel.instance._falseUsersInformation[_topPosition];
        
        if(_playerInformation._icon != null) icon.sprite = _playerInformation._icon;
        else icon.sprite = RatingsModel.instance._defaultIcon;
        textName.text = _playerInformation._name;
        textScore.text = _playerInformation._score.ToString();
        textTopPosition.text = (_numberPlayer + 1).ToString();
        _topPositionPlayer = _numberPlayer;
        LoadSpecialIconForPlayer(); 
        
    }

    private void LoadSpecialIconForPlayer()
    {
        if(_topPositionPlayer == 0) topPositionImage.sprite = RatingsModel.instance._topOne;
        else if(_topPositionPlayer == 1) topPositionImage.sprite = RatingsModel.instance._topTwo;
        else if(_topPositionPlayer == 2) topPositionImage.sprite = RatingsModel.instance._topThree;
        else topPositionImage.enabled = false;
    }
}