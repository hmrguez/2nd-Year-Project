﻿using Domino;


public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Want a quick game? [Y]es or [N]o");
            string yor = Console.ReadLine()!;
            Console.Clear();
            if (yor == "Y" || yor == "y")
            {
                var game = new GameObject();
                PlayGame.Play(game);
                game.PrintGame();
            }
            else
            {
                Settings s = ConsoleUtils.GetMainConfig();
                int[] a = ConsoleUtils.GetSideConfig();
                IPlayer[] b = ConsoleUtils.GetPlayerConfig(a[2]);
                GameObject game = new GameObject(a[1], b, s, a[0]);

                System.Console.WriteLine("Want to play a tournament? [Y]es or [N]o");
                string f = Console.ReadLine()!;
                Console.Clear();

                if (f == "Y" || f == "y")
                {
                    System.Console.WriteLine("How many Games?");
                    int x = int.Parse(Console.ReadLine()!);
                    Console.Clear();
                    for (int i = 0; i < x; i++)
                    {
                        PlayGame.Play(game);
                        game.PrintGame();
                        game.Reset();
                        System.Console.WriteLine();
                    }
                }
                else{
                    PlayGame.Play(game);
                    game.PrintGame();
                    game.Reset();
                }
            }

            System.Console.WriteLine("Want to play again? [Y]es or [N]o");
            string yei = Console.ReadLine()!;
            if (yei != "Y" && yei != "y")
            {
                break;
            }
        }
    }
}

