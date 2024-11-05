using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckWheelView : MonoBehaviour
{
    public static LuckWheelView instance;
    private bool spinning = false;
    public Transform arrow;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !spinning)
        {
            if (LuckWheelPresenter.instance != null)
            {
                LuckWheelPresenter.instance.OnSpinButtonPressed();
            }
            else
            {
                Debug.LogError("LuckWheelPresenter instance is not set.");
            }
        }
    }

    public void ShowSpinningStatus(bool isSpinning)
    {
        spinning = isSpinning;
        Debug.Log("Колесо крутится: " + isSpinning);
    }

    public void SetArrowPosition(float angle) 
    {
        Debug.Log("Стрелка указывает на сектор с углом: " + angle);
    }
}
