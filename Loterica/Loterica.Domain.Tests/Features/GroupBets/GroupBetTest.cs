using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loterica.Domain.Features.Bets;
using Moq;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Features.GroupBets;
using FluentAssertions;

namespace Loterica.Domain.Tests.Features.GroupBets
{
    [TestFixture]
    public class GroupBetTest
    {
        GroupBet _groupBet;
        Mock<Bet> _bet;

        [SetUp]
        public void Initialize()
        {
            _groupBet = new GroupBet();
            _bet = new Mock<Bet>();
        }

        [Test]
        public void GroupBet_ValidCreateDate_ShouldBeOk()
        {
            //Cenário
            _groupBet = ObjectMother.ValidGroupBetWithId();
            _groupBet.Bets = new List<Bet>() { _bet.Object };

            //Ação
            Action act = () => _groupBet.Validate();

            //Verificar
            act.Should().NotThrow<InvalidCreateGroupBetDateException>();
        }

        [Test]
        public void GroupBet_InvalidCreateDate_ShouldFail()
        {
            //Cenário
            _groupBet = ObjectMother.InvalidCreateGroupBetDate();
            _groupBet.Bets = new List<Bet>() { _bet.Object };

            //Ação
            Action act = () => _groupBet.Validate();

            //Verificar
            act.Should().Throw<InvalidCreateGroupBetDateException>();
        }

        [Test]
        public void GroupBet_ValidOrganizer_ShouldBeOk()
        {
            //Cenário
            _groupBet = ObjectMother.ValidGroupBetWithId();
            _groupBet.Bets = new List<Bet>() { _bet.Object };

            //Ação
            Action act = () => _groupBet.Validate();

            //Verificar
            act.Should().NotThrow<InvalidOrganizerException>();
        }

        [Test]
        public void GroupBet_InvalidOrganizer_ShouldFail()
        {
            //Cenário
            _groupBet = ObjectMother.InvalidGroupBetOrganizer();
            _groupBet.Bets = new List<Bet>() { _bet.Object };

            //Ação
            Action act = () => _groupBet.Validate();

            //Verificar
            act.Should().Throw<InvalidOrganizerException>();
        }

        [Test]
        public void GroupBet_ValidBets_ShouldBeOk()
        {
            //Cenário
            _groupBet = ObjectMother.ValidGroupBetWithId();
            _groupBet.Bets = new List<Bet> { _bet.Object };

            //Ação
            Action act = () => _groupBet.Validate();

            //Verificar
            act.Should().NotThrow<GroupBetEmptyBetsException>();
        }

        [Test]
        public void GroupBet_EmptyBets_ShouldFail()
        {
            //Cenário
            _groupBet = ObjectMother.GroupBetEmptyBets();

            //Ação
            Action act = () => _groupBet.Validate();

            //Verificar
            act.Should().Throw<GroupBetEmptyBetsException>();
        }

        [TearDown]
        public void TearDown()
        {
            _groupBet = null;
        }
    }
}