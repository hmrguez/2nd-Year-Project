namespace Domino;

public abstract class BaseShuffler : IShuffler
{
    public abstract void Shuffle(IPlayer[] players, Board board, int maxHandSize);
    public abstract void ShufflePlayer(IPlayer player, Board board, int maxHandSize);

    public override string ToString() => GetType().Name;
}
