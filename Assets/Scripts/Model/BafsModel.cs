using UnityEngine;

public class BafsModel : MonoBehaviour
{
    public static BafsModel instance;
    public int multicolorBafs;
    public int springBafs;
    public int bombBafs;
    public int tornadoBafs;
    public int magnetBafs;
    public int selectBaf;
    public int destroyBaf;

    private void Awake()
    {
        multicolorBafs = 10;
        springBafs = 10;
        bombBafs = 10;
        tornadoBafs = 10;
        magnetBafs = 10;
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