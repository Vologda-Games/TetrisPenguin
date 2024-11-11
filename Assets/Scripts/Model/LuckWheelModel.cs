using System.Collections.Generic;
using UnityEngine;

public class LuckWheelModel : MonoBehaviour
{
    public static LuckWheelModel instance;
    public int token;
    [SerializeField] public List<string> prizes;

    [SerializeField] public float rotationSpeed;
    [SerializeField] public float rotationTimeMaxSpeed; 
    [SerializeField] public float accelerationTime; //время ускорения до максимальной скорости
    [SerializeField] public int numberOfSpins;

    private void Awake()
    {
        instance = this;

    }
}