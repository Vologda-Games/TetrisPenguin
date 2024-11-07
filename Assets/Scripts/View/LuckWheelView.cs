using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckWheelView : MonoBehaviour
{
    public static LuckWheelView instance;
    private bool spinning = false;
    [SerializeField] public GameObject wheel;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float rotationTimeMaxSpeed;
    [SerializeField] public float accelerationTime; //время ускорения до максимальной скорости
    [SerializeField] public int numberOfSpins;

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !spinning)
        {
            if (LuckWheelPresenter.instance != null)
            {
                LuckWheelPresenter.instance.OnClickButton();
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
    }

}
