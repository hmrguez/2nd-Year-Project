namespace Domino;


public class PlayerRandomValue : IPlayer
{

    public List<Piece> Hand { get; private set; }
    private IPlayer _mode;
    public PlayerRandomValue()
    {
        this.Hand = new List<Piece>();
        this._mode = new PlayerMostValue();
    }

    public Piece Play(Board board)
    {
        ChangingMind(board);
        return this._mode.Play(board);
    }
    private void ChangingMind(Board board)
    {
        //Idea pobre por poner algo
        if (board.PiecesOnBoard.Count() == 10)
        {
            this._mode = new PlayerRandom();
        }
    }
}