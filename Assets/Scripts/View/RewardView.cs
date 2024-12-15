using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardView : MonoBehaviour
{
    public static RewardView instance;

    [Header("UI")]
    [SerializeField] public Image rewardImage;
    [SerializeField] public TextMeshProUGUI textReward;

    [SerializeField] public Sprite[] spriteBafs;
    [SerializeField] public Sprite SpriteCoin;

    [Header("Buttons")]
    [SerializeField] public Button continueButton;
    [SerializeField] public Button doubleItButton;

    [Header("Transform")]
    [SerializeField] public Transform obj_ViewRewardexceptBlackBackground;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        RewardPresenter.instance.Initialization();
    }

    public void ClickContinue()
    {
        Destroy(gameObject);
    }

    public void ClickDoubleIt()
    {
        AdsGPPresenter.instance.REARD_NOW = RewardPresenter.instance.kol;
        if (GameInterface.instance.activeView == ViewModel.instance._wheelOfLuck) AdsGPPresenter.instance.ShowRewardedOfLuckWheel();
        else AdsGPPresenter.instance.ShowRewarded();
        Destroy(gameObject);
    }
}
