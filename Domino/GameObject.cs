namespace Domino;

public class GameObject
{
    public int MaxHandSize { get; }
    public int BoardSize { get; set; }
    public List<Round> Rounds { get; set; }
    public IPlayer[] Players { get; }
    public IPlayer CurrentPlayer { get; set; }
    public IPlayer? Winner { get; set; }
    public ChangedThings Changes { get; }

    public GameObject()
    {
        Changes = new(new RegularBoard(), new RegularWinnable(), new Clockwise(), new RegularShuffler(), new RegularHandCounter());
        MaxHandSize = 10;
        Players = new IPlayer[] { new PlayerMostValue(), new PlayerRandom(), new PlayerRandom(), new PlayerMostValue() };
        CurrentPlayer = Players[0];
        Changes.Board.Deck = Changes.Board.Generate(9);
        Rounds = new();
    }
    public GameObject(int maxHandSize, IPlayer[] players, ChangedThings changedThings, int boardSize)
    {
        this.Changes = changedThings;
        MaxHandSize = maxHandSize;
        Players = players;
        Rounds = new();
        CurrentPlayer = Players[0];
        BoardSize = boardSize;
        Changes.Board.Deck = Changes.Board.Generate(boardSize);
    }
    public void Play()
    {
        Changes.Shuffler.Shuffle(Players, Changes.Board, MaxHandSize);

        while (true)
        {
            //En cada iteración el jugador actual tiene que jugar una pieza
            //Esta se recoge
            Piece x = CurrentPlayer.Play(Changes.Board);
            if (Changes.Board.PiecesOnBoard.Count == 0)
            {
                //Si es la primera entonces simplemente se añade
                Changes.Board.PiecesOnBoard.Add(x);
            }
            else if (x != null)
            {
                // Si no, por como funciona el Play, se sabe que o se 
                if (x.Match(Changes.Board.PiecesOnBoard.Last().Right))
                {
                    if (x.MatchLeft(Changes.Board.PiecesOnBoard.Last().Right))
                    {
                        Changes.Board.PiecesOnBoard.Add(x);
                    }
                    else
                    {
                        Changes.Board.PiecesOnBoard.Add(x.Rotate());
                    }
                }
                else if (x.Match(Changes.Board.PiecesOnBoard.First().Left))
                {
                    if (x.MatchRight(Changes.Board.PiecesOnBoard.First().Left))
                    {
                        Changes.Board.PiecesOnBoard = Changes.Board.PiecesOnBoard.Prepend(x).ToList();
                    }
                    else
                    {
                        Changes.Board.PiecesOnBoard = Changes.Board.PiecesOnBoard.Prepend(x.Rotate()).ToList();
                    }
                }
                else
                {
                    throw new Exception("Ha introducido un jugador que hace trampas");
                }
            }
            Rounds.Add(new Round(CurrentPlayer, x!));
            if (Changes.WinCondition.EndCondition(this))
            {
                Winner = Changes.WinCondition.Winner(this);
                break;
            }
            CurrentPlayer = Changes.Rounder.NextPlayer(this);
        }
    }
    public void Reset()
    {
        Changes.Board.Deck = Changes.Board.Generate(BoardSize);
        Changes.Board.PiecesOnBoard = new();
        foreach (var item in Players)
        {
            item.ResetHand();
        }
        Winner = null;
    }
}