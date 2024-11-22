using TMPro;
using UnityEngine;

public class ShopItemView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text _cost;

    public void OutputInformationItemShop(ShopItemInformation _infoItem)
    {
        _cost.text = $"{_infoItem.costPurchase}";
    }
}