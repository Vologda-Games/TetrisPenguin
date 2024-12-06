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

    [Header("1. Reward, 2. Button(Continue), 3. Button(Double)")]
    [SerializeField] private TextMeshProUGUI[] textAll;

    [Header("Transform")]
    [SerializeField] public Transform obj_ViewRewardexceptBlackBackground;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        RewardPresenter.instance.Initialization();
        textAll[0].text = LibraryWords.reward.GetText();
        textAll[0].font = FontsModel.GetFont();
        textAll[1].text = LibraryWords.continueText.GetText();
        textAll[1].font = FontsModel.GetFont();
        textAll[2].text = LibraryWords.doubleIt.GetText();
        textAll[2].font = FontsModel.GetFont();
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
