using System.Collections.Generic;

public static class LibraryWords
{
    public static Localization language = new Localization("Русский", "English", "Français", "Italiano", "Deutsch", "Español", "中文", "Português", "한국어", "日本語", "Türk", "العربية", "हिन्दी", "Indonesian", "Polski", "Svensk");
    public static Localization music = new Localization("Музыка", "Music", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка", "Музыка");
    public static Localization sounds = new Localization("Звуки", "Sounds", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки", "Звуки");
    public static Localization preciseControl = new Localization("Точное управление", "Precise Control", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление", "Точное управление");
    public static Localization flexibleManagement = new Localization("Гибкое управление", "Flexible Management", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление", "Гибкое управление");
    public static Localization startOver = new Localization("Начать заново", "Start over", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново", "Начать заново");
    public static Localization reatings = new Localization("Рейтинги", "Reatings", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги", "Рейтинги");
    public static Localization shop = new Localization("Магазин", "Shop", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин", "Магазин");
    public static Localization level = new Localization("Уровень", "Level", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень", "Уровень");
    public static Localization dailyTasks = new Localization("Ежедневные Задания", "Daily Tasks", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания", "Ежедневные Задания");
    public static Localization dailyRewards = new Localization("Ежедневные Награды", "Daily Rewards", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды", "Ежедневные Награды");
    public static Localization wheelOfLuck = new Localization("Колесо Удачи", "The Wheel of Luck", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи", "Колесо Удачи");
    public static Localization penguinTable = new Localization("Таблица Пингвинов", "The Penguin Table", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов", "Таблица Пингвинов");
    public static Localization updatingVia = new Localization("Обновится через", "It will be updated after", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через", "Обновится через");
    public static List<Localization> createPenguinTask = new List<Localization>()
    {
        new Localization("Создать пингвина первого уровня", "Create a first-level penguin", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня", "Создать пингвина первого уровня"),
        new Localization("Создать пингвина второго уровня", "Create a second-level penguin", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня", "Создать пингвина второго уровня"),
        new Localization("Создать пингвина третьего уровня", "Create a third-level penguin", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня", "Создать пингвина третьего уровня"),
        new Localization("Создать пингвина четвёртого уровня", "Create a fourth-level penguin", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня", "Создать пингвина четвёртого уровня"),
        new Localization("Создать пингвина пятого уровня", "Create a fifth-level penguin", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня", "Создать пингвина пятого уровня"),
        new Localization("Создать пингвина шестого уровня", "Create a penguin of the sixth level", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня", "Создать пингвина шестого уровня"),
        new Localization("Создать пингвина седьмого уровня", "Create a seventh-level penguin", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня", "Создать пингвина седьмого уровня"),
        new Localization("Создать пингвина восьмого уровня", "Create a penguin of the eighth level", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня", "Создать пингвина восьмого уровня"),
        new Localization("Создать пингвина девятого уровня", "Create a level nine penguin", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня", "Создать пингвина девятого уровня"),
        new Localization("Создать пингвина десятого уровня", "Create a level ten penguin", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня", "Создать пингвина десятого уровня"),
        new Localization("Создать пингвина одиннадцатого уровня", "Create a penguin of the eleventh level", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня", "Создать пингвина одиннадцатого уровня"),
        new Localization("Создать пингвина двенадцатого уровня", "Create a level twelve penguin", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня", "Создать пингвина двенадцатого уровня"),
        new Localization("Создать пингвина тринадцатого уровня", "Create a penguin of the thirteenth level", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня", "Создать пингвина тринадцатого уровня"),
        new Localization("Создать пингвина четырнадцатого уровня", "Create a level fourteen penguin", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня", "Создать пингвина четырнадцатого уровня"),
        new Localization("Создать пингвина пятнадцатого уровня", "Create a penguin of the fifteenth level", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня", "Создать пингвина пятнадцатого уровня"),
    };
    public static List<Localization> useBaffTask = new List<Localization>()
    {
            new Localization("Использовать усилитель \"мультимингвин\"", "Use the \"multi-penguin\" amplifier", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\"", "Использовать усилитель \"мультимингвин\""),
            new Localization("Использовать усилитель \"супер удар\"", "Use the \"super kick\" amplifier", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\"", "Использовать усилитель \"супер удар\""),
            new Localization("Использовать усилитель \"бомба\"", "Use the \"bomb\" amplifier", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\"", "Использовать усилитель \"бомба\""),
            new Localization("Использовать усилитель \"ураган\"", "Use the \"hurricane\" amplifier", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\"", "Использовать усилитель \"ураган\""),
            new Localization("Использовать усилитель \"магнит\"", "Use an amplifier \"magnet\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\"", "Использовать усилитель \"магнит\""),
    };
    public static Localization clickTask = new Localization("Кликнуть на экран, при создании пингвинов", "Click on the screen when creating penguins", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов", "Кликнуть на экран, при создании пингвинов");
    public static Localization buy = new Localization("Купить", "Buy", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить", "Купить");
    public static Localization spin = new Localization("Крутить", "Spin", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить", "Крутить");
    public static Localization get = new Localization("Получить", "Get", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить", "Получить");
    public static Localization collect = new Localization("Собрать", "Collect", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать", "Собрать");
    public static Localization collected = new Localization("Собрано", "Collected", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано", "Собрано");
    public static Localization you = new Localization("Вы", "You", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы", "Вы");
    public static Localization buyAttempt = new Localization("Купить попытку", "Buy an attempt", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку", "Купить попытку");
    public static Localization loginToGame = new Localization("Заходи в игру каждый день, чтобы получать награды!", "Log in to the game every day to get rewards!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!", "Заходи в игру каждый день, чтобы получать награды!");
}