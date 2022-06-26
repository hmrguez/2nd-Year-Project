namespace Domino;

public class ConsoleUtils{
    public static Board[] GetBoards() => new Board[]{new RegularBoard(), new DoubleEvenBoard()};
    public static BasePlayer[] GetPlayers() => new BasePlayer[]{new PlayerMostValue(), new PlayerRandom(), new PlayerRandomValue()};
    public static BaseShuffler[] GetShufflers() => new BaseShuffler[]{new RegularShuffler(), new SortedByLeftShuffler()};
    public static BaseWinnable[] GetWinnables() => new BaseWinnable[]{new RegularWinnable(), new DropDoubleBlank()};
    public static BaseHandCounter[] GetHandCounters() => new BaseHandCounter[]{new RegularHandCounter(), new DoubleDoubleHandCounter()};
    public static BaseRounder[] GetRounders() => new BaseRounder[]{new Clockwise(), new CounterClockWise(), new SkipTurn()};
}