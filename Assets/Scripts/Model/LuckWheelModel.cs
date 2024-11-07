using System.Collections.Generic;
using UnityEngine;

public class LuckWheelModel : MonoBehaviour
{
    public static LuckWheelModel instance;
    public int token;
    [SerializeField] public List<string> prizes;

    private void Awake()
    {
        instance = this;

    }
}