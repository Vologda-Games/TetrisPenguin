using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckWheelView : MonoBehaviour
{
    public static LuckWheelView instance;
    private bool spinning = false;
    [SerializeField] public GameObject wheel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        LuckWheelPresenter.instance.Initialization();
        // if (PlayerPrefs.HasKey("WheelSpunToday")) 
        // {
        //     PlayerPrefs.DeleteKey("WheelSpunToday");
        // }
        CanSpinToday();
    }

    public void EventTriggerBtn() 
    {
        if (!spinning && PlayerPrefs.GetInt("WheelSpunToday") == 0 && CanSpinToday()) 
        {
            LuckWheelPresenter.instance.OnClickButton();
            PlayerPrefs.SetInt("WheelSpunToday", 1);
            PlayerPrefs.SetString("LastSpinDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
        }
        else 
        {
            string lastSpinDate = PlayerPrefs.GetString("LastSpinDate");
            Debug.Log($"Сегодня вы уже крутили один раз, последняя попытка: {lastSpinDate}");
        }
    }

    private bool CanSpinToday() 
    {
        string lastSpinDate = PlayerPrefs.GetString("LastSpinDate", "");

        if (string.IsNullOrEmpty(lastSpinDate)) 
        {
            return true;
        }

        DateTime lastSpin;
        if (DateTime.TryParse(lastSpinDate, out lastSpin)) 
        {
            if (lastSpin.Date < DateTime.Today) 
            {
                PlayerPrefs.SetInt("WheelSpunToday", 0);
                return true;
            }
        }

        return PlayerPrefs.GetInt("WheelSpinToday") == 0;
    }

    // Метод для отображения состояния вращения
    public void ShowSpinningStatus(bool isSpinning)
    {
        spinning = isSpinning;
    }

}
