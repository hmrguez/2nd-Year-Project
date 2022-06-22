using System.Collections;

namespace Domino;

public class Table<T> : IEnumerable<T> where T : Piece
{
    private List<T> _onBoard;
    public Table()
    {
        this._onBoard = new List<T>();
    }
    public int Count()
    {
        return _onBoard.Count();
    }
    public void AddLast(T piece)
    {
        _onBoard.Add(piece);
    }
    public void AddFirst(T piece)
    {
        this._onBoard =this._onBoard.Prepend(piece).ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this._onBoard.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this._onBoard.GetEnumerator();
    }
}