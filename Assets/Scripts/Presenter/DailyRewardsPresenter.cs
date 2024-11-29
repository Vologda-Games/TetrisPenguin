using System.Collections;
using System.Collections.Generic;
using GamePush.Data;
using UnityEngine;

public class DailyRewardsPresenter : MonoBehaviour
{
    public static DailyRewardsPresenter instance;
    private bool isBlackBackground;
    private bool isDailyRewardsWindow;

    void Awake() 
    {
        instance = this;
    }
    
    public void IsWindowDailtRewards(bool meaning) 
    {
        isDailyRewardsWindow = meaning;
    }

    public bool GetIsWindowDailtRewardsBool() 
    {
        return isDailyRewardsWindow;
    }

    public void Initialization() 
    {
    if (DailyRewardsView.instance.slider != null) 
            {
                //PlayerPrefs.GetInt("currentDay");
                Invoke("IsBackground", 0.3f);
                // if (!PlayerPrefs.HasKey("claimRewadsBool")) 
                // {
                //     DailyRewardsModel.instance.claimRewadsBool = new List<bool>(new bool[DailyRewardsModel.instance.rewards.Count]);
                // }

                DailyRewardsView.instance.slider.minValue = 1;
                DailyRewardsView.instance.slider.maxValue = DailyRewardsModel.instance.rewards.Count;
                DailyRewardsView.instance.slider.wholeNumbers = true;
                DailyRewardsView.instance.slider.interactable = false;

                DailyRewardsView.instance.slider.value = Mathf.Clamp(GetCurrentDay(), 1, DailyRewardsModel.instance.rewards.Count);
                DailyRewardsView.instance.slider.onValueChanged.AddListener(OnSliderValueChanged);

                if (DailyRewardsView.instance.claimButton != null) 
                {
                    DailyRewardsView.instance.claimButton.onClick.AddListener(ClaimRewardButton);
                }
                UpdateUI((int)DailyRewardsView.instance.slider.value);
                DayTextAnimation();
                SwipeImage();
            }
    }

    private void IsBackground() 
    {
        isBlackBackground = !isBlackBackground;

        if (isBlackBackground) 
        {
            DailyRewardsView.instance.BlackBackground.SetActive(isBlackBackground);
        }
        else 
        {
            DailyRewardsView.instance.BlackBackground.SetActive(isBlackBackground);
        }
        Debug.Log($"isBlackBackground: {isBlackBackground}");
    }

    public void OnSliderValueChanged(float value) 
    {
        if (value > DailyRewardsModel.instance.maxDay) 
        {
            DailyRewardsView.instance.slider.value = DailyRewardsModel.instance.maxDay;
        }
        else 
        {
            UpdateUI((int)value);
        }
    }

    private void UpdateUI(int day) 
    {
        int index = day - 1;
        int money = DailyRewardsModel.instance.rewards[index];

        DailyRewardsView.instance.rewardPrice.text = money.ToString();                    //$"Заберите награду за {day} день";
        DailyRewardsView.instance.textInButton.text = LibraryWords.get.GetText();
        DailyRewardsView.instance.claimButton.interactable = !DailyRewardsModel.instance.claimRewadsBool[index]; // если true = забрана, то отключает кнопку
        if (DailyRewardsModel.instance.claimRewadsBool[index]) 
        {            
            DailyRewardsView.instance.textInButton.text = LibraryWords.received.GetText(); //$"Получено";
        }
    }

    public void ClaimRewardButton() 
    {
        
        StartCoroutine(ScaleButton());
        int day = (int)DailyRewardsView.instance.slider.value;
        int index = day - 1;
        int money = DailyRewardsModel.instance.rewards[index];
        if (DailyRewardsModel.instance.claimRewadsBool[index]) 
        {
            return;
        }

        DailyRewardsModel.instance.claimRewadsBool[index] = true;

        DailyRewardsView.instance.rewardPrice.text =   money.ToString();                                        //$"Вы получили {DailyRewardsModel.instance.rewards[index]} монет за {day} день!";
        DailyRewardsView.instance.textInButton.text = LibraryWords.received.GetText();         // $"Получено";
        DailyRewardsView.instance.claimButton.interactable = false;

        //CurrentSaveBoolList();
        PlayerPresenter.instance.AddCoin(DailyRewardsModel.instance.rewards[index]);
    }

