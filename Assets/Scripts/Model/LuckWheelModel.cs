using System.Collections.Generic;
using UnityEngine;

public class LuckWheelModel : MonoBehaviour
{
    public static LuckWheelModel instance;
    public int token;
    [Header("Сколько призов, то столько и секторов. Без разницы как призы называются, логика в скрипте зависит от количества призов и выдача призов тоже там же")]
    [SerializeField] public List<string> prizes;

    [SerializeField] public float rotationSpeed = 800;
    [SerializeField] public float rotationTimeMaxSpeed = 1; 
    [SerializeField] public float accelerationTime = 0.8f; //время ускорения до максимальной скорости
    [SerializeField] public int numberOfSpins = 4;

    private void Awake()
    {
        instance = this;
        
    }

    
}