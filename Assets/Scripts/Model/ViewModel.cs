using UnityEngine;

public class ViewModel : MonoBehaviour
{
    public static ViewModel instance;

    [SerializeField] public GameObject shop;

    private void Awake()
    {
        instance = this;
    }
}