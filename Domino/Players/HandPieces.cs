using System.Collections;

namespace Domino;

public class HandPieces<T> : IEnumerable<T> where T : Piece
{
    public HandPieces()
    {
        this._hand = new List<T>();
    }
    private List<T> _hand;

    public void Add(T item){
        this._hand.Add(item);
    }
    public void Remove(T item)
    {
        if(item != null){
            this._hand.Remove(item);
            this._hand = new List<T>(this._hand);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this._hand.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this._hand.GetEnumerator();
    }
}