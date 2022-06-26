using Domino;


public class Program
{
    public static void Main()
    {
        System.Console.WriteLine("Want a quick game?");
        string yor = Console.ReadLine();
        Console.Clear();
        if (yor == "Y" || yor == "y")
        {
            BasePlayer[] players = new BasePlayer[] { new PlayerMostValue(), new PlayerRandom() };
            ChangedThings changes = new ChangedThings(new RegularBoard(), new RegularWinnable(), new Clockwise(), new RegularShuffler(), new RegularHandCounter());
            GameObject game = new GameObject(10,players,changes);
            game.Play();
            System.Console.WriteLine(string.Join(" ", game.Changes.Board.PiecesOnBoard));
            System.Console.WriteLine(game.Winner);
        }
        else
        {
            ChangedThings s = ConsoleUtils.GetMainConfig();
            int[] a = ConsoleUtils.GetSideConfig();
            BasePlayer[] b = ConsoleUtils.GetPlayerConfig(a[2]);
            GameObject game = new GameObject(a[1], b, s, a[0]);
            game.Play();
            System.Console.WriteLine(string.Join(" ", game.Changes.Board.PiecesOnBoard));
            System.Console.WriteLine(game.Winner);
        }
    }
}

