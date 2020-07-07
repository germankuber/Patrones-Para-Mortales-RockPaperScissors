namespace RockPaperScissors.Domain.Results
{
    class Tie : IResult
    {
        public void Resolve(Players players) =>
            players.Play();
    }
}