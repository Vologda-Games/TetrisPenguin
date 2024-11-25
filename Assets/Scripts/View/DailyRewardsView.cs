using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DailyRewardsView : MonoBehaviour
{
    public static DailyRewardsView instance;

    [Header("UI")]
    [SerializeField] public Slider slider;
    [SerializeField] public TextMeshProUGUI rewardPrice;
    [SerializeField] public Button claimButton;
    [SerializeField] public GameObject BlackBackground;
    [SerializeField] public List<TextMeshProUGUI> textDay = new List<TextMeshProUGUI>();
    [SerializeField] public List<Image> icons = new List<Image>();
    [SerializeField] public List<Sprite> BlueAndYellow = new List<Sprite>();
    [SerializeField] public RectTransform rectTranformClaimButton;
    [SerializeField] public TextMeshProUGUI textInButton;
    [SerializeField] public TMP_FontAsset  newFont;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DailyRewardsPresenter.instance.Initialization();
        BlackBackground.SetActive(false);
        DailyRewardsPresenter.instance.IsWindowDailtRewards(true);
    }
    
    public void CloseWindow() 
    {
        DailyRewardsPresenter.instance.EventCloseDailyRewards();
    }
    
}
