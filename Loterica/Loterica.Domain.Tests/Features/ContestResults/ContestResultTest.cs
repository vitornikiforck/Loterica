using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Features.Bets;
using Loterica.Domain.Features.ContestResults;
using Loterica.Domain.Features.Contests;
using Loterica.Domain.Features.GroupBets;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Tests.Features.ContestResults
{
    [TestFixture]
    public class ContestResultTest
    {
        ContestResult _contestResult;
        Mock<Contest> _mockContest;
        Mock<Bet> _mockBet;

        [SetUp]
        public void Initialize()
        {
            _contestResult = ObjectMother.ContestResultWithoutId();
            _mockContest = new Mock<Contest>();
            _mockBet = new Mock<Bet>();

            _contestResult.Bets.Add(_mockBet.Object);
            _contestResult.Contest = _mockContest.Object;
        }

        [Test]
        public void ContestResult_ValidContest_ShouldBeOk()
        {
            //Cenário e Ação 
            Action act = () => _contestResult.Validate();

            //Verificar
            act.Should().NotThrow<ContestResultEmptyContestException>();
        }

        [Test]
        public void ContestResult_EmptyContest_ShouldFail()
        {
            //Cenário
            _contestResult.Contest = null;

            //Ação
            Action act = () => _contestResult.Validate();

            //Verificar
            act.Should().Throw<ContestResultEmptyContestException>();
        }

        [Test]
        public void ContestResult_ValidTotalPrize_ShouldBeOk()
        {
            //Cenário
            double betPrice = 3.50;
            _mockBet.Setup(bet => bet.Value).Returns(betPrice);

            //Ação e Verificar
            _contestResult.TotalPrize.Should().Be(betPrice);
        }

        [Test]
        public void ContestResult_InvalidTotalPrize_ShouldFail()
        {
            //Cenário
            _contestResult.Bets.Clear();

            //Ação
            Action act = () => _contestResult.Validate();

            //Verificar
            act.Should().Throw<InvalidContestPrizeException>();
        }

        [Test]
        public void ContestResult_ValidContestResultDate_ShouldBeOk()
        {
            //Cenário
            _mockBet.Setup(bet => bet.BetDate).Returns(DateTime.Now);
            _mockContest.Setup(cont => cont.ContestDate).Returns(DateTime.Now);

            //Ação
            Action act = () => _contestResult.Validate();

            //Verificar
            act.Should().NotThrow<ContestDateHigherThanContestResultDateException>();
            act.Should().NotThrow<BetDateHigherThanContestResultDateException>();
        }

        [Test]
        public void ContestResult_ContestResultDateLowerThanBetDate_ShouldFail()
        {
            //Cenário
            _mockBet.Setup(bet => bet.BetDate).Returns(DateTime.Now.AddDays(20));

            //Ação
            Action act = () => _contestResult.Validate();

            //Verificar
            act.Should().Throw<BetDateHigherThanContestResultDateException>();
        }

        [Test]
        public void ContestResult_ContestResultDateLowerThanContestDate_ShouldFail()
        {
            //Cenário
            _mockContest.Setup(cont => cont.ContestDate).Returns(DateTime.Now.AddDays(28));

            //Ação
            Action act = () => _contestResult.Validate();

            //Verificar
            act.Should().Throw<ContestDateHigherThanContestResultDateException>();
        }

        [Test]
        public void ContestResult_WinnerNumbers_ShouldBeOk()
        {
            //Cenário
            _contestResult.WinnerNumbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            //Ação
            Action act = () => _contestResult.Validate();

            //Cenário
            act.Should().NotThrow<InvalidWinnerNumbersException>();
        }

        [Test]
        public void ContestResult_InvalidWinnerNumbers_ShouldFail()
        {
            //Cenário
            _contestResult.WinnerNumbers = new List<int>() { 1, 1, 4, 4, 9, 9 };

            //Ação
            Action act = () => _contestResult.Validate();

            //Cenário
            act.Should().Throw<InvalidWinnerNumbersException>();
        }

        [Test]
        public void ContestResult_PickContestWinnerNumbers_ShouldBeOk()
        {
            //Cenário e Ação
            int quantityOfWinnerNumbers = 6;
            _contestResult.WinnerNumbers = _contestResult.PickContestWinnerNumbers();

            //Verificar
            _contestResult.WinnerNumbers.Distinct().Count().Should().Be(quantityOfWinnerNumbers);
        }

        [TearDown]
        public void TearDown()
        {
            _contestResult = null;
            _mockContest = null;
            _mockBet = null;
        }
    }
}
