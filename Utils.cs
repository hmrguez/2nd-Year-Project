namespace Domino;

public static class Utils
{
    public static bool IsBlocked(IGame game)
    {
        if (game.Rounds.Count > game.Players.Length)
        {
            for (int i = 0; i < game.Players.Length; i++)
            {
                if (game.Rounds[game.Rounds.Count - i] != null) break;
                if (i == game.Players.Length - 1) return true;
            }
        }
        return false;
    }
    public static IPlayer StandardCounter(IGame game, IHandCounter HandCounter) => game.Players.MinBy(x => HandCounter.GetHandValue(x))!;


    public static IWinnable[] GetWinnables() => new IWinnable[] { new RegularWinnable(), new DropDoubleBlank() };
    public static IShuffler[] GetShufflers() => new IShuffler[] { new RegularShuffler(), new SortedShuffler() };
    public static IRounder[] GetRounders() => new IRounder[] { new Clockwise(), new CounterClockWise(), new SkipTurn() };
    public static Board[] GetBoards() => new Board[] { new RegularBoard(1), new DoubleEvenBoard(1) };
    public static IHandCounter[] GetHandCounters() => new IHandCounter[] { new RegularHandCounter(), new DoubleDoubleHandCounter() };
}