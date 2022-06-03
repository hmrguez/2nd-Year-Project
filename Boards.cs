using System.Collections;
using System.Collections.Generic;

public class RegularBoard : Board  
{
    public RegularBoard(int maxInput)
    {
        this.PiecesOnBoard = new Table();
        this.Deck = Generate(maxInput);
    }
    protected override List<Piece> Generate(int maximumInput){
        List<Piece> result = new();
        for (int i = 0; i <= maximumInput; i++)
        {
            for (int j = i; j <= maximumInput; j++)
            {
                var temp = new RegularPiece(i,j);
                result.Add(temp);
            }
        }
        return result;
    }
}
public class Table
{
    private List<Piece> _onBoard;
    public Table(){
        this._onBoard = new List<Piece>();
    }
    public Piece First(){
        return _onBoard.First();
    }
    public Piece Last(){
        return _onBoard.Last();
    }
    public int Count(){
        return _onBoard.Count();
    }
    public void AddRight(Piece piece){
        _onBoard.Add(piece);
    }
    public void AddLeft(Piece piece){
        _onBoard.Prepend(piece);
    }
}