public class PlayerPresenter
{
    public static void AddCoin(int value)
    {
        PlayerModel.instance.coins += value;
        CheckLevel();
        PlayerView.instance.RenderCoin();
    }

    public static void AddLevel()
    {
        PlayerModel.instance.level++;
        PlayerView.instance.RenderLevel();
    }

    public static void ReduceCoin(int value)
    {
        PlayerModel.instance.coins -= value;
        CheckLevel();
        PlayerView.instance.RenderCoin();
    }

    public static void CheckLevel()
    {
        if (PlayerModel.instance.coins >= Levels.levels[PlayerModel.instance.level].experience)
        {
            PlayerModel.instance.coins -= Levels.levels[PlayerModel.instance.level].experience;
            AddLevel();
        }
    }
}