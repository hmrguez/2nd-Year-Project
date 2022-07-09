using Domino;

public class ConsoleUtils
{
    ///<summary>Consigue la propiedad ChangedThings del juego</summary>
    public static Settings GetMainConfig()
    {
        System.Console.WriteLine("Choose your Board");

        for (int i = 0; i < Utils.GetBoards().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetBoards()[i]}");
        }

        //Se le da a escoger al usuario un número en pantalla para que sea el tablero que quiera
        //Se guarda ese número y se coge el string que está en el array en ese índice
        //Se usa reflection para crear una instancia del primer elemento que tenga ese por nombre
        //Lo mismo se hace con el resto de módulos

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
        y = typeof(IShuffler).Assembly.GetTypes().First(t => t.Name == Utils.GetShufflers()[x]);
        var b = Activator.CreateInstance(y) as IShuffler;

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
        y = typeof(IHandCounter).Assembly.GetTypes().First(t => t.Name == Utils.GetHandCounters()[x]);
        var d = Activator.CreateInstance(y) as IHandCounter;

        Console.Clear();

        System.Console.WriteLine("Choose your Rounder");

        for (int i = 0; i < Utils.GetRounders().Length; i++)
        {
            System.Console.WriteLine($"[{i}] {Utils.GetRounders()[i]}");
        }
        x = int.Parse(Console.ReadLine()!);
        y = typeof(IRounder).Assembly.GetTypes().First(t => t.Name == Utils.GetRounders()[x]);
        var e = Activator.CreateInstance(y) as IRounder;

        Console.Clear();

        //Se devuelve un objeto de ChangedThings con todos los módulos recogidos anteriormente

        return new Settings(a!, c!, e!, b!, d!);
    }

    ///<returns>Un array de tamaño 3 de enteros donde el valor en la posicion 0 es el tamaño del tablero, en 1 el de la mano y en 2 la cantidad de jugadores</returns>
    public static int[] GetSideConfig()
    {
        int[] m = new int[3];
        System.Console.WriteLine("Choose your Board Size");
        m[0] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine();
        System.Console.WriteLine("Choose your Hand Size");
        m[1] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine();
        System.Console.WriteLine("Choose your amount of Players Size. Notice that it should be less than " + Utils.SumaDomino(m[0])/m[1]);
        m[2] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine();
        Console.Clear();
        return m;
    }
    ///<summary>Hace exactamente lo mismo que los módulos pero con los jugadores, se le pasa el máximo de jugadores</summary>
    ///<returns>Un array con todos los jugadores de la partida</returns>
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