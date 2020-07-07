using System;
using RockPaperScissors.Domain.Moves;

namespace RockPaperScissors.Domain
{
    public interface ICallbackActions
    {
         Func<IMove> DoMove { get; }
         Action Won { get; }
         Action Lost { get; }
    }

    public class CallbackActions: ICallbackActions
    {
        public Func<IMove> DoMove { get; }
        public Action Won { get; }
        public Action Lost { get; }

        public CallbackActions(Func<IMove> move, Action won, Action lost)
        {
            DoMove = move;
            Won = won;
            Lost = lost;
        }
    }
}