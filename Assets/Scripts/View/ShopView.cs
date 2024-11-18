using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public static ShopView instance;

    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] private TMP_Text[] _titleProductTexts;
    [SerializeField] private TMP_Text[] _buttonProductTexts;
    [SerializeField] private TMP_Text[] _costProductDonateTexts;
    [SerializeField] private Image[] _currencyProductDonateTexts;

    // временно, далее локализация
    private readonly string[] _titleProducts = new string[] { "Стопка монет", "Кучка монет", "Гора монет", "Монеты", "Восстановление" };
    private readonly string[] _buttonProduct = new string[] { "Бесплатно", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить" };

    private Action<bool> _rewardDonate_1 = (result) => { PlayerPresenter.instance.AddCoin(3000); };
    private Action<bool> _rewardDonate_2 = (result) => { PlayerPresenter.instance.AddCoin(10000); };
    private Action<bool> _rewardDonate_3 = (result) => { PlayerPresenter.instance.AddCoin(25000); };
    private Action<bool> _rewardAds = (result) => { PlayerPresenter.instance.AddCoin(900); };
    private Action<bool> _rewardCoin_1 = (result) => { PlayerPresenter.instance.ReduceCoin(1899); PlayerPresenter.instance.AddCoin(1800); };
    private Action<bool> _rewardCoin_2 = (result) => { PlayerPresenter.instance.ReduceCoin(1999); BafsPresenter.AddBombBafs(1); BafsPresenter.AddMulticolorBafs(1); BafsPresenter.AddSpringBafs(1); LuckWheelPresenter.AddToken(1); };
    private Action<bool> _rewardCoin_3 = (result) => { PlayerPresenter.instance.ReduceCoin(3999); BafsPresenter.AddTornadoBafs(1); BafsPresenter.AddMagnetBafs(1); LuckWheelPresenter.AddToken(1); };
    private Action<bool> _rewardCoin_4 = (result) => { PlayerPresenter.instance.ReduceCoin(4999); BafsPresenter.AddBombBafs(3); BafsPresenter.AddMulticolorBafs(3); BafsPresenter.AddSpringBafs(3); LuckWheelPresenter.AddToken(1); };
    private Action<bool> _rewardCoin_5 = (result) => { PlayerPresenter.instance.ReduceCoin(8999); BafsPresenter.AddBombBafs(1); BafsPresenter.AddMulticolorBafs(1); BafsPresenter.AddSpringBafs(1); BafsPresenter.AddTornadoBafs(3); BafsPresenter.AddMagnetBafs(3); };
    private Action<bool> _rewardCoin_6 = (result) => { PlayerPresenter.instance.ReduceCoin(9999); BafsPresenter.AddBombBafs(5); BafsPresenter.AddMulticolorBafs(5); BafsPresenter.AddSpringBafs(5); BafsPresenter.AddTornadoBafs(1); BafsPresenter.AddMagnetBafs(1); PlayerPresenter.instance.AddCoin(1800); };

    private int[] _costCoins = new int[] { 1899, 1999, 3999, 4999, 8999, 9999 };

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RenderCoins();
    }

    public void EventCloseShop()
    {
        GameInterface.instance.CloseFirstLayout();
    }

    public void RenderCoins()
    {
        _experienceText.text = PlayerModel.instance.experience.ToString();
    }

    public void Localization()
    {
        _titleText.text = "Магазин";
        for (int i = 0; i < _titleProductTexts.Length; i++)
        {
            _titleProductTexts[i].text = _titleProducts[i];
        }
        for (int i = 0; i < _buttonProductTexts.Length; i++)
        {
            _buttonProductTexts[i].text = _buttonProduct[i];
        }
        for (int i = 0; i < _costProductDonateTexts.Length; i++)
        {
            _costProductDonateTexts[i].text = "19"; // будет получение из массива
            // _currencyProductDonateTexts[i].sprite = в массиве с GP
        }
    }

    public void EventBuyDonate(int index)
    {
        // обоработка платежа
        if (true) // success
        {
            _rewardDonate_1?.Invoke(true);
        }
    }

    public void EventBuyFree()
    {
        // показ рекламы
        _rewardAds?.Invoke(true);
    }

    public void EventBuyCoin(int index)
    {
        if (PlayerModel.instance.coins >= _costCoins[index - 1])
        {
            switch (index)
            {
                case 1:
                    _rewardCoin_1?.Invoke(true);
                    break;
                case 2:
                    _rewardCoin_2?.Invoke(true);
                    break;
                case 3:
                    _rewardCoin_3?.Invoke(true);
                    break;
                case 4:
                    _rewardCoin_4?.Invoke(true);
                    break;
                case 5:
                    _rewardCoin_5?.Invoke(true);
                    break;
                case 6:
                    _rewardCoin_6?.Invoke(true);
                    break;
            }
            RenderCoins();
        }
    }
}