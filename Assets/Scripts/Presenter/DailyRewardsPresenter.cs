using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardsPresenter : MonoBehaviour
{
    public static DailyRewardsPresenter instance;

    private bool isBlackBackground;
    void Awake() 
    {
        instance = this;
    }
 
    public void Initialization() 
    {
    if (DailyRewardsView.instance.slider != null) 
            {
                Invoke("IsBackground", 0.2f);
                if (!PlayerPrefs.HasKey("claimRewadsBool")) 
                {
                    DailyRewardsModel.instance.claimRewadsBool = new List<bool>(new bool[DailyRewardsModel.instance.rewards.Count]);
                }

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
        DailyRewardsView.instance.rewardPrice.text = $"день {day}: {DailyRewardsModel.instance.rewards[index]}";
        DailyRewardsView.instance.claimButton.interactable = !DailyRewardsModel.instance.claimRewadsBool[index]; // если true = забрана, то отключает кнопку
        if (DailyRewardsModel.instance.claimRewadsBool[index]) 
        {
            DailyRewardsView.instance.rewardPrice.text = $"день {day}: награда получена!";
        }
    }

    public void ClaimRewardButton() 
    {
        int day = (int)DailyRewardsView.instance.slider.value;
        int index = day - 1;

        if (DailyRewardsModel.instance.claimRewadsBool[index]) 
        {
            Debug.Log("Эта награда уже была забрана");
            return;
        }

        DailyRewardsModel.instance.claimRewadsBool[index] = true;

        DailyRewardsView.instance.rewardPrice.text = $"день {day}: награда получена!";
        DailyRewardsView.instance.claimButton.interactable = false;

        CurrentSaveBoolList();
        Debug.Log($"награда за день {day} получена: {DailyRewardsModel.instance.rewards[index]}");
        AddToken(DailyRewardsModel.instance.rewards[index]);
    }

    private int GetCurrentDay() //Написать метод какой день сейчас. Если день пропущен, то все заново с 1 дня. Через скрипт NewDayEventModel
    {
        return DailyRewardsModel.instance.currentDay;
    }

    public void NewDay() 
    {
        if (PlayerPrefs.HasKey("currentDay")) 
        {
            DailyRewardsModel.instance.currentDay = PlayerPrefs.GetInt("currentDay");
        }
        else 
        {
            DailyRewardsModel.instance.currentDay = 1;
        }
        
        /*if (DailyRewardsModel.instance.claimRewadsBool[DailyRewardsModel.instance.currentDay - 1] == true) 
        {
            DailyRewardsModel.instance.currentDay++;
        }*/

        if (DailyRewardsModel.instance.currentDay > 7) 
        {
            DailyRewardsModel.instance.currentDay = 1;
            for (int i = 0; i < DailyRewardsModel.instance.claimRewadsBool.Count; i++) 
            {
                DailyRewardsModel.instance.claimRewadsBool[i] = false;
            }
            CurrentSaveBoolList();
        }

        GetCurrentDay();
        SaveDayDailyRewards(DailyRewardsModel.instance.currentDay);
        Debug.Log("Текущий день для ежедненвых заданий: " + DailyRewardsModel.instance.currentDay);
    }

    private void SaveDayDailyRewards(int value) 
    {
        PlayerPrefs.SetInt("currentDay", value);
    }

    private void CurrentSaveBoolList() 
    {
        DailyRewardsModel.instance.SaveBoolList(DailyRewardsModel.instance.claimRewadsBool);
    }

    public void AddToken(int value)
    {
        PlayerModel.instance.coins += value;
        PlayerView.instance.RenderCoin();
    }

    public void EventCloseDailyRewards()
    {
        IsBackground();
        GameInterface.instance.CloseFirstLayout();
    }

    private void DayTextAnimation() 
    {
        for (int i = 0; i < DailyRewardsView.instance.textDay.Count; i++) 
        {
            DailyRewardsView.instance.textDay[i].color = new Color(0.51f,0.51f,0.51f);
            DailyRewardsView.instance.textDay[i].rectTransform.localScale = new Vector3(1f,1f,1f);
            DailyRewardsView.instance.icons[i].rectTransform.localScale = new Vector3(1f,1f,1f);
        }
        int CurrentDay = DailyRewardsModel.instance.currentDay;
        if (CurrentDay == 0) 
        {
            CurrentDay = 1;
        }
        DailyRewardsView.instance.textDay[CurrentDay -1].color = new Color(1f,1f,1f);
        DailyRewardsView.instance.textDay[CurrentDay -1].rectTransform.localScale = new Vector3(1.5f,1.5f,1.5f);
        DailyRewardsView.instance.icons[CurrentDay -1].rectTransform.localScale = new Vector3(1.5f,1.5f,1.5f);
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
