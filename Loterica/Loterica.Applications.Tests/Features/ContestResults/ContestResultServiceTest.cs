using FluentAssertions;
using Loterica.Applications.Features.ContestResults;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.ContestResults;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Tests.Features.ContestResults
{
    [TestFixture]
    public class ContestResultServiceTest
    {
        ContestResult _contestResult;
        Mock<IContestResultRepository> _mockContestResultRepository;
        ContestResultService _contestResultService;

        [SetUp]
        public void Initialize()
        {
            _contestResult = ObjectMother.ContestResultWithBet();
            _mockContestResultRepository = new Mock<IContestResultRepository>();
            _contestResultService = new ContestResultService(_mockContestResultRepository.Object);
        }

        [Test]
        public void ContestResult_Add_ShouldBeOk()
        {
            //Cenário
            _mockContestResultRepository.Setup(rp => rp.Save(_contestResult)).Returns(_contestResult);

            //Ação
            ContestResult savedContestResult = _contestResultService.Add(_contestResult);

            //Verificar
            savedContestResult.Should().Be(_contestResult);
            _mockContestResultRepository.Verify(rp => rp.Save(_contestResult));
        }

        [Test]
        public void ContestResult_AddEmptyContest_ShouldFail()
        {
            //Cenário
            _contestResult.Contest = null;
            _mockContestResultRepository.Setup(rp => rp.Save(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Add(_contestResult);

            //Verificar
            act.Should().Throw<ContestResultEmptyContestException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_AddInvalidContestPrize_ShouldFail()
        {
            //Cenário
            _contestResult.Bets.Clear(); //Limpa listas para Total Prize retornar um valor 0
            _mockContestResultRepository.Setup(rp => rp.Save(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Add(_contestResult);

            //Verificar
            act.Should().Throw<InvalidContestPrizeException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_AddBetDateHigherThanContestResultDate_ShouldFail()
        {
            //Cenário
            _contestResult.Bets.First().BetDate = DateTime.Now.AddDays(2);
            _mockContestResultRepository.Setup(rp => rp.Save(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Add(_contestResult);

            //Verificar
            act.Should().Throw<BetDateHigherThanContestResultDateException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_AddContestDateHigherThanContestResultDate_ShouldFail()
        {
            //Cenário
            _contestResult.Contest.ContestDate = DateTime.Now.AddDays(2);
            _mockContestResultRepository.Setup(rp => rp.Save(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Add(_contestResult);

            //Verificar
            act.Should().Throw<ContestDateHigherThanContestResultDateException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_AddInvalidWinnerNumbers_ShouldFail()
        {
            //Cenário
            _contestResult.WinnerNumbers = new List<int>() { 1, 1, 4, 4, 6, 9 };
            _mockContestResultRepository.Setup(rp => rp.Save(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Add(_contestResult);

            //Verificar
            act.Should().Throw<InvalidWinnerNumbersException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_Update_ShouldBeOk()
        {
            //Cenário
            _mockContestResultRepository.Setup(rp => rp.Update(_contestResult)).Returns(_contestResult);

            //Ação
            ContestResult updatedContestResult = _contestResultService.Update(_contestResult);

            //Verificar
            updatedContestResult.Should().Be(_contestResult);
            _mockContestResultRepository.Verify(rp => rp.Update(_contestResult));
        }

        [Test]
        public void ContestResult_UpdateEmptyContest_ShouldFail()
        {
            //Cenário
            _contestResult.Contest = null;
            _mockContestResultRepository.Setup(rp => rp.Update(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Update(_contestResult);

            //Verificar
            act.Should().Throw<ContestResultEmptyContestException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_UpdateInvalidContestPrize_ShouldFail()
        {
            //Cenário
            _contestResult.Bets.Clear(); //Limpa listas para Total Prize retornar um valor 0
            _mockContestResultRepository.Setup(rp => rp.Update(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Update(_contestResult);

            //Verificar
            act.Should().Throw<InvalidContestPrizeException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_UpdateBetDateHigherThanContestResultDate_ShouldFail()
        {
            //Cenário
            _contestResult.Bets.First().BetDate = DateTime.Now.AddDays(2);
            _mockContestResultRepository.Setup(rp => rp.Update(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Update(_contestResult);

            //Verificar
            act.Should().Throw<BetDateHigherThanContestResultDateException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_UpdateContestDateHigherThanContestResultDate_ShouldFail()
        {
            //Cenário
            _contestResult.Contest.ContestDate = DateTime.Now.AddDays(2);
            _mockContestResultRepository.Setup(rp => rp.Update(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Update(_contestResult);

            //Verificar
            act.Should().Throw<ContestDateHigherThanContestResultDateException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_UpdateInvalidWinnerNumbers_ShouldFail()
        {
            //Cenário
            _contestResult.WinnerNumbers = new List<int>() { 1, 1, 4, 4, 6, 9 };
            _mockContestResultRepository.Setup(rp => rp.Update(_contestResult)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Update(_contestResult);

            //Verificar
            act.Should().Throw<InvalidWinnerNumbersException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_Delete_ShouldBeOk()
        {
            //Cenário
            _mockContestResultRepository.Setup(rp => rp.Delete(_contestResult));

            //Ação
            _contestResultService.Delete(_contestResult);
            Action act = () => _contestResultService.Delete(_contestResult);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
            _mockContestResultRepository.Verify(rp => rp.Delete(_contestResult));
        }

        [Test]
        public void ContestResult_DeleteInvalidContestResultId_ShouldFail()
        {
            //Cenário
            _contestResult.Id = 0;
            _mockContestResultRepository.Setup(rp => rp.Delete(_contestResult));

            //Ação
            Action act = () => _contestResultService.Delete(_contestResult);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_Get_ShouldBeOk()
        {
            //Cenário
            _mockContestResultRepository.Setup(rp => rp.Get(_contestResult.Id)).Returns(_contestResult);

            //Ação
            ContestResult getContestResult = _contestResultService.Get(_contestResult);

            //Verificar
            getContestResult.Should().Be(_contestResult);
            _mockContestResultRepository.Verify(rp => rp.Get(_contestResult.Id));
        }

        [Test]
        public void ContestResult_GetInvalidContestResultId_ShouldFail()
        {
            //Cenário
            _contestResult.Id = 0;
            _mockContestResultRepository.Setup(rp => rp.Get(_contestResult.Id)).Returns(_contestResult);

            //Ação
            Action act = () => _contestResultService.Get(_contestResult);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockContestResultRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ContestResult_GetAll_ShouldBeOk()
        {
            //Cenário
            _mockContestResultRepository.Setup(rp => rp.GetAll()).Returns(new List<ContestResult>() { _contestResult });

            //Ação
            IEnumerable<ContestResult> contestResultList = _contestResultService.GetAll();

            //Verificar
            contestResultList.Should().NotBeNull();
            contestResultList.Should().HaveCount(1);
            contestResultList.First().Should().Be(_contestResult);
            _mockContestResultRepository.Verify(rp => rp.GetAll());
        }

        [TearDown]
        public void TearDown()
        {
            _contestResult = null;
            _mockContestResultRepository = null;
            _contestResultService = null;
        }
    }
}
