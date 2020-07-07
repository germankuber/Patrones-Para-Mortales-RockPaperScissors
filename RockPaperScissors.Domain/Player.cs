using System;
using RockPaperScissors.Domain.Moves;

namespace RockPaperScissors.Domain
{
    public class Player
    {
        private readonly ICallbackActions _callbackActions;
        public string Name { get; }

        public Player(string name, ICallbackActions callbackActions)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Name = name;
            _callbackActions = callbackActions;
        }

        public IMove DoMove() =>
            _callbackActions.DoMove();
        public void Won() =>
            _callbackActions.Won();
        public void Lost() =>
            _callbackActions.Lost();
    }
}