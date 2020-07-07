using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Moves;

namespace RockPaperScissors.Test
{
    public static class PlayerTestFactory
    {
        public static Player Create(string name) =>
            new Player(name, CallbackActionsTestFactory.Create(() => new Paper()));
        public static Player Create(string name, ICallbackActions actions) =>
            new Player(name, actions);

    }
}
