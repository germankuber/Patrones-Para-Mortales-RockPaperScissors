using System;

namespace RockPaperScissors.Domain
{
    public class Players
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Players(Player playerOne, Player playerTwo )
        {
            if (playerOne == playerTwo)
                throw  new ArgumentException();
            PlayerTwo = playerTwo;
            PlayerOne = playerOne;
        }

        public void Play() =>
            PlayerOne.DoMove().MatchWith(PlayerTwo.DoMove(), this);

    
    }
}