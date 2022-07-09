namespace Domino;

public static class Utils
{
    static string[] Names = new string[] { "MartaBot", "TobiasBot", "FranciscoBot", "VladBot", "HectorBot", "AlejandroBot",
    "KarenBot", "LuisBot", "JavierBot", "PennyBot", "SheldonBot", "LeonardBot", "RajBot", "HowardBot", "AmyBot", "LynnBot",
    "RaulBot", "SaulBot" , "DimitriBot", "NikolaBot", "AmandaBot", "CamilaBot", "CatherinBot", "EdwardBot", "AlbertoBot"};
    public static bool IsBlocked(GameObject game)
    {
        if (game.Rounds.Count > game.Players.Length)
        {
            foreach (var item in game.Rounds.TakeLast(game.Players.Length)) if(item.Piece!=null) return false;
            return true;
        }
        return false;
    }

    ///<returns>El jugador con menor Score en la mano</returns>
    public static IPlayer StandardCounter(GameObject game) => game.Players.MinBy(x => game.Settings.HandCounter.GetHandValue(x))!;

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
    ///<returns>El nombre de todos los elementos que hereden de una clase o interfaz mientras no sean clases abstractas o interfaces</returns>
    public static string[] GetT(Type x)
        => x.Assembly
        .GetTypes()
        .Where(p => x.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
        .Select(p => p.Name)
        .ToArray();
}