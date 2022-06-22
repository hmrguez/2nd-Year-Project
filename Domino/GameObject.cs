namespace Domino;

public class GameObject
{
    public event EventHandler? OnPlayerPassed;
    public int MaxHandSize { get; }
    public List<Round> Rounds { get; set; }
    public IPlayer[] Players { get; }
    public IPlayer CurrentPlayer { get; set; }
    public IPlayer? Winner{ get; set;}
    public ChangedThings Changes{ get;}
    public GameObject(int maxHandSize, IPlayer[] players, ChangedThings changedThings)
    {
        this.Changes = changedThings;
        MaxHandSize = maxHandSize;
        Players = players;
        Rounds = new();
        CurrentPlayer = Players[0];
    }
}