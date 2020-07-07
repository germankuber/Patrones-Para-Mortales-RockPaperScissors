namespace RockPaperScissors.Domain.Results
{
    class Lost : IResult
    {
        public void Resolve(Players players)
        {
            players.PlayerOne.Lost();
            players.PlayerTwo.Won();
        }
    }
}