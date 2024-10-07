using UnityEngine;

public class LuckWheelModel : MonoBehaviour
{
    public static LuckWheelModel instance;
    public int token;

    private void Awake()
    {
        instance = this;
    }
}