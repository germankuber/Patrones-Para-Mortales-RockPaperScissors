using System;
using FluentAssertions;
using Moq;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Moves;
using Xunit;

namespace RockPaperScissors.Test
{
    public class PlayersShould
    {
        [Fact]
        public void Has_Two_Players()
        {
            var playerOne = PlayerTestFactory.Create("Player 1");
            var playerTwo = PlayerTestFactory.Create("Player 2");
            var players = new Players(playerOne, playerTwo);

            players.PlayerOne.Should().Be(playerOne);
            players.PlayerTwo.Should().Be(playerTwo);
        }
        [Fact]
        public void Not_Allow_Two_Same_Players()
        {
            var playerOne = PlayerTestFactory.Create("Player 1");
            Action act = () => new Players(playerOne, playerOne);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Name_Not_Allow_Null(string name)
        {
            Action act = () => new Player(name, CallbackActionsTestFactory.Create());
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Call_Choose_Move()
        {
            var executed = false;

            PlayerTestFactory.Create("Player 1",
                CallbackActionsTestFactory.Create(() =>
                {
                    executed = true;
                    return new Paper();
                })).DoMove();
            executed.Should().BeTrue();
        }
        [Fact]
        public void Choose_Valid_Move()
        {
            var move = new Paper();

            PlayerTestFactory.Create("Player 1",
                    CallbackActionsTestFactory.Create(() => move))
                .DoMove()
                .Should().Be(move);
        }

        [Fact]
        public void PlayerOne_PlayerTwo_Tie()
        {
            var callbackActionPlayerTwoMoq = new Mock<ICallbackActions>();

            callbackActionPlayerTwoMoq.Setup(x => x.DoMove)
                .Returns(() => new Paper());

            callbackActionPlayerTwoMoq.Setup(x => x.Lost)
                .Returns(() => { });

            var playerOne = PlayerTestFactory.Create("Player 1",
                callbackActionPlayerTwoMoq.Object);

            var callbackActionPlayerOneMoq = new Mock<ICallbackActions>();

            callbackActionPlayerOneMoq.SetupSequence(x => x.DoMove)
                .Returns(() => new Paper())
                .Returns(() => new Scissors());

            callbackActionPlayerOneMoq.Setup(x => x.Won)
                .Returns(() => { });

            var playerTwo = PlayerTestFactory.Create("Player 2", callbackActionPlayerOneMoq.Object);

            new Players(playerOne,playerTwo)
                .Play();

            callbackActionPlayerOneMoq.Verify(x=> x.DoMove, Times.Exactly(2));
            callbackActionPlayerTwoMoq.Verify(x=> x.Lost, Times.Once);
        }
    }
}
