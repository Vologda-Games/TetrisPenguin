using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _buy;

    [Header("InformationItemShop")]
    [SerializeField] private GameObject[] _linesBaffs;
    [SerializeField] private List<ItemBaff> _itemBaffToOneLine = new List<ItemBaff>();
    [SerializeField] private List<ItemBaff> _itemBaffToSecondLine = new List<ItemBaff>();
    private ShopItemInformation _thisShopItemInformation;
    public void OutputInformationItemShop(ShopItemInformation _infoItem)
    {
        _buy.font = FontsModel.GetFont();
        _cost.font = FontsModel.GetFont();
        _buy.text = LibraryWords.buy.GetText();
        _cost.text = $"{_infoItem.costPurchase}";
        _linesBaffs[0].SetActive(true);
        _linesBaffs[1].SetActive(true);
        for (int i = 0; i < _infoItem.informationForBuyBaffs.Count; i++)
        {
            if (_infoItem.informationForBuyBaffs.Count < 4)
            {
                if (_itemBaffToOneLine[i]._baffText != null) _itemBaffToOneLine[i]._baffText.font = FontsModel.GetFont();
                if (_linesBaffs[1].activeSelf) _linesBaffs[1].SetActive(false);
                _itemBaffToOneLine[i]._baffImage.gameObject.SetActive(true);
                _itemBaffToOneLine[i]._baffText.text = $"x{_infoItem.informationForBuyBaffs[i].quantityAddBaff}";
                _itemBaffToOneLine[i]._baffImage.sprite = DailyTasksModel.spritesForRewardBaff[_infoItem.informationForBuyBaffs[i].numberAddBaff - 1];
            }else if (_infoItem.informationForBuyBaffs.Count == 4)
            {
                if(i <= 1)
                {
                    if (_itemBaffToOneLine[i]._baffText != null) _itemBaffToOneLine[i]._baffText.font = FontsModel.GetFont();
                    _itemBaffToOneLine[i]._baffImage.gameObject.SetActive(true);
                    _itemBaffToOneLine[i]._baffText.text = $"x{_infoItem.informationForBuyBaffs[i].quantityAddBaff}";
                    _itemBaffToOneLine[i]._baffImage.sprite = DailyTasksModel.spritesForRewardBaff[_infoItem.informationForBuyBaffs[i].numberAddBaff - 1];
                }else if (i > 1)
                {
                    if (_itemBaffToOneLine[i - 2]._baffText != null) _itemBaffToOneLine[i - 2]._baffText.font = FontsModel.GetFont();
                    _itemBaffToSecondLine[i - 2]._baffImage.gameObject.SetActive(true);
                    _itemBaffToSecondLine[i - 2]._baffText.text = $"x{_infoItem.informationForBuyBaffs[i].quantityAddBaff}";
                    _itemBaffToSecondLine[i - 2]._baffImage.sprite = DailyTasksModel.spritesForRewardBaff[_infoItem.informationForBuyBaffs[i].numberAddBaff - 1];
                }
            }else if (_infoItem.informationForBuyBaffs.Count > 4)
            {
                if (i < 3)
                {
                    if (_itemBaffToOneLine[i]._baffText != null) _itemBaffToOneLine[i]._baffText.font = FontsModel.GetFont();
                    _itemBaffToOneLine[i]._baffImage.gameObject.SetActive(true);
                    _itemBaffToOneLine[i]._baffText.text = $"x{_infoItem.informationForBuyBaffs[i].quantityAddBaff}";
                    _itemBaffToOneLine[i]._baffImage.sprite = DailyTasksModel.spritesForRewardBaff[_infoItem.informationForBuyBaffs[i].numberAddBaff - 1];
                }
                else
                {
                    if (_itemBaffToOneLine[i - _itemBaffToOneLine.Count]._baffText != null) _itemBaffToOneLine[i - _itemBaffToOneLine.Count]._baffText.font = FontsModel.GetFont();
                    _itemBaffToSecondLine[i - _itemBaffToOneLine.Count]._baffImage.gameObject.SetActive(true);
                    _itemBaffToSecondLine[i - _itemBaffToOneLine.Count]._baffText.text = $"x{_infoItem.informationForBuyBaffs[i].quantityAddBaff}";
                    _itemBaffToSecondLine[i - _itemBaffToOneLine.Count]._baffImage.sprite = DailyTasksModel.spritesForRewardBaff[_infoItem.informationForBuyBaffs[i].numberAddBaff - 1];
                }
            }
        }
        _thisShopItemInformation = _infoItem;
    }

    public void Buy()
    {
        if (PlayerModel.instance.coins >= _thisShopItemInformation.costPurchase)
        {
            PlayerPresenter.instance.ReduceCoin(_thisShopItemInformation.costPurchase);
            for(int i = 0; i < _thisShopItemInformation.informationForBuyBaffs.Count; i++)
            {
                BafsPresenter.AddBaffsByNumber(_thisShopItemInformation.informationForBuyBaffs[i].numberAddBaff, _thisShopItemInformation.informationForBuyBaffs[i].quantityAddBaff);
            }
            DataPresenter.SaveBafsModel();
        }
        else return;
    }

    public void ClickButton()
    {
        MusicAndSoundsManager._instance.PlaySoundClickOnButton();
    }
}

[Serializable]
public class ItemBaff
{
    public Image _baffImage;
    public TMP_Text _baffText;
}