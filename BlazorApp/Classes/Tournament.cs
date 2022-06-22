using Domino;


public class TournamentClass
{
    public static bool IsTournament(string tournamnet) => tournamnet == "off" ? false : true;
    public static void PlayTournament(GameObject[] games, PlayGame single)
    {
        int count = 0;
        while (count < games.Length)
        {
            single.PlaySingleGame(games[count++]);
        }
    }
}