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

    public static string Parse(this string s, string par){
        string temp = $"{s[0]}";
        for (int i = 1; i < s.Length; i++)
        {

            if(char.IsUpper(s[i])) temp+=$" {s[i]}";
            else temp+=$"{s[i]}";
        }
        string[] six = temp.Split(' ');
        string[] nine = par.Split(' ');
        return string.Join(' ',six.Where(x => !nine.Contains(x))).ToString();
    }


    public static string[] GetWinnables() 
        => typeof(IShuffler)
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
        => typeof(IShuffler)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BaseRounder))
            .Select(p => p.Name)
            .ToArray();
    public static string[] GetBoards()
        => typeof(IShuffler)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(Board))
            .Select(p => p.Name)
            .OrderByDescending(p => p)
            .ToArray();
    public static string[] GetHandCounters() 
        => typeof(IShuffler)
            .Assembly
            .GetTypes()
            .Where(p => p.BaseType == typeof(BaseHandCounter))
            .Select(p => p.Name)
            .OrderByDescending(p => p)
            .ToArray();
    public static IPlayer[] GetPlayers()=> new IPlayer[]{new PlayerRandom(), new PlayerMostValue(), new PlayerRandomValue()};
    
}