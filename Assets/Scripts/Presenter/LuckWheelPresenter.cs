using UnityEngine;

public class LuckWheelPresenter : MonoBehaviour
{
    public static int GetTokens()
    {
        return LuckWheelModel.instance.token;
    }

    public static void AddToken(int value)
    {
        LuckWheelModel.instance.token += value;
    }
}