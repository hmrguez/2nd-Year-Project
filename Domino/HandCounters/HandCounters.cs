namespace Domino;

public abstract class BaseHandCounter : IHandCounter
{
    public abstract int GetHandValue(IPlayer player);
    public override string ToString() => GetType().Name;
}