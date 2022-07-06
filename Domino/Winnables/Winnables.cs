namespace Domino;

public abstract class BaseWinnable : IWinnable
{
    public bool Won { get; protected set; }
    public IPlayer Winner(GameObject game) => Won 
        ? game.Rounds.Last().Player 
        : Utils.StandardCounter(game, game.Settings.HandCounter);

    public abstract bool EndCondition(GameObject game);
    
    public override string ToString() => GetType().Name;
}