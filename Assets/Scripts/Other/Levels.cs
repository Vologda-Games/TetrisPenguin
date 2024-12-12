using UnityEngine;

public class Levels : MonoBehaviour
{
    public static Level[] levels = new Level[] {
        new Level(0, 0, 0),
        new Level(1, 4000, 400),
        new Level(2, 4199, 420),
        new Level(3, 4408, 450),
        new Level(4, 4628, 472),
        new Level(5, 4859, 495),
        new Level(6, 5101, 520),
        new Level(7, 5356, 546),
        new Level(8, 5623, 580),
        new Level(9, 5904, 600),
        new Level(10, 6199, 632),
        new Level(11, 6508, 663),
        new Level(12, 6833, 700),
        new Level(13, 7174, 730),
        new Level(14, 7532, 766),
        new Level(15, 7908, 810),
        new Level(16, 8303, 849),
        new Level(17, 8178, 893),
        new Level(18, 9153, 941),
        new Level(19, 9610, 979),
        new Level(20, 10090, 1031),
        new Level(21, 10594, 1082),
        new Level(22, 11123, 1130),
        new Level(23, 11679, 1194),
        new Level(24, 12262, 1251),
        new Level(25, 12875, 1315),
        new Level(26, 13518, 1377),
        new Level(27, 14193, 1446),
        new Level(28, 14902, 1519),
        new Level(29, 15647, 1599),
        new Level(30, 16429, 1670),
        new Level(31, 17250, 1751),
        new Level(32, 18112, 1837),
        new Level(33, 19017, 1930),
        new Level(34, 20965, 2025),
        new Level(35, 22013, 2129),
        new Level(36, 23113, 2238),
        new Level(37, 24268, 2350),
        new Level(38, 25481, 2461),
        new Level(39, 26755, 2590),
        new Level(40, 28092, 2720),
        new Level(41, 29496, 2887),
        new Level(42, 30970, 3000),
        new Level(43, 32518, 3159),
        new Level(44, 34143, 3323),
        new Level(45, 35850, 3510),
        new Level(46, 37642, 3750),
        new Level(47, 39524, 3956),
        new Level(48, 41500, 4109),
        new Level(49, 43574, 4302),
        new Level(50, 45753, 4800)
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