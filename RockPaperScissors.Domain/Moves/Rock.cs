using RockPaperScissors.Domain.Results;

namespace RockPaperScissors.Domain.Moves
{
    public class Rock : IMove
    {
        public void MatchWith(IMove move, Players players) =>
            ((IResult)(move switch
            {
                Scissors _ => new Win(),
                Rock _ => new Tie(),
                _ => new Lost(),
            })).Resolve(players);
    }
}