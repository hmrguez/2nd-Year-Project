namespace Domino;

public class Clockwise : IRounder
{
    public IPlayer NextPlayer(GameObject game)
    {
        int k = game.Players.ToList().FindIndex(x => x == game.CurrentPlayer);
        return k >= game.Players.Length - 1 ? game.Players[0] : game.Players[k + 1];
    }
}