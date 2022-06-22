namespace Domino;


public class PlayerRandomValue : BasePlayer
{

    private IPlayer _mode;
    public PlayerRandomValue()
    {
        this.Hand = new List<Piece>();
        this._mode = new PlayerMostValue();
    }

    public override Piece Play(Board board)
    {
        ChangingMind(board);
        return this._mode.Play(board);
    }
    private void ChangingMind(Board board)
    {
        if (board.PiecesOnBoard!.Count() == 10)
        {
            this._mode = new PlayerRandom();
        }
    }
}