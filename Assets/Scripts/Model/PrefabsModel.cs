using UnityEngine;

public class PrefabsModel : MonoBehaviour
{
    public static PrefabsModel instance;
    public GameObject[] penguins;

    private void Awake()
    {
        instance = this;
    }
}