namespace Domino;

public class PlayerMostValue : IPlayer
{
    public List<Piece> Hand { get; set; }
    public PlayerMostValue()
    {
        Hand = new();
    }
    public Piece Play(Board board)
    {
        Piece? piece = Hand.Where(pieces => pieces.CanPlay(board)).OrderByDescending(x=>x.GetValue()).First();
        return piece!;
    }
}