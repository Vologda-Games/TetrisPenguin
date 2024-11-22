using UnityEngine;

public class SpawnItemShopPresenter : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform _parentItems;

    [Header("GameObjects")]
    [SerializeField] private GameObject _itemShopObject;

    private void Start()
    {
        SpawnItemShop();
    }

    public void SpawnItemShop()
    {
        for (int i = 0; i < ShopModel.shopItems.Count; i++)
        {
            GameObject _newItem = Instantiate(_itemShopObject, _parentItems);
            ShopItemView _shopItemView = _newItem.GetComponent<ShopItemView>();
            if (_shopItemView != null) _shopItemView.OutputInformationItemShop(ShopModel.shopItems[i]);
        }
    }
}