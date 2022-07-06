using Domino;

public class ConsoleUtils
{
    public static ChangedThings GetMainConfig()
    {
        System.Console.WriteLine("Choose your Board");

        for (int i = 0; i < Utils.GetBoards().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetBoards()[i]}");
        }
        int x = int.Parse(Console.ReadLine()!);
        var y = typeof(Board).Assembly.GetTypes().First(t => t.Name == Utils.GetBoards()[x]);
        var a = Activator.CreateInstance(y) as Board;

        Console.Clear();

        System.Console.WriteLine("Choose your Shuffler");

        for (int i = 0; i < Utils.GetShufflers().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetShufflers()[i]}");
        }
        x = int.Parse(Console.ReadLine()!);
        y = typeof(BaseShuffler).Assembly.GetTypes().First(t => t.Name == Utils.GetShufflers()[x]);
        var b = Activator.CreateInstance(y) as BaseShuffler;

        Console.Clear();

        System.Console.WriteLine("Choose your Winnable");

        for (int i = 0; i < Utils.GetWinnables().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetWinnables()[i]}");
        }
        x = int.Parse(Console.ReadLine()!);
        y = typeof(BaseWinnable).Assembly.GetTypes().First(t => t.Name == Utils.GetWinnables()[x]);
        var c = Activator.CreateInstance(y) as BaseWinnable;

        Console.Clear();

        System.Console.WriteLine("Choose your Hand Counter");

        for (int i = 0; i < Utils.GetHandCounters().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetHandCounters()[i]}");
        }
        x = int.Parse(Console.ReadLine()!);
        y = typeof(BaseHandCounter).Assembly.GetTypes().First(t => t.Name == Utils.GetHandCounters()[x]);
        var d = Activator.CreateInstance(y) as BaseHandCounter;

        Console.Clear();

        System.Console.WriteLine("Choose your Rounder");

        for (int i = 0; i < Utils.GetRounders().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetRounders()[i]}");
        }
        x = int.Parse(Console.ReadLine()!);
        y = typeof(BaseRounder).Assembly.GetTypes().First(t => t.Name == Utils.GetRounders()[x]);
        var e = Activator.CreateInstance(y) as BaseRounder;

        Console.Clear();

        return new ChangedThings(a!, c!, e!, b!, d!);
    }
    public static int[] GetSideConfig()
    {
        int[] m = new int[3];
        System.Console.WriteLine("Choose your Board Size");
        m[0] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Choose your Hand Size");
        m[1] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Choose your amount of Players Size");
        m[2] = int.Parse(Console.ReadLine()!);
        Console.Clear();
        return m;
    }
    public static BasePlayer[] GetPlayerConfig(int p)
    {
        int k = 0;
        BasePlayer[] result = new BasePlayer[p];
        while (k < p)
        {
            System.Console.WriteLine("Choose your Player");
            for (int i = 0; i < Utils.GetPlayers().Length; i++)
            {
                System.Console.WriteLine($"[{i}] {Utils.GetPlayers()[i]}");
            }
            int a = int.Parse(Console.ReadLine()!);
            Type? t = typeof(BasePlayer).Assembly.GetTypes().First(x => x.Name == Utils.GetPlayers()[a]);
            BasePlayer? b = Activator.CreateInstance(t) as BasePlayer;
            result[k] = b!;
            k += 1;
            Console.Clear();
        }
        return result;
    }
}