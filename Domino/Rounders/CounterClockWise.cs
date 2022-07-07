namespace Domino;

public class CounterClockWise : IRounder
{
    public IPlayer NextPlayer(GameObject game)
    {
        int k = game.Players.ToList().FindIndex(x => x == game.CurrentPlayer);
        return k <= 0 ? game.Players[game.Players.Length - 1] : game.Players[k - 1];
    }
}