using RockPaperScissors.Domain.Results;

namespace RockPaperScissors.Domain.Moves
{
    public class Paper : IMove
    {
        public void MatchWith(IMove move, Players players) =>
            ((IResult)(move switch
            {
                Rock _ => new Win(),
                Paper _ => new Tie(),
                _ => new Lost(),
            })).Resolve(players);
    }
}