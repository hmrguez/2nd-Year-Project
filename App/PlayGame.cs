namespace Domino;

public static class PlayGame
{
    public static void Play(GameObject game)
    {
        // Se reparten a los jugadores las fichas
        game.Settings.Shuffler.Shuffle(game.Players, game.Settings.Board, game.MaxHandSize);

        while (true)
        {
            //En cada iteración el jugador actual tiene que jugar una pieza
            //Esta se recoge

            Piece x = GetPiece(game.CurrentPlayer, game.Settings.Board);

            if (game.Settings.Board.PiecesOnBoard.Count == 0)
            {
                //Si es la primera entonces simplemente se añade
                game.Settings.Board.PiecesOnBoard.Add(x);
            }
            else if (x != null)
            {
                // Si no, por como funciona el Play, se sabe que o se puede puede jugar por la izquierda o derecha
                // Se prueba con cada una, rotando si es necesario
                // Si al final no entra en ningun caso el jugador esta mal implementado de alguna forma y da excepcion
                if (x.Match(game.Settings.Board.PiecesOnBoard.Last().Right))
                {
                    if (x.MatchLeft(game.Settings.Board.PiecesOnBoard.Last().Right))
                    {
                        game.Settings.Board.PiecesOnBoard.Add(x);
                    }
                    else
                    {
                        game.Settings.Board.PiecesOnBoard.Add(x.Rotate());
                    }
                }
                else if (x.Match(game.Settings.Board.PiecesOnBoard.First().Left))
                {
                    if (x.MatchRight(game.Settings.Board.PiecesOnBoard.First().Left))
                    {
                        game.Settings.Board.PiecesOnBoard = game.Settings.Board.PiecesOnBoard.Prepend(x).ToList();
                    }
                    else
                    {
                        game.Settings.Board.PiecesOnBoard = game.Settings.Board.PiecesOnBoard.Prepend(x.Rotate()).ToList();
                    }
                }
                else
                {
                    throw new Exception("Ha introducido un jugador que hace trampas");
                }
            }

            System.Console.WriteLine(string.Join(' ', game.Settings.Board.PiecesOnBoard));
            Thread.Sleep(1000);
            Console.Clear();

            //Se actualizan las rondas con la nueva jugada, que puede ser null si el tipo se pasa
            game.Rounds.Add(new Round(game.CurrentPlayer, x!));

            //Se comprueba siempre si al terminar la ronda se gano o tranco el juego y si da correcto sale del bucle
            if (game.Settings.WinCondition.EndCondition(game))
            {
                game.Winner = game.Settings.WinCondition.Winner(game);
                break;
            }

            //Se cambia el jugador actual por el siguiente en 
            game.CurrentPlayer = game.Settings.Rounder.NextPlayer(game);
        }
    }

    private static Piece GetPiece(IPlayer player, Board board)
    {
        if (player is HumanPlayer)
        {
            if(player.Hand.Where(x=>x.CanPlay(board)).Count() == 0)
            {
                System.Console.WriteLine("You have to pass");
                Thread.Sleep(2000);
                return null!;
            }
            while (true)
            {
                System.Console.WriteLine(player.Name);
                System.Console.WriteLine();
                System.Console.WriteLine("Board: " + string.Join(' ', board.PiecesOnBoard));
                System.Console.WriteLine();
                System.Console.WriteLine("Hand: " + string.Join(' ', player.Hand));
                System.Console.WriteLine();
                System.Console.WriteLine("Choose a Piece with the numpad");

                int p = int.Parse(Console.ReadLine()!);

                if (p >= player.Hand.Count)
                {
                    System.Console.WriteLine("Try again a piece you can actually play");
                    System.Console.WriteLine();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    var x = player.Hand[p];

                    if (x.CanPlay(board))
                    {
                        Console.Clear();
                        player.Hand.Remove(x);
                        return x;
                    }

                    else
                    {
                        System.Console.WriteLine("Try again a piece you can actually play");
                        System.Console.WriteLine();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }

            }
        }
        else
        {
            return player.Play(board);
        }
    }
}