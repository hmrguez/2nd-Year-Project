namespace Domino;

public abstract class BaseRounder : IRounder
{
    public abstract IPlayer NextPlayer(GameObject game);

    public override string ToString()=> GetType().Name;
}