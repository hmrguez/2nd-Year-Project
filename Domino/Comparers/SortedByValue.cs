namespace Domino;

///<summary> Sorts Pieces according to their value </summary>
public class SortedByValue : IComparer<Piece>
{
    public int Compare(Piece? a, Piece? b)
    {
        return (a, b) switch
        {
            (Piece h, Piece q) when a == null => -1,
            (Piece h, Piece q) when b == null => 1,
            (Piece h, Piece q) when a.GetValue() > b.GetValue() => 1,
            (Piece h, Piece q) when a.GetValue() == b.GetValue() => 0,
            (Piece h, Piece q) when a.GetValue() < b.GetValue() => -1,
            _ => throw new Exception(" This shouldn't happen")
        };
    }
}