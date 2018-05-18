using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.Bets;
using Loterica.Infra.Data.Features.Bets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Infra.Data.Tests.Features.Bets
{
    [TestFixture]
    public class BetSqlRepositoryTest
    {
        private int _seedId = 1;
        private int _invalidId = 0;

        Bet _bet;
        IBetRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _bet = ObjectMother.RandomValidBetWithoutId();
            _repository = new BetSqlRepository();
        }

        [Test]
        public void BetSqlRepository_Save_ShouldBeOk()
        {
            //Cenário e Ação
            _bet.Contest = ObjectMother.ValidContestWithId();
            Bet savedBet = _repository.Save(_bet);

            //Verificar
            savedBet.Should().Be(_bet);
            savedBet.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void BetSqlRepository_SaveInvalidQuantityNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidQuantityNumbersBet();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Save(_bet);

            //Verificar
            act.Should().Throw<QuantityNumbersBetException>();
        }

        [Test]
        public void BetSqlRepository_SaveInvalidBetDate_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidBetDate();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Save(_bet);

            //Verificar
            act.Should().Throw<InvalidBetDateException>();
        }

        [Test]
        public void BetSqlRepository_SaveInvalidNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidNumbersBet();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Save(_bet);

            //Verificar
            act.Should().Throw<InvalidNumbersBetException>();
        }

        [Test]
        public void BetSqlRepository_SaveRepeatedNumber_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.RepeatedNumbersBet();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Save(_bet);

            //Verificar
            act.Should().Throw<RepeatedNumberException>();
        }

        [Test]
        public void BetSqlRepository_SaveEmptyContest_ShouldFail()
        {
            //Cenário
            _bet.Contest = null;

            //Ação
            Action act = () => _repository.Save(_bet);

            //Verificar
            act.Should().Throw<BetEmptyContestException>();
        }

        [Test]
        public void BetSqlRepository_Update_ShouldBeOk()
        {
            //Cenário
            _bet.Id = _seedId;
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            _repository.Update(_bet);

            //Verificar
            Bet updatedBet = _repository.Get(_bet.Id);
            updatedBet.Id.Should().Be(_bet.Id);
            updatedBet.Contest.Id.Should().Be(_bet.Contest.Id);
            updatedBet.NumbersBet.Should().BeEquivalentTo(_bet.NumbersBet);
        }

        [Test]
        public void BetSqlRepository_UpdateInvalidQuantityNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidQuantityNumbersBet();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Update(_bet);

            //Verificar
            act.Should().Throw<QuantityNumbersBetException>();
        }

        [Test]
        public void BetSqlRepository_UpdateInvalidBetDate_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidBetDate();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Update(_bet);

            //Verificar
            act.Should().Throw<InvalidBetDateException>();
        }

        [Test]
        public void BetSqlRepository_UpdateInvalidNumbersBet_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.InvalidNumbersBet();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Update(_bet);

            //Verificar
            act.Should().Throw<InvalidNumbersBetException>();
        }

        [Test]
        public void BetSqlRepository_UpdateRepeatedNumber_ShouldFail()
        {
            //Cenário
            _bet = ObjectMother.RepeatedNumbersBet();
            _bet.Contest = ObjectMother.ValidContestWithId();

            //Ação
            Action act = () => _repository.Update(_bet);

            //Verificar
            act.Should().Throw<RepeatedNumberException>();
        }

        [Test]
        public void BetSqlRepository_UpdateEmptyContest_ShouldFail()
        {
            //Cenário
            _bet.Contest = null;

            //Ação
            Action act = () => _repository.Update(_bet);

            //Verificar
            act.Should().Throw<BetEmptyContestException>();
        }

        [Test]
        public void BetSqlRepository_Delete_ShouldBeOk()
        {
            //Cenário
            _bet.Id = _seedId;

            //Ação
            _repository.Delete(_bet);

            //Verificar
            _repository.Get(_bet.Id).Should().BeNull();

        }

        [Test]
        public void BetSqlRepository_DeleteInvalidBetId_ShouldFail()
        {
            //Cenário
            _bet.Id = _invalidId;

            //Ação
            Action act = () => _repository.Delete(_bet);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BetSqlRepository_Get_ShouldBeOk()
        {
            //Cenário
            _bet.Id = _seedId;

            //Ação
            Bet getBet = _repository.Get(_seedId);

            //Verificar
            getBet.Should().NotBeNull();
            getBet.Id.Should().BeGreaterThan(0);
            getBet.Id.Should().Be(_seedId);
        }

        [Test]
        public void BetSqlRepository_GetInvalidBetId_ShouldFail()
        {
            //Cenário
            _bet.Id = _invalidId;

            // Ação
            Action act = () => _repository.Get(_bet.Id);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BetSqlRepository_GetAll_ShouldBeOk()
        {
            //Cenário e Ação
            IEnumerable<Bet> betList = _repository.GetAll();

            //Verificar
            betList.Should().HaveCount(1);
            betList.First().Id.Should().Be(_seedId);
        }

        [Test]

        [TearDown]
        public void TearDown()
        {
            _bet = null;
            _repository = null;
        }
    }
}
