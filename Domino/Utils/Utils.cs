namespace Domino;

public static class Utils
{
    public static bool IsBlocked(GameObject game)
    {
        if (game.Rounds.Count > game.Players.Length)
        {
            for (int i = 0; i < game.Players.Length; i++)
            {
                if (game.Rounds[(game.Rounds.Count -1) - i].Piece != null) break;
                if (i == game.Players.Length - 1) return true;
            }
        }
        return false;
    }
    public static IPlayer StandardCounter(GameObject game, IHandCounter HandCounter) => game.Players.MinBy(x => HandCounter.GetHandValue(x))!;

    public static string[] GetWinnables() 
        => typeof(IWinnable)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BaseWinnable))
            .Select(p => p.Name)
            .OrderByDescending(p => p)
            .ToArray();
    public static string[] GetShufflers() 
        => typeof(IShuffler)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BaseShuffler))
            .Select(p => p.Name)
            .ToArray();
    public static string[] GetRounders() 
        => typeof(IRounder)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BaseRounder))
            .Select(p => p.Name)
            .ToArray();
    public static string[] GetBoards()
        => typeof(Board)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(Board))
            .Select(p => p.Name)
            .OrderByDescending(p => p)
            .ToArray();
    public static string[] GetHandCounters() 
        => typeof(IHandCounter)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BaseHandCounter))
            .Select(p => p.Name)
            .OrderByDescending(p => p)
            .ToArray();
    public static string[] GetPlayers()
        => typeof(IPlayer)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType ==  typeof(BasePlayer))
            .Select(p => p.Name)
            .ToArray(); 

    //public static IPlayer[] GetPlayers() => new IPlayer[]{new PlayerRandom(), new PlayerMostValue(), new PlayerRandomValue()};
    
}