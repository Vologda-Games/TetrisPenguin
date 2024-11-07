using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckWheelView : MonoBehaviour
{
    public static LuckWheelView instance;
    private bool spinning = false;
    public Image[] sectors;
    public Image arrowImage;

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

    // Метод для отображения состояния вращения
    public void ShowSpinningStatus(bool isSpinning)
    {
        spinning = isSpinning;
        Debug.Log("Колесо крутится: " + isSpinning);
    }



    // Метод для вычисления сектора, на который указывает стрелка
    public void SetArrowPosition(float angle)
    {
        // Проверяем, завершилось ли вращение
        if (spinning) return;  // Если колесо ещё вращается, стрелка не меняет позицию
    }

}
