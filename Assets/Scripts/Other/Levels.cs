using UnityEngine;

public class Levels : MonoBehaviour
{
    public static Level[] levels = new Level[] {
        new Level(0, 0, 0),
        new Level(1, 2000, 400),
        new Level(2, 2099, 420),
        new Level(3, 2204, 450),
        new Level(4, 2314, 472),
        new Level(5, 2430, 495),
        new Level(6, 2550, 520),
        new Level(7, 2678, 546),
        new Level(8, 2812, 580),
        new Level(9, 2952, 600),
        new Level(10, 3100, 632),
        new Level(11, 3254, 663),
        new Level(12, 3417, 700),
        new Level(13, 3587, 730),
        new Level(14, 3766, 766),
        new Level(15, 3954, 810),
        new Level(16, 4089, 849),
        new Level(17, 4154, 893),
        new Level(18, 4576, 941),
        new Level(19, 4805, 979),
        new Level(20, 5045, 1031),
        new Level(21, 5297, 1082),
        new Level(22, 5560, 1130),
        new Level(23, 5840, 1194),
        new Level(24, 6131, 1251),
        new Level(25, 6438, 1315),
        new Level(26, 6759, 1377),
        new Level(27, 7096, 1446),
        new Level(28, 7451, 1519),
        new Level(29, 7824, 1599),
        new Level(30, 8214, 1670),
        new Level(31, 8625, 1751),
        new Level(32, 9056, 1837),
        new Level(33, 9510, 1930),
        new Level(34, 10482, 2025),
        new Level(35, 11006, 2129),
        new Level(36, 11556, 2238),
        new Level(37, 12134, 2350),
        new Level(38, 12740, 2461),
        new Level(39, 13380, 2590),
        new Level(40, 14046, 2720),
        new Level(41, 14748, 2887),
        new Level(42, 15485, 3000),
        new Level(43, 16259, 3159),
        new Level(44, 17071, 3323),
        new Level(45, 17925, 3510),
        new Level(46, 18824, 3750),
        new Level(47, 39524, 3956),
        new Level(48, 19767, 4109),
        new Level(49, 21787, 4302),
        new Level(50, 22876, 4800)
    };

    public static int CurrentLevel
    {
        get
        {
            return PlayerModel.instance.level;
        }
        set
        {
            PlayerModel.instance.level = value;
            DataPresenter.SavePlayerModel();
        }
    }
}

public class Level
{
    public int level;
    public int experience;
    public int coins;

    public Level(int level, int experience, int coins)
    {
        this.level = level;
        this.experience = experience;
        this.coins = coins;
    }
}