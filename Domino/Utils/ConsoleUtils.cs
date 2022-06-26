namespace Domino;

public class ConsoleUtils{
    
    #region Get Stuff
    public static Board[] GetBoards() => new Board[]{new RegularBoard(), new DoubleEvenBoard()};
    public static BasePlayer[] GetPlayers() => new BasePlayer[]{new PlayerMostValue(), new PlayerRandom(), new PlayerRandomValue()};
    public static BaseShuffler[] GetShufflers() => new BaseShuffler[]{new RegularShuffler(), new SortedByLeftShuffler(), new ValueSortedShuffler()};
    public static BaseWinnable[] GetWinnables() => new BaseWinnable[]{new RegularWinnable(), new DropDoubleBlank()};
    public static BaseHandCounter[] GetHandCounters() => new BaseHandCounter[]{new RegularHandCounter(), new DoubleDoubleHandCounter()};
    public static BaseRounder[] GetRounders() => new BaseRounder[]{new Clockwise(), new CounterClockWise(), new SkipTurn()};
    #endregion
    #region Config
    public static ChangedThings GetMainConfig(){
        System.Console.WriteLine("Choose your Board");
        for (int i = 0; i < ConsoleUtils.GetBoards().Length; i++)
        {
            System.Console.WriteLine($"[{i}]{ConsoleUtils.GetBoards()[i]}");
        }
        int a = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Type t = ConsoleUtils.GetBoards()[a].GetType();
        Board board = Activator.CreateInstance(t!) as Board;

        System.Console.WriteLine("Choose your Shuffler");
        for (int i = 0; i < ConsoleUtils.GetShufflers().Length; i++)
        {
            System.Console.WriteLine($"[{i}]{ConsoleUtils.GetShufflers()[i]}");
        }
        a = int.Parse(Console.ReadLine()!);
        Type s = ConsoleUtils.GetShufflers()[a].GetType();
        Console.Clear();
        BaseShuffler shuffler = Activator.CreateInstance(s) as BaseShuffler;
        
        System.Console.WriteLine("Choose your Winnable");
        for (int i = 0; i < ConsoleUtils.GetWinnables().Length; i++)
        {
            System.Console.WriteLine($"[{i}]{ConsoleUtils.GetWinnables()[i]}");
        }
        a = int.Parse(Console.ReadLine()!);
        t = ConsoleUtils.GetWinnables()[a].GetType();
        Console.Clear();
        BaseWinnable winnable = Activator.CreateInstance(t!) as BaseWinnable;

        System.Console.WriteLine("Choose your Hand Counter");
        for (int i = 0; i < ConsoleUtils.GetHandCounters().Length; i++)
        {
            System.Console.WriteLine($"[{i}]{ConsoleUtils.GetHandCounters()[i]}");
        }
        a = int.Parse(Console.ReadLine()!);
        t = ConsoleUtils.GetHandCounters()[a].GetType();
        Console.Clear();
        BaseHandCounter handCounter = Activator.CreateInstance(t!) as BaseHandCounter;

        System.Console.WriteLine("Choose your Rounder");
        for (int i = 0; i < ConsoleUtils.GetRounders().Length; i++)
        {
            System.Console.WriteLine($"[{i}]{ConsoleUtils.GetRounders()[i]}");
        }
        a = int.Parse(Console.ReadLine()!);
        t = ConsoleUtils.GetRounders()[a].GetType();
        Console.Clear();
        BaseRounder rounder = Activator.CreateInstance(t!) as BaseRounder;

        // return new ChangedThings(board,winnable,rounder,shuffler,handCounter);
        return new ChangedThings(board,winnable, rounder, shuffler,handCounter);
    }
    public static int[] GetSideConfig(){
        int[] m = new int[3];
        System.Console.WriteLine("Choose your Board Size");
        m[0] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Choose your Hand Size");
        m[1] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Choose your amount of Players Size");
        m[2] = int.Parse(Console.ReadLine()!);
        return m;
    }
    public static BasePlayer[] GetPlayerConfig(int p){
        int k = 0;
        BasePlayer[] array = ConsoleUtils.GetPlayers();
        BasePlayer[] result = new BasePlayer[p];
        while (k<p)
        {
            System.Console.WriteLine("Choose your Player");
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.WriteLine($"[{i} {array[i]}]");
            }
            int a = int.Parse(Console.ReadLine()!);
            Type t = array[a].GetType();
            result[k] = Activator.CreateInstance(t) as BasePlayer;
            k+=1;
            Console.Clear();
        }
        return result;
    }

    #endregion
}