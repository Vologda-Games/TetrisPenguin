using System;
using UnityEngine;

public class LuckWheelView : MonoBehaviour
{
    public static LuckWheelView instance;
    private bool spinning = false;
    private bool rotation = false;
    private bool isScale = false;
    [SerializeField] public GameObject wheel;
    [SerializeField] public GameObject TextSpin;
    [SerializeField] public GameObject ImageCoinAndTextPrice;

    [Header("Transform")]

    [SerializeField] public RectTransform spinButton;
    [SerializeField] public RectTransform ImageCoinAndTextPriceRectTransform;
    [SerializeField] public RectTransform TextSpinRectTranform;



    [HideInInspector] public int _priceAttempt = 750;
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
        ImageCoinAndTextPrice.SetActive(false);
        TextSpin.SetActive(true);
        LuckWheelPresenter.instance.Initialization();
        //if (PlayerPrefs.GetInt("WheelSpunToday") == 1)
        if (LuckWheelModel.instance.wheelSpunToday == 1)
        {
            ImageCoinAndTextPrice.SetActive(true);
            TextSpin.SetActive(false);
        }
        CanSpinToday();
    }

    public void EventTriggerBtn() 
    {
        if (!spinning && !rotation && !isScale) 
        {
            //if (PlayerPrefs.GetInt("WheelSpunToday") == 0 && CanSpinToday())
            if (LuckWheelModel.instance.wheelSpunToday == 0 && CanSpinToday()) 
            {
                LuckWheelPresenter.instance.OnClickButton();
            }
            else 
            {
                LuckWheelPresenter.instance.OnClickBtnMoney();
            }
        }

    }

    private bool CanSpinToday() 
    {
        Debug.Log("Нажатие");
        //string lastSpinDate = PlayerPrefs.GetString("LastSpinDate", "");
        string lastSpinDate = LuckWheelModel.instance.lastSpinDate;

        if (string.IsNullOrEmpty(lastSpinDate))
        {
            return true;
        }

        DateTime lastSpin;
        if (DateTime.TryParse(lastSpinDate, out lastSpin)) 
        {
            if (lastSpin.Date < DateTime.Today) 
            {
                //PlayerPrefs.SetInt("WheelSpunToday", 0);
                LuckWheelModel.instance.wheelSpunToday = 0;
                return true;
            }
        }
        //Debug.Log(PlayerPrefs.GetInt("WheelSpunToday"));
        //return PlayerPrefs.GetInt("WheelSpinToday") == 0;
        return LuckWheelModel.instance.wheelSpunToday == 0;
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

    public void AnimScaleButtonSpin(bool isScale) 
    {
        this.isScale = isScale;
    }

}
