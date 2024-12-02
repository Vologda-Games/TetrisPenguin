using System;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    public static event Action updateEXPEvent;
    public static void UpdateEXP()
    {
        updateEXPEvent?.Invoke();
    }
}