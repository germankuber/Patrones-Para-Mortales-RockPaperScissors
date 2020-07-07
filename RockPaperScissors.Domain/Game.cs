namespace RockPaperScissors.Domain
{
    public class Game
    {
        private readonly Players _players;

        public Game(Players players)
        {
            _players = players;
        }

        public void Start() =>
            _players.Play();
    }
}