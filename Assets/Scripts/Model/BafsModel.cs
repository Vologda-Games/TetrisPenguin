using UnityEngine;

public class BafsModel : MonoBehaviour
{
    public static BafsModel instance;
    [HideInInspector] public int multicolorBafs;
    [HideInInspector] public int springBafs;
    [HideInInspector] public int bombBafs;
    [HideInInspector] public int tornadoBafs;
    [HideInInspector] public int magnetBafs;
    [HideInInspector] public int selectBaf;
    [HideInInspector] public int destroyBaf;

    private void Awake()
    {
        multicolorBafs = 5;
        springBafs = 5;
        bombBafs = 5;
        tornadoBafs = 5;
        magnetBafs = 5;
        instance = this;
    }
}

public class SaveBafsModel
{
    public int multicolorBafs;
    public int springBafs;
    public int bombBafs;
    public int tornadoBafs;
    public int magnetBafs;
}