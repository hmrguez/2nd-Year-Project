using Domino;


public class TournamentClass
{
    public static bool IsTournament(int tournamnet) => tournamnet > 1 ? true : false;
    public static void PlayTournament(GameObject[] games, PlayGame single)
    {
        int count = 0;
        while (count < games.Length)
        {
            single.PlaySingleGame(games[count++]);
        }
    }
}