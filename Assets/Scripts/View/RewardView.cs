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
        Debug.Log("click");
        GameObject currentprefab = gameObject;
        Destroy(currentprefab);
    }

    public void ClickDoubleIt()
    {

    }
}