    IEnumerator ScaleButton() 
    {
        float time = 0;
        float duration = 0.2f;

        Vector3 currentScale = DailyRewardsView.instance.rectTranformClaimButton.localScale;
        Vector3 futureScale = new Vector3(0.8f,0.8f,0.8f);

        while(time < duration) 
        {
            time += Time.deltaTime;
            float progress = time/duration;
            DailyRewardsView.instance.rectTranformClaimButton.localScale = Vector3.Lerp(currentScale, futureScale, progress);
            yield return null;

        }
        DailyRewardsView.instance.rectTranformClaimButton.localScale = futureScale;

        DailyRewardsView.instance.textInButton.text = LibraryWords.received.GetText();   //$"Получено";
        time = 0;
        
        while(time < duration) 
        {
            time += Time.deltaTime;
            float progress = time/duration;
            DailyRewardsView.instance.rectTranformClaimButton.localScale = Vector3.Lerp(futureScale, currentScale, progress);
            yield return null;
        }
        DailyRewardsView.instance.rectTranformClaimButton.localScale = currentScale;
    }
    private int GetCurrentDay() //Написать метод какой день сейчас. Если день пропущен, то все заново с 1 дня. Через скрипт NewDayEventModel
    {
        return DailyRewardsModel.instance.currentDay;
    }

    public void NewDay() 
    {
        //if (PlayerPrefs.HasKey("currentDay")) 
        if (DailyRewardsModel.instance.currentDay != 0 && DailyRewardsModel.instance.currentDay < 8)
        {
            //DailyRewardsModel.instance.currentDay = PlayerPrefs.GetInt("currentDay");
        }
        else 
        {
            DailyRewardsModel.instance.currentDay = 1;
            DailyRewardsModel.instance.claimRewadsBool = new List<bool>(new bool[DailyRewardsModel.instance.rewards.Count]);
        }

        if (DailyRewardsModel.instance.claimRewadsBool[DailyRewardsModel.instance.currentDay - 1] == true) 
        {
            DailyRewardsModel.instance.currentDay++;
        }

        if (DailyRewardsModel.instance.currentDay > 7) 
        {
            DailyRewardsModel.instance.currentDay = 1;
            for (int i = 0; i < DailyRewardsModel.instance.claimRewadsBool.Count; i++) 
            {
                DailyRewardsModel.instance.claimRewadsBool[i] = false;
            }
            //CurrentSaveBoolList();
        }

        GetCurrentDay();
        //SaveDayDailyRewards(DailyRewardsModel.instance.currentDay);
    }

    // private void SaveDayDailyRewards(int value) 
    // {
    //     PlayerPrefs.SetInt("currentDay", value);
    // }

    // private void CurrentSaveBoolList() 
    // {
    //     DailyRewardsModel.instance.SaveBoolList(DailyRewardsModel.instance.claimRewadsBool);
    // }

    public void EventCloseDailyRewards()
    {
        IsBackground();
        Debug.Log("CLOSE");
        IsWindowDailtRewards(false);
        WindowManager.instance.EventCloseWindow();
    }

    private void DayTextAnimation() 
    {
        for (int i = 0; i < DailyRewardsView.instance.textDay.Count; i++) 
        {
            DailyRewardsView.instance.textDay[i].color = new Color(0.51f,0.51f,0.51f, 0.5f);
            DailyRewardsView.instance.textDay[i].rectTransform.localScale = new Vector3(1f,1f,1f);
            DailyRewardsView.instance.icons[i].rectTransform.localScale = new Vector3(1.35f,1.35f,1.35f);
        }
        int CurrentDay = DailyRewardsModel.instance.currentDay;
        if (CurrentDay == 0) 
        {
            CurrentDay = 1;
        }
        for (int i = 0; i < CurrentDay - 1; i++) 
        {
            DailyRewardsView.instance.icons[i].color = new Color(0f, 0.8f,1f);
            DailyRewardsView.instance.textDay[i].color = new Color(0.51f,0.51f,0.51f, 0.8f);
        }
        DailyRewardsView.instance.icons[CurrentDay -1].color = new Color(0f, 0.9f,1f);
        DailyRewardsView.instance.textDay[CurrentDay -1].color = new Color(1f,1f,1f);
        DailyRewardsView.instance.textDay[CurrentDay -1].rectTransform.localScale = new Vector3(1.5f,1.5f,1.5f);
        DailyRewardsView.instance.icons[CurrentDay -1].rectTransform.localScale = new Vector3(1.7f,1.7f,1.7f);
        DailyRewardsView.instance.textDay[CurrentDay -1].font = DailyRewardsView.instance.newFont;
    }

    public bool isReward() 
    {    
        int day = DailyRewardsModel.instance.currentDay;
        if (day == 0) 
        {
            day = 1;
        }

        for (int i = 0; i < DailyRewardsModel.instance.claimRewadsBool.Count; i++) 
        {
            if (DailyRewardsModel.instance.claimRewadsBool[day - 1] == false) 
            {
                return true;
            }
        }
        return false;
    }

    public void SwipeImage() 
    {
        int day = GetCurrentDay();
        if (day == 0) 
        {
            day = 1;
        }
        for (int i = 0; i < day; i++) 
        {
            DailyRewardsView.instance.icons[i].sprite = DailyRewardsView.instance.BlueAndYellow[0];
        }
    }
}
