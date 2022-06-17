namespace Domino;

public class SkipTurn : BaseRounder
{
    public override IPlayer NextPlayer(GameObject game) => game.Rounds.Last().Piece == null ? new CounterClockWise().NextPlayer(game) : new Clockwise().NextPlayer(game);
}