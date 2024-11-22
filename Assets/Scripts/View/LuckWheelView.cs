using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LuckWheelView : MonoBehaviour
{
    public static LuckWheelView instance;
    private bool spinning = false;
    private bool rotation = false;
    [SerializeField] public GameObject wheel;
    [SerializeField] public GameObject request_For_Money;

    [Header("Transform")]

    [SerializeField] public RectTransform btnForMoney;

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
        request_For_Money.SetActive(false);
        LuckWheelPresenter.instance.Initialization();
        if (PlayerPrefs.GetInt("WheelSpunToday") == 1) 
        {
            request_For_Money.SetActive(true);
        }
        CanSpinToday();
    }

    public void EventTriggerBtn() 
    {
        if (!spinning && !rotation) 
        {
            if (PlayerPrefs.GetInt("WheelSpunToday") == 0 && CanSpinToday()) 
            {
                LuckWheelPresenter.instance.OnClickButton();
            }
            else 
            {
                LuckWheelPresenter.instance.ShowBtnMoney();
            }
        }

    }

    public void ClickOnButtonForMoneys() 
    {
        LuckWheelPresenter.instance.OnClickBtnMoney();
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

    public void AnimationRotation(bool isRotation) 
    {
        rotation = isRotation;
    }

}
