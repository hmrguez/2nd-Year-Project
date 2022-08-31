using Domino;

public static class ConsoleUtils
{
    ///<summary>Consigue la propiedad Settings del juego</summary>
    public static Settings GetMainConfig() => new Settings(
        (new Getter<Board>()).GetConfig("Board", Utils.GetT(typeof(Board))),
        (new Getter<IWinnable>()).GetConfig("Winnable", Utils.GetT(typeof(IWinnable))),
        (new Getter<IRounder>()).GetConfig("Rounder", Utils.GetT(typeof(IRounder))),
        (new Getter<IShuffler>()).GetConfig("Shuffler", Utils.GetT(typeof(IShuffler))),
        (new Getter<IHandCounter>()).GetConfig("HandCounter", Utils.GetT(typeof(IHandCounter)))
    );

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
        System.Console.WriteLine("Choose your amount of Players Size. Notice that it should be less than " + (int)(Utils.SumaDomino(m[0]) / m[1] + 1));
        m[2] = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine();
        Console.Clear();
        return m;
    }
    ///<summary>Hace exactamente lo mismo que los módulos pero con los jugadores, se le pasa el máximo de jugadores</summary>
    ///<returns>Un array con todos los jugadores de la partida</returns>
    public static IPlayer[] GetPlayerConfig(int p)
    {
        int k = 0;
        IPlayer[] result = new IPlayer[p];
        while (k < p)
        {
            result[k] = (new Getter<IPlayer>()).GetConfig("Player",Utils.GetT(typeof(IPlayer)));
            if(result[k] is HumanPlayer)
            {
                System.Console.WriteLine("Name: ");
                string name = Console.ReadLine()!;
                result[k].Name = name;
                Console.Clear();
            }
            k += 1;
        }
        return result;
    }
    public static void PrintGame(this GameObject game)
    {
        System.Console.WriteLine(string.Join(" ", game.Settings.Board.PiecesOnBoard));
        System.Console.WriteLine();
        System.Console.WriteLine("Winner: " + game.Winner?.Name + " (" + game.Winner + ")");
        System.Console.WriteLine("------------------------------------------------------------------------");
        System.Console.WriteLine();
        foreach (var item in game.Rounds)
        {
            if(item.Piece!=null)
            System.Console.WriteLine(item.Player.Name +" (" + item.Player +") played " + item.Piece);
            else System.Console.WriteLine(item.Player.Name +" (" + item.Player + ") passed");   
            Thread.Sleep(600);
        }
        System.Console.WriteLine();
    }
    public static string Number(int n) => n switch
    {
        1 => "st",
        2 => "nd",
        3 => "rd",
        _ => "th"
    };
}
public class Getter<T>{

    ///<summary>Cicla por todas las iteraciones de cada módulo y le da a escoger al usuario</summary>
    ///<param name="x">Es el string que se imprime en el encabezado, puramente decorativo</param>
    ///<param name="y">Es el array de donde se sacan todos los tipos que se quieren</param>
    ///<returns>Una instancia de tipo T del módulo en el índice que escogio el usuario</returns>   
    public T GetConfig(string x, string[] y){
        System.Console.WriteLine("Choose your " + x );
        for (int i = 0; i < y.Length; i++)
        {
            System.Console.WriteLine($"[{i}] {y[i]}");
        }
        int a = int.Parse(Console.ReadLine()!);
        var z = typeof(T).Assembly.GetTypes().First(t => t.Name == y[a]);
        Console.Clear();
        return (T)Activator.CreateInstance(z)!;
    }
}