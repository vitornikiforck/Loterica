using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Features.Bets;
using Loterica.Domain.Features.Contests;
using Loterica.Domain.Features.GroupBets;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Tests.Features.Bets
{
    [TestFixture]
    public class BetTest
    {
        Bet _bet;
        Mock<Contest> _contestMock;

        [SetUp]
        public void Initialize()
        {
            _bet = new Bet();
            _contestMock = new Mock<Contest>();
        }

        //Escrever testes
        [Test]
        public void Bet_ValidBetDate_ShouldBeOk()
        {
            //Cenário
            _bet = ObjectMother.RandomValidBetWithoutId();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().NotThrow<InvalidBetDateException>();
        }

        [Test]
        public void Bet_InvalidBetDate_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidBetDate();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().Throw<InvalidBetDateException>();
        }

        [Test]
        public void Bet_ValidNumbersBet_ShouldBeOk()
        {
            //Cenário
            _bet = ObjectMother.RandomValidBetWithoutId();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().NotThrow<InvalidNumbersBetException>();
        }

        [Test]
        public void Bet_InvalidNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidNumbersBet();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().Throw<InvalidNumbersBetException>();
        }

        [Test]
        public void Bet_ValidQuantityNumbersBet_ShouldBeOk()
        {
            //Cenário
            _bet = ObjectMother.RandomValidBetWithoutId();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().NotThrow<QuantityNumbersBetException>();
        }

        [Test]
        public void Bet_InvalidQuantityNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.NumbersBetOverflow();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().Throw<QuantityNumbersBetException>();
        }

        [Test]
        public void Bet_CalculateBet_Case6BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 3.50;
            _bet = ObjectMother.ValidBetWithId(); //Possui 6 números na aposta = 3.50 reais

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case7BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 24.50;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet.Add(7); //Adiciona mais um número

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case8BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 98.00;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }; //Popula uma nova lista de apostas com 8 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case9BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 294.00;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //Popula uma nova lista de apostas com 9 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case10BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 735.00;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //Popula uma nova lista de apostas com 10 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case11BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 1617.00;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }; //Popula uma nova lista de apostas com 11 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case12BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 3234.00;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; //Popula uma nova lista de apostas com 12 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case13BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 6006.00;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; //Popula uma nova lista de apostas com 13 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case14BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 10510.50;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; //Popula uma nova lista de apostas com 14 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_Case15BetNumbers_ShouldBeOk()
        {
            //Cenário 
            double valueBet = 17517.50;
            _bet = ObjectMother.ValidBetWithId();
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; //Popula uma nova lista de apostas com 15 números

            //Ação e Verificar
            _bet.Value.Should().Be(valueBet);
        }

        [Test]
        public void Bet_CalculateBet_CaseLowerInvalidQuantity_ShouldFail()
        {
            //Cenário
            double invalidBetValue = 0;
            _bet = ObjectMother.LackNumbersBet();

            //Ação e Verificar
            _bet.Value.Should().Be(invalidBetValue);
        }

        [Test]
        public void Bet_CalculateBet_CaseHigherInvalidQuantity_ShouldFail()
        {
            //Cenário
            double invalidBetValue = 0;
            _bet = ObjectMother.NumbersBetOverflow();

            //Ação e Verificar
            _bet.Value.Should().Be(invalidBetValue);
        }

        [Test]
        public void Bet_RepeatedNumbersInList_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.RepeatedNumbersBet();

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().Throw<RepeatedNumberException>();
        }

        [Test]
        public void Bet_ValidContest_ShouldBeOk()
        {
            //Cenário
            _bet = ObjectMother.RandomValidBetWithoutId();
            _bet.Contest = _contestMock.Object;

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().NotThrow<BetEmptyContestException>();
        }

        [Test]
        public void Bet_InvalidContest_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.RandomValidBetWithoutId();
            _bet.Contest = null;

            //Ação
            Action act = () => _bet.Validate();

            //Verificar
            act.Should().Throw<BetEmptyContestException>();
        }

        [TearDown]
        public void TearDown()
        {
            _bet = null;
        }
    }
}
