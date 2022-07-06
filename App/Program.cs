using Domino;


public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Want a quick game?");
            string yor = Console.ReadLine()!;
            Console.Clear();
            if (yor == "Y" || yor == "y")
            {
                var game = new GameObject();
                game.Play();
                System.Console.WriteLine(string.Join(" ", game.Changes.Board.PiecesOnBoard));
                System.Console.WriteLine();
                System.Console.WriteLine("Winner:" + game.Winner);
                System.Console.WriteLine();
            }
            else
            {
                ChangedThings s = ConsoleUtils.GetMainConfig();
                int[] a = ConsoleUtils.GetSideConfig();
                BasePlayer[] b = ConsoleUtils.GetPlayerConfig(a[2]);
                GameObject game = new GameObject(a[1], b, s, a[0]);

                System.Console.WriteLine("Want to play a tournament?");
                string f = Console.ReadLine()!;
                Console.Clear();

                if(f=="Y"||f=="y"){
                    System.Console.WriteLine("How many Games?");
                    int x = int.Parse(Console.ReadLine()!);
                    Console.Clear();
                    for (int i = 0; i < x; i++)
                    {
                        game.Play();
                        System.Console.WriteLine(string.Join(" ", game.Changes.Board.PiecesOnBoard));
                        System.Console.WriteLine();
                        System.Console.WriteLine("Winner:" + game.Winner);
                        System.Console.WriteLine();
                        game.Reset();
                    }
                }
                else{
                    game.Play();
                    System.Console.WriteLine(string.Join(" ", game.Changes.Board.PiecesOnBoard));
                    System.Console.WriteLine();
                    System.Console.WriteLine("Winner:" + game.Winner);
                    System.Console.WriteLine();
                    game.Reset();
                }
            }

            System.Console.WriteLine("Want to play again?");
            string yei = Console.ReadLine()!;
            if (yei != "Y" && yei != "y")
            {
                break;
            }
        }
    }
}

