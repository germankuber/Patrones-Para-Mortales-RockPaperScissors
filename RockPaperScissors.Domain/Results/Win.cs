namespace RockPaperScissors.Domain.Results
{
    class Win : IResult
    {
        public void Resolve(Players players)
        {
            players.PlayerOne.Won();
            players.PlayerTwo.Lost();
        }
    }
}