using Domino;

public class PlayerValue
{
    public string? Player1 { get; set; }
    public string? Player2 { get; set; }
    public string? Player3{ get; set;}
    public string? Player4{ get; set;}

    public static IPlayer? GetPlayer(string player)
    {
        Type? t = typeof(IWinnable).Assembly.GetTypes().FirstOrDefault(p => p.Name == player);
        return Activator.CreateInstance(t!) as IPlayer;
    }
}