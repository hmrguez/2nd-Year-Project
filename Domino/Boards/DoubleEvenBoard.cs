namespace Domino;

public class DoubleEvenBoard : Board
{
    public DoubleEvenBoard() : this(12)
    {
        
    }
    public DoubleEvenBoard(int maxInput)
    {
        this.PiecesOnBoard = new();
        this.Deck = Generate(maxInput);
    }
    protected override List<Piece> Generate(int maximumInput)
    {
        List<Piece> result = new();
        for (int i = 0; i <= maximumInput; i++)
        {
            for (int j = i; j <= maximumInput; j++)
            {
                var temp = new OnlyEvenDoublesPiece(i, j);
                result.Add(temp);
            }
        }
        return result;
    }
}