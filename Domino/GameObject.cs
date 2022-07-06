namespace Domino;

public class GameObject
{
    public int MaxHandSize { get; }
    public int BoardSize { get; set; }
    public List<Round> Rounds { get; set; }
    public IPlayer[] Players { get; }
    public IPlayer CurrentPlayer { get; set; }
    public IPlayer? Winner { get; set; }
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
        Settings.Board.Deck = Settings.Board.Generate(boardSize);
    }
    public void Play()
    {
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
                // Si no, por como funciona el Play, se sabe que o se 
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
            Rounds.Add(new Round(CurrentPlayer, x!));
            if (Settings.WinCondition.EndCondition(this))
            {
                Winner = Settings.WinCondition.Winner(this);
                break;
            }
            CurrentPlayer = Settings.Rounder.NextPlayer(this);
        }
    }
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