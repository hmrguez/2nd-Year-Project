using Domino;


public class Program{
    public static void Main(){
        var shuffler = new RegularShuffler();
        var board = new RegularBoard(9);
        var handcounter = new RegularHandCounter();
        var winnable = new DropDoubleBlank();
        var rounder = new CounterClockWise();
        IPlayer[] players = new IPlayer[] { new PlayerMostValue(), new PlayerMostValue(), new PlayerMostValue(), new PlayerRandom() };


        ChangedThings settings = new ChangedThings(board, winnable, rounder, shuffler, handcounter);
        var game = new GameObject(10, players, settings, 12);
        game.Play();

        // System.Console.WriteLine(game.Winner);
        // System.Console.WriteLine(string.Join(" ", game.Changes.Board.PiecesOnBoard));
    }
    // public static ChangedThings GetMainConfig(){
    //     System.Console.WriteLine("Choose your Board");
    //     for (int i = 0; i < ConsoleUtils.GetBoards().Length; i++)
    //     {
    //         System.Console.WriteLine($"[0]{ConsoleUtils.GetBoards()[0]}");
    //     }
    //     int a = int.Parse(Console.ReadLine()!);
    //     Type t = ConsoleUtils.GetBoards()[1].GetType();
    //     Board board = Activator.CreateInstance(t!) as Board;
    // }
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
        while (k++<p)
        {
            System.Console.WriteLine("Choose your Player");
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.WriteLine($"[{i} {array[i]}]");
            }
            int a = int.Parse(Console.ReadLine()!);
            Type t = array[a].GetType();
            result[k] = Activator.CreateInstance(t) as BasePlayer;
        }
        return result;
    }
}

