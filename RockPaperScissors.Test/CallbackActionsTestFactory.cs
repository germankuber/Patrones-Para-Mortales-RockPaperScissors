using System;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Moves;

namespace RockPaperScissors.Test
{
    public static class CallbackActionsTestFactory
    {
        public static ICallbackActions Create() =>
            new CallbackActions(()=> new Paper(), () => { }, () => { });
        public static ICallbackActions Create(Func<IMove> action) =>
            new CallbackActions(action, () => { }, () => { });
        public static ICallbackActions Create(Func<IMove> action, Action won, Action lost) =>
            new CallbackActions(action, won,lost);
    }
}