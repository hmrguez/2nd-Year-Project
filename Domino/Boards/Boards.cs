using System.Collections;
using System.Collections.Generic;

namespace Domino;

public abstract class Board
{
    public Table<Piece>? PiecesOnBoard { get; protected set; }
    public List<Piece>? Deck { get; protected set; }
    protected abstract List<Piece> Generate(int maximumInput);
    public override string ToString() => GetType().Name;
}