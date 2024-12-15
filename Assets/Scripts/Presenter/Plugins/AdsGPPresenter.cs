using GamePush;
using UnityEngine;

public class AdsGPPresenter : MonoBehaviour
{
    public static AdsGPPresenter instance;

    [HideInInspector] public int REARD_NOW = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GP_Ads.OnAdsStart += OnAdsStart;
        GP_Ads.OnAdsClose += OnAdsClose;
    }

    private void OnDisable()
    {
        GP_Ads.OnAdsStart -= OnAdsStart;
        GP_Ads.OnAdsClose -= OnAdsClose;
    }

    private void OnAdsStart()
    {
        Debug.Log("������� ��������)");
        MusicAndSoundsManager.instance.ChangeMusicCondition();
        Time.timeScale = 0.0f;
        // ������� ����� �������
    }
    private void OnAdsClose(bool success)
    {
        Debug.Log("������� �����������)");
        Time.timeScale = 1.0f;
        MusicAndSoundsManager.instance.ChangeMusicCondition();
        // ���������� ����� �������
    }

    // �������� fullscreen
    public void ShowFullscreen()
    {
        Debug.Log("<color=#04bc04> GP: </color> ����������� FULLSCRIN �������!");
        GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);
    }

        // ������� �����
    private void OnFullscreenStart()
    {
    }
    // ���������� �����
    private void OnFullscreenClose(bool success)
    {
    }


    // �������� rewarded video
    public void ShowRewardedOfLuckWheel() => GP_Ads.ShowRewarded("PRIZE", OnRewardedReward, OnRewardedStart, OnRewardedClose);
    public void ShowRewarded() => GP_Ads.ShowRewarded("COINS", OnRewardedReward, OnRewardedStart, OnRewardedClose);


    // ������� �����
    private void OnRewardedStart() => Debug.Log("ON REWARDED: START");
    // �������� �������
    private void OnRewardedReward(string value)
    {
        if (value == "PRIZE")
        {
            LuckWheelPresenter.instance.GetPrize(false);
            Debug.Log($"Rewarded {REARD_NOW}");
        }else if (value == "COINS")
        {
            PlayerPresenter.instance.AddCoin(REARD_NOW);
            Debug.Log($"Rewarded {REARD_NOW}");
        }
    }

        // ���������� �����
        private void OnRewardedClose(bool success) => Debug.Log("ON REWARDED: CLOSE");
}
