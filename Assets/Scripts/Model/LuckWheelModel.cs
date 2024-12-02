using System.Collections.Generic;
using UnityEngine;

public class LuckWheelModel : MonoBehaviour
{
    public static LuckWheelModel instance;

    [Header("Сколько призов, то столько и секторов. Без разницы как призы называются, логика в скрипте зависит от количества призов и выдача призов тоже там же")]
    public List<int> prizes;

    public float rotationSpeed = 800;
    public float rotationTimeMaxSpeed = 1; 
    public float accelerationTime = 0.8f; //время ускорения до максимальной скорости
    public int numberOfSpins = 4;
    public int isUpScale = 0;
    public int wheelSpunToday = 0;
    public string lastSpinDate;
    private void Awake()
    {
        rotationSpeed = 700;
        rotationTimeMaxSpeed = 0.6f;
        accelerationTime = 0.4f;
        numberOfSpins = 3;
        isUpScale = 0;
        wheelSpunToday = 1;
        prizes = new List<int>()
        {
            300,
            2,
            2,
            550,
            2,
            2,
            900,
            2
        };
        instance = this;
        
    }

    
}
public class SaveLuckWheelModel 
{
    public int isUpScale;
    public int wheelSpunToday;
    public string lastSpinDate;
}