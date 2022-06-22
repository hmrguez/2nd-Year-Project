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


    public static IWinnable[] GetWinnables() => new IWinnable[] { new RegularWinnable(), new DropDoubleBlank() };
    public static IShuffler[] GetShufflers() => new IShuffler[] { new RegularShuffler(), new SortedByLeftShuffler(), new ValueSortedShuffler() };
    public static IRounder[] GetRounders() => new IRounder[] { new Clockwise(), new CounterClockWise(), new SkipTurn() };
    public static Board[] GetBoards() => new Board[] { new RegularBoard(9), new DoubleEvenBoard(12) };
    public static IHandCounter[] GetHandCounters() => new IHandCounter[] { new RegularHandCounter(), new DoubleDoubleHandCounter() };
    public static IPlayer[] GetPlayers()=> new IPlayer[]{new PlayerRandom(), new PlayerMostValue(), new PlayerRandomValue(), new SemiSmartPlayer()};
    
}