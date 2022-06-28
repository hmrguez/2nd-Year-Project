namespace Domino;

public class GameObject
{
    public int MaxHandSize { get; }
    public int BoardSize { get; set; }
    public List<Round> Rounds { get; set; }
    public IPlayer[] Players { get; }
    public IPlayer CurrentPlayer { get; set; }
    public IPlayer? Winner{ get; set;}
    public ChangedThings Changes{ get;}
    
    public GameObject(){
        Changes = new(new RegularBoard(),new RegularWinnable(),new Clockwise(),new RegularShuffler(),new RegularHandCounter());
        MaxHandSize = 10;
        Players = new IPlayer[]{new PlayerMostValue(), new PlayerRandom(), new PlayerRandom(), new PlayerMostValue()};
        CurrentPlayer = Players[0];
        Changes.Board.Deck = Changes.Board.Generate(9);
        Rounds = new();
    }
    public GameObject(int maxHandSize, IPlayer[] players, ChangedThings changedThings)
    {
        this.Changes = changedThings;
        MaxHandSize = maxHandSize;
        Players = players;
        Rounds = new();
        CurrentPlayer = Players[0];
        Changes.Board.Deck = Changes.Board.Generate(9);
    }
    public GameObject(int maxHandSize, IPlayer[] players, ChangedThings changedThings, int boardSize){
        this.Changes = changedThings;
        MaxHandSize = maxHandSize;
        Players = players;
        Rounds = new();
        CurrentPlayer = Players[0];
        Changes.Board.Deck = Changes.Board.Generate(boardSize);
    }
    public void Play()
    {
        Changes.Shuffler.Shuffle(Players, Changes.Board, MaxHandSize);
        
        while (true)
        {
            Piece x = CurrentPlayer.Play(Changes.Board);
            if (Changes.Board.PiecesOnBoard.Count == 0)
            {
                Changes.Board.PiecesOnBoard.Add(x);
            }
            else if (x != null)
            {
                if (x.Match(Changes.Board.PiecesOnBoard.Last().Right))
                {
                    if (x.Left == Changes.Board.PiecesOnBoard.Last().Right)
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
                    if (x.Right == Changes.Board.PiecesOnBoard.First().Left)
                    {
                        Changes.Board.PiecesOnBoard = Changes.Board.PiecesOnBoard.Prepend(x).ToList();
                    }
                    else
                    {
                        Changes.Board.PiecesOnBoard = Changes.Board.PiecesOnBoard.Prepend(x.Rotate()).ToList();
                    }
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
}