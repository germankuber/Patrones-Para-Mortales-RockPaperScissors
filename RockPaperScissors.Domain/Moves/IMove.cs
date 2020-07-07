namespace RockPaperScissors.Domain.Moves
{
    public interface IMove
    {
        void MatchWith(IMove move, Players players);
    }
}