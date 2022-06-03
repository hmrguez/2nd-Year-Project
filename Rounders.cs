public class Clockwise : IRounder
{
    public IPlayer NextPlayer(IGame game)
    {
        int k = 0;
        IPlayer name = game.Rounds.Last().Player;
        for (int i = 0; i < game.Players.Length; i++)
        {
            if (name == game.Players[i]) k = i;
        }
        return k >= game.Players.Length - 1 ? game.Players[0] : game.Players[k + 1];
    }
}
public class CounterClockWise : IRounder
{
    public IPlayer NextPlayer(IGame game)
    {
        int k = 0;
        IPlayer name = game.Rounds.Last().Player;
        for (int i = 0; i < game.Players.Length; i++)
        {
            if (name == game.Players[i]) k = i;
        }
        return k <= 0 ? game.Players[game.Players.Length - 1] : game.Players[k - 1];
    }
}
public class SkipTurn : IRounder
{
    public IPlayer NextPlayer(IGame game)
    {
        return game.Rounds.Last().Piece == null ? new CounterClockWise().NextPlayer(game) : new Clockwise().NextPlayer(game);
    }
}