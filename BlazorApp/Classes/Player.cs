using Domino;
public class Player
{
    public string Name{get; private set;}
    public IPlayer PlayerMode{get; private set;}

    public Player(string name, IPlayer player)
    {
        this.Name = name;
        this.PlayerMode = player;
    }

}