namespace Domino;

public class Clockwise : IRounder
{
    public IPlayer NextPlayer(IGame game)
    {
        int k = game.Players.ToList().FindIndex(x => x == game.CurrentPlayer);
        return k >= game.Players.Length - 1 ? game.Players[0] : game.Players[k + 1];
    }
    public override string ToString()
    {
        return "Clockwise";
    }
}
public class CounterClockWise : IRounder
{
    public IPlayer NextPlayer(IGame game)
    {
        int k = game.Players.ToList().FindIndex(x => x == game.CurrentPlayer);
        return k <= 0 ? game.Players[game.Players.Length - 1] : game.Players[k - 1];
    }
    public override string ToString()
    {
        return "Counter-clockwise";
    }
}
public class SkipTurn : IRounder
{
    public override string ToString()
    {
        return "Skip Turn";
    }
    public IPlayer NextPlayer(IGame game) => game.Rounds.Last().Piece == null ? new CounterClockWise().NextPlayer(game) : new Clockwise().NextPlayer(game);
}