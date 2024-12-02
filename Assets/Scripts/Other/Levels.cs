using UnityEngine;

public class Levels : MonoBehaviour
{
    public static Level[] levels = new Level[] {
        new Level(0, 0),
        new Level(1, 4000),
        new Level(2, 4199),
        new Level(3, 4408),
        new Level(4, 4628),
        new Level(5, 4859),
        new Level(6, 5101),
        new Level(7, 5356),
        new Level(8, 5623),
        new Level(9, 5904),
        new Level(10, 6199),
        new Level(11, 6508),
        new Level(12, 6833),
        new Level(13, 7174),
        new Level(14, 7532),
        new Level(15, 7908),
        new Level(16, 8303),
        new Level(17, 8178),
        new Level(18, 9153),
        new Level(19, 9610),
        new Level(20, 10090),
        new Level(21, 10594),
        new Level(22, 11123),
        new Level(23, 11679),
        new Level(24, 12262),
        new Level(25, 12875),
        new Level(26, 13518),
        new Level(27, 14193),
        new Level(28, 14902),
        new Level(29, 15647),
        new Level(30, 16429),
        new Level(31, 17250),
        new Level(32, 18112),
        new Level(33, 19017),
        new Level(34, 20965),
        new Level(35, 22013),
        new Level(36, 23113),
        new Level(37, 24268),
        new Level(38, 25481),
        new Level(39, 26755),
        new Level(40, 28092),
        new Level(41, 29496),
        new Level(42, 30970),
        new Level(43, 32518),
        new Level(44, 34143),
        new Level(45, 35850),
        new Level(46, 37642),
        new Level(47, 39524),
        new Level(48, 41500),
        new Level(49, 43574),
        new Level(50, 45753)
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

    public Level(int level, int experience)
    {
        this.level = level;
        this.experience = experience;
    }
}