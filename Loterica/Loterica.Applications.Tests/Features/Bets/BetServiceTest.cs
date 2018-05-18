using FluentAssertions;
using Loterica.Applications.Features.Bets;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Exceptions;
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

namespace Loterica.Applications.Tests.Features.Bets
{
    [TestFixture]
    public class BetServiceTest
    {
        Bet _bet;
        BetService _betService;
        Mock<IBetRepository> _mockBetRepository;

        [SetUp]
        public void Initialize()
        {
            _bet = ObjectMother.ValidBetWithContest();

            _mockBetRepository = new Mock<IBetRepository>();
            _betService = new BetService(_mockBetRepository.Object);
        }

        [Test]
        public void BetService_Add_ShouldBeOk()
        {
            //Cenário
            _mockBetRepository.Setup(rp => rp.Save(_bet)).Returns(_bet);

            //Ação
            Bet savedBet = _betService.Add(_bet);

            //Verificar
            _bet.Should().Be(savedBet);
            _mockBetRepository.Verify(rp => rp.Save(_bet));
        }

        [Test]
        public void BetService_InvalidNumbersBetQuantity_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.LackNumbersBet();
            _mockBetRepository.Setup(rp => rp.Save(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Add(_bet);

            //Verificar
            _mockBetRepository.VerifyNoOtherCalls();
            act.Should().Throw<QuantityNumbersBetException>();
        }

        [Test]
        public void BetService_AddInvalidBetDate_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidBetDate();
            _mockBetRepository.Setup(rp => rp.Save(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Add(_bet);

            //Verificar
            act.Should().Throw<InvalidBetDateException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_AddInvalidNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidNumbersBet();
            _mockBetRepository.Setup(rp => rp.Save(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Add(_bet);

            //Verificar
            act.Should().Throw<InvalidNumbersBetException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_AddRepeatedNumbers_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.RepeatedNumbersBet();
            _mockBetRepository.Setup(rp => rp.Save(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Add(_bet);

            //Verificar       
            act.Should().Throw<RepeatedNumberException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_AddEmptyContest_ShouldFail()
        {
            //Cenário
            _bet.Contest = null;
            _mockBetRepository.Setup(rp => rp.Save(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Add(_bet);

            //Verificar
            act.Should().Throw<BetEmptyContestException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_UpdateBet_ShouldBeOk()
        {
            //Cenário
            _bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 9 };
            _mockBetRepository.Setup(rp => rp.Update(_bet)).Returns(_bet);

            //Ação
            Bet updatedBet = _betService.Update(_bet);

            //Verificar
            _mockBetRepository.Verify(rp => rp.Update(_bet));
            updatedBet.Should().Be(_bet);
        }

        [Test]
        public void BetService_UpdateInvalidNumbersBetQuantity_ShouldFail()
        {
            //Ação
            _bet = ObjectMother.NumbersBetOverflow();
            _mockBetRepository.Setup(rp => rp.Update(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Update(_bet);

            //Verificar
            act.Should().Throw<QuantityNumbersBetException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_UpdateInvalidBetDate_ShouldFail()
        {
            //Ação
            _bet = ObjectMother.InvalidBetDate();
            _mockBetRepository.Setup(rp => rp.Update(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Update(_bet);

            //Verificar
            act.Should().Throw<InvalidBetDateException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_UpdateInvalidNumbersBet_ShouldFail()
        {
            //Ação
            _bet = ObjectMother.InvalidNumbersBet();
            _mockBetRepository.Setup(rp => rp.Update(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Update(_bet);

            //Verificar
            act.Should().Throw<InvalidNumbersBetException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_UpdateRepeatedNumbers_ShouldFail()
        {
            //Ação
            _bet = ObjectMother.RepeatedNumbersBet();
            _mockBetRepository.Setup(rp => rp.Update(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Update(_bet);

            //Verificar
            act.Should().Throw<RepeatedNumberException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_UpdateEmptyBet_ShouldFail()
        {
            //Ação
            _bet.Contest = null;
            _mockBetRepository.Setup(rp => rp.Update(_bet)).Returns(_bet);

            //Ação
            Action act = () => _betService.Update(_bet);

            //Verificar
            act.Should().Throw<BetEmptyContestException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_DeleteBet_ShouldBeOk()
        {
            //Cenário
            _mockBetRepository.Setup(rp => rp.Delete(_bet));

            //Ação
            _betService.Delete(_bet);
            Action act = () => _betService.Delete(_bet);

            //Verificar
            _mockBetRepository.Verify(rp => rp.Delete(_bet));
            act.Should().NotThrow<IdentifierUndefinedException>();
        }

        [Test]
        public void BetService_DeleteInvalidBetId_ShouldFail()
        {
            //Cenário
            _bet.Id = 0;
            _mockBetRepository.Setup(rp => rp.Delete(_bet));

            //Ação
            Action act = () => _betService.Delete(_bet);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_GetBet_ShouldBeOk()
        {
            //Cenário
            _mockBetRepository.Setup(rp => rp.Get(_bet.Id)).Returns(_bet);

            //Ação
            Bet getBet = _betService.Get(_bet);

            //Verificar
            getBet.Should().Be(_bet);
            _mockBetRepository.Verify(rp => rp.Get(_bet.Id));
        }

        [Test]
        public void BetService_GetInvalidBetId_ShouldFail()
        {
            //Cenário
            _bet.Id = 0;
            _mockBetRepository.Setup(rp => rp.Get(_bet.Id)).Returns(_bet);

            //Ação
            Action act = () => _betService.Get(_bet);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BetService_GetAll_ShouldBeOk()
        {
            //Cenário
            _mockBetRepository.Setup(rp => rp.GetAll()).Returns(new List<Bet>() { _bet });

            //Ação
            IEnumerable<Bet> getAllBets = _betService.GetAll();

            //Verificar
            getAllBets.Should().NotBeNull();
            getAllBets.Should().HaveCount(1);
            getAllBets.First().Should().Be(_bet);
            _mockBetRepository.Verify(rp => rp.GetAll());
        }

        [TearDown]
        public void TearDown()
        {
            _bet = null;
            _mockBetRepository = null;
            _betService = null;
        }
    }
}
