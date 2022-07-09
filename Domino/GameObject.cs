namespace Domino;

public class GameObject
{
    public int MaxHandSize { get; }
    public int BoardSize { get; }
    public List<Round> Rounds { get; private set; }
    public IPlayer[] Players { get; }
    public IPlayer CurrentPlayer { get; private set; }
    public IPlayer? Winner { get; private set; }
    public Settings Settings { get; }

    public GameObject()
    {
        Settings = new(new RegularBoard(), new RegularWinnable(), new Clockwise(), new RegularShuffler(), new RegularHandCounter());
        MaxHandSize = 10;
        Players = new IPlayer[] { new PlayerMostValue("MartaBot"), new PlayerRandom("TobiasBot"), new PlayerRandom("FranciscoBot"), new PlayerMostValue("VladBot") };
        CurrentPlayer = Players[0];
        Settings.Board.Deck = Settings.Board.Generate(9);
        Rounds = new();
    }
    public GameObject(int maxHandSize, IPlayer[] players, Settings changedThings, int boardSize)
    {
        this.Settings = changedThings;
        MaxHandSize = maxHandSize;
        Players = players;
        Rounds = new();
        CurrentPlayer = Players[0];
        BoardSize = boardSize;

        //Se actualiza el Deck del Board con todas las posibles combinaciones de ficha con ese doble maximo
        Settings.Board.Deck = Settings.Board.Generate(boardSize);
    }
    public void Play()
    {
        // Se reparten a los jugadores las fichas
        Settings.Shuffler.Shuffle(Players, Settings.Board, MaxHandSize);

        while (true)
        {
            //En cada iteración el jugador actual tiene que jugar una pieza
            //Esta se recoge
            Piece x = CurrentPlayer.Play(Settings.Board);
            if (Settings.Board.PiecesOnBoard.Count == 0)
            {
                //Si es la primera entonces simplemente se añade
                Settings.Board.PiecesOnBoard.Add(x);
            }
            else if (x != null)
            {
                // Si no, por como funciona el Play, se sabe que o se puede puede jugar por la izquierda o derecha
                // Se prueba con cada una, rotando si es necesario
                // Si al final no entra en ningun caso el jugador esta mal implementado de alguna forma y da excepcion
                if (x.Match(Settings.Board.PiecesOnBoard.Last().Right))
                {
                    if (x.MatchLeft(Settings.Board.PiecesOnBoard.Last().Right))
                    {
                        Settings.Board.PiecesOnBoard.Add(x);
                    }
                    else
                    {
                        Settings.Board.PiecesOnBoard.Add(x.Rotate());
                    }
                }
                else if (x.Match(Settings.Board.PiecesOnBoard.First().Left))
                {
                    if (x.MatchRight(Settings.Board.PiecesOnBoard.First().Left))
                    {
                        Settings.Board.PiecesOnBoard = Settings.Board.PiecesOnBoard.Prepend(x).ToList();
                    }
                    else
                    {
                        Settings.Board.PiecesOnBoard = Settings.Board.PiecesOnBoard.Prepend(x.Rotate()).ToList();
                    }
                }
                else
                {
                    throw new Exception("Ha introducido un jugador que hace trampas");
                }
            }
            //Se actualizan las rondas con la nueva jugada, que puede ser null si el tipo se pasa
            Rounds.Add(new Round(CurrentPlayer, x!));

            //Se comprueba siempre si al terminar la ronda se gano o tranco el juego y si da correcto sale del bucle
            if (Settings.WinCondition.EndCondition(this))
            {
                Winner = Settings.WinCondition.Winner(this);
                break;
            }

            //Se cambia el jugador actual por el siguiente en 
            CurrentPlayer = Settings.Rounder.NextPlayer(this);
        }
    }

    ///<summary>Vuelve el juego a su estado inicial</summary>
    public void Reset()
    {
        Settings.Board.Deck = Settings.Board.Generate(BoardSize);
        Settings.Board.PiecesOnBoard = new();
        foreach (var item in Players)
        {
            item.ResetHand();
        }
        Winner = null;
    }
}