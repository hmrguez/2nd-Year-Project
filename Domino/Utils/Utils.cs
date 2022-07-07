namespace Domino;

public static class Utils
{
    static string[] Names = new string[] { "MartaBot", "TobiasBot", "FranciscoBot", "VladBot", "HectorBot", "AlejandroBot", 
    "KarenBot", "LuisBot", "JavierBot", "PennyBot", "SheldonBot", "LeonardBot", "RajBot", "HowardBot", "AmyBot", "LynnBot",
    "RaulBot", "SaulBot" , "DimitriBot", "NikolaBot", "AmandaBot", "CamilaBot", "CatherinBot"};
    public static bool IsBlocked(GameObject game)
    {
        if (game.Rounds.Count > game.Players.Length)
        {
            for (int i = 0; i < game.Players.Length; i++)
            {
                if (game.Rounds[(game.Rounds.Count - 1) - i].Piece != null) break;
                if (i == game.Players.Length - 1) return true;
            }
        }
        return false;
    }
    public static IPlayer StandardCounter(GameObject game, IHandCounter HandCounter) => game.Players.MinBy(x => HandCounter.GetHandValue(x))!;

    public static string GetName()
    {
        Random r = new Random();
        int x = r.Next(0, Names.Length);
        return Names[x];
    }


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
            .Where(p => typeof(IShuffler).IsAssignableFrom(p) && p.IsClass)
            .Select(p => p.Name)
            .ToArray();
    public static string[] GetRounders()
        => typeof(IRounder)
            .Assembly
            .GetTypes()
            .Where(p => typeof(IRounder).IsAssignableFrom(p) && p.IsClass)
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
            .Where(p => typeof(IHandCounter).IsAssignableFrom(p) && p.IsClass)
            .Select(p => p.Name)
            .OrderByDescending(p => p)
            .ToArray();
    public static string[] GetPlayers()
        => typeof(IPlayer)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BasePlayer))
            .Select(p => p.Name)
            .ToArray();

}