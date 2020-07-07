using FluentAssertions;

using Moq;

using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Moves;

using Xunit;

namespace RockPaperScissors.Test
{
    public class GameShould
    {

        [Fact]
        public void Call_Second_Player()
        {
            var callbackActionMoq = new Mock<ICallbackActions>();

            callbackActionMoq.Setup(x => x.DoMove)
                .Returns(() => new Rock());
            callbackActionMoq.Setup(x => x.Lost)
                .Returns(() => { });

            var playerTwo = PlayerTestFactory.Create("Player 2",
                callbackActionMoq.Object);
            var playerOne = PlayerTestFactory.Create("Player 1");
            var players = new Players(playerOne, playerTwo);
            var game = new Game(players);
            game.Start();
            callbackActionMoq.Verify(x => x.DoMove, Times.Once);

        }
        [Fact]
        public void Call_First_Player()
        {
            var callbackActionMoq = new Mock<ICallbackActions>();

            callbackActionMoq.Setup(x => x.DoMove)
                .Returns(() => new Rock());
            callbackActionMoq.Setup(x => x.Lost)
                .Returns(() => { });

            var playerTwo = PlayerTestFactory.Create("Player 2");
            var playerOne = PlayerTestFactory.Create("Player 1", callbackActionMoq.Object);
            var players = new Players(playerOne, playerTwo);
            var game = new Game(players);
            game.Start();
            callbackActionMoq.Verify(x => x.DoMove, Times.Once);

        }
    }
}
