using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RewardPresenter : MonoBehaviour
{
    public static RewardPresenter instance;

    [Header("Transform")]
    [SerializeField] private Transform _parentItem;

    [Header("GameObject")]
    [SerializeField] private GameObject _rewardView;

    void Awake()
    {
        instance = this;
    }
    public void Initialization()
    {
        RewardView.instance.continueButton.onClick.AddListener(RewardView.instance.ClickContinue);
        RewardView.instance.doubleItButton.interactable = false;
        RewardView.instance.obj_ViewRewardexceptBlackBackground.localScale = new Vector3(0f, 0f, 0f);
        StartCoroutine(UpScale());
    }

    public void SpawnRewardView(string itemImage, int kol)
    {
        GameObject _newReward = Instantiate(_rewardView, _parentItem);
        switch (itemImage)
        {
            case "multicolor":
                RewardView.instance.rewardImage.sprite = RewardView.instance.spriteBafs[0];
                break;
            case "spring":
                RewardView.instance.rewardImage.sprite = RewardView.instance.spriteBafs[1];
                break;
            case "bomb":
                RewardView.instance.rewardImage.sprite = RewardView.instance.spriteBafs[2];
                break;
            case "tornado":
                RewardView.instance.rewardImage.sprite = RewardView.instance.spriteBafs[3];
                break;
            case "magnet":
                RewardView.instance.rewardImage.sprite = RewardView.instance.spriteBafs[4];
                break;
            case "money":
                RewardView.instance.rewardImage.sprite = RewardView.instance.SpriteCoin;
                break;
        }
        RewardView.instance.textReward.text = kol.ToString();
    }

    IEnumerator UpScale()
    {
        if (RewardView.instance.obj_ViewRewardexceptBlackBackground == null)
        {
            yield break; // Завершаем корутину, если объект уже уничтожен
        }
        float time = 0f;
        float duration = 0.2f;
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = new Vector3(1f, 1f, 1f);

        while (time < duration)
        {
            if (RewardView.instance.obj_ViewRewardexceptBlackBackground == null)
            {
                yield break; // Завершаем корутину, если объект уже уничтожен
            }
            time += Time.deltaTime;
            float progress = time / duration;
            RewardView.instance.obj_ViewRewardexceptBlackBackground.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }
        RewardView.instance.obj_ViewRewardexceptBlackBackground.localScale = targetScale;
    }
}
