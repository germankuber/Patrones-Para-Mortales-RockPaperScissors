using RockPaperScissors.Domain.Results;

namespace RockPaperScissors.Domain.Moves
{
    public class Scissors : IMove
    {
        public void MatchWith(IMove move, Players players) =>
            ((IResult)(move switch
            {
                Paper _ => new Win(),
                Scissors _ => new Tie(),
                _ => new Lost(),
            })).Resolve(players);
    }
}