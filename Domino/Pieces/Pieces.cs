namespace Domino;

public abstract class Piece
{
    public int Left { get; set; }
    public int Right { get; set; }

    ///<returns> True if this piece can fit in the board, false if can't </returns>
    public abstract bool CanPlay(Board board);

    ///<summary> Rotates the piece so their side values change position </summary>
    public Piece Rotate()
    {
        int c = Left;
        Left = Right;
        Right = c;
        return this;
    }

    ///<returns> The total value of the piece, the sum of the sides </returns>
    public int GetValue() => Left + Right;

    ///<returns> True if any side of this piece matches the int, false if doesn't </returns>
    public bool Match(int num) => (Left == num || Right == num) ? true : false;
    public override string ToString() => $"[{Left}|{Right}]";
}