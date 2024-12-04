using UnityEngine;  

public class PlayerModel : MonoBehaviour
{
    public static PlayerModel instance;
    public int level;
    public int experience;
    public int coins;

    private void Awake()
    {
        level = 1;
        coins = 0;
        experience = 0;
        instance = this;
    }
}

public class SavePlayerModel
{
    public int level;
    public int coins;
    public int experience;
}