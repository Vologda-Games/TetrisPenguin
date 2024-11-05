using System.Collections.Generic;
using UnityEngine;

public class LuckWheelModel : MonoBehaviour
{
    public static LuckWheelModel instance;
    public int token;
    public int prizeCount = 6;
    public List<string> prizes;

    private void Awake()
    {
        instance = this;

        if (prizes == null || prizes.Count == 0)
        {
            prizes = new List<string>
            {
                "Красный",
                "Зелёный",
                "Синий",
                "Жёлтый",
                "Циан",
                "Пурпурный"
            };
        }
    }

    public float GetAnglePerItem()
    {
        return 360f / prizeCount;
    }

    public string GetPrize(int index)
    {
        if (index >= 0 && index < prizes.Count)
        {
            return prizes[index];
        }
        else
        {
            return "Неизвестный цвет";
        }
    }
}