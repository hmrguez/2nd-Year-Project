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

    public static int SumaDomino(int x)
    {
        if (x == 0) return 1;
        return x + 1 + SumaDomino(x - 1);
    }

    public static string GetName()
    {
        Random r = new Random();
        int x = r.Next(0, Names.Length);
        return Names[x];
    }

    public static string[] GetT(Type x)
        => x.Assembly
        .GetTypes()
        .Where(p => x.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
        .Select(p => p.Name)
        .ToArray();
}