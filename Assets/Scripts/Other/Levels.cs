using UnityEngine;

public class Levels : MonoBehaviour
{
    public static Level[] levels = new Level[] {
        new Level(0, 0),
        new Level(1, 1000),
        new Level(2, 2000),
        new Level(3, 3000),
        new Level(4, 4000),
        new Level(5, 5000),
        new Level(6, 6000),
        new Level(7, 7000),
        new Level(8, 8000),
        new Level(9, 9000),
        new Level(10, 10000),
        new Level(11, 11000),
        new Level(12, 12000),
        new Level(13, 13000),
    };

    public static int CurrentLevel
    {
        get
        {
            int level = PlayerPrefs.GetInt("level");
            return level;
        }
        set
        {
            PlayerPrefs.SetInt("level", value);
        }
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("level")) PlayerPrefs.SetInt("level", 1);
    }
}

public class Level
{
    public int level;
    public int experience;

    public Level(int level, int experience)
    {
        this.level = level;
        this.experience = experience;
    }
}