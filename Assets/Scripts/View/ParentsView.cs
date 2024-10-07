using UnityEngine;

public class ParentsView : MonoBehaviour
{
    public static ParentsView instance;
    public Transform penguinsParent;

    private void Awake()
    {
        instance = this;
    }
}
