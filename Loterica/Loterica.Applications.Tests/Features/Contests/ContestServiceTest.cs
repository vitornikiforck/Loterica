using FluentAssertions;
using Loterica.Applications.Features.Contests;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.Contests;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Tests.Features.Contests
{
    [TestFixture]
    public class ContestServiceTest
    {
        Contest _contest;
        ContestService _contestService;
        Mock<IContestRepository> _mockContestRepository;

        [SetUp]
        public void Initialize()
        {
            _contest = ObjectMother.ValidContestWithoutId();
            _mockContestRepository = new Mock<IContestRepository>();
            _contestService = new ContestService(_mockContestRepository.Object);
        }

        [Test]
        public void Contest_Add_ShouldBeOk()
        {
            //Cenário
            _mockContestRepository.Setup(rp => rp.Save(_contest)).Returns(_contest);

            //Ação
            Contest savedContest = _contestService.Add(_contest);

            //Verificar
            savedContest.Should().Be(_contest);
            _mockContestRepository.Verify(rp => rp.Save(_contest));
        }

        [Test]
        public void Contest_AddInvalidDateContest_ShouldFail()
        {
            //Cenário
            _contest.ContestDate = DateTime.Now.AddDays(-1);
            _mockContestRepository.Setup(rp => rp.Save(_contest)).Returns(_contest);

            //Ação
            Action act = () => _contestService.Add(_contest);

            //Verificar
            act.Should().Throw<InvalidDateContestException>();
            _mockContestRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_Update_ShouldBeOk()
        {
            //Cenário
            _mockContestRepository.Setup(rp => rp.Update(_contest)).Returns(_contest);

            //Ação
            Contest savedContest = _contestService.Update(_contest);

            //Verificar
            savedContest.Should().Be(_contest);
            _mockContestRepository.Verify(rp => rp.Update(_contest));
        }

        [Test]
        public void Contest_UpdateInvalidDateContest_ShouldFail()
        {
            //Cenário
            _contest.ContestDate = DateTime.Now.AddDays(-1);
            _mockContestRepository.Setup(rp => rp.Update(_contest)).Returns(_contest);

            //Ação
            Action act = () => _contestService.Update(_contest);

            //Verificar
            act.Should().Throw<InvalidDateContestException>();
            _mockContestRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_Delete_ShouldBeOk()
        {
            //Cenário
            _contest = ObjectMother.ValidContestWithId();
            _mockContestRepository.Setup(rp => rp.Delete(_contest));

            //Ação
            _contestService.Delete(_contest);
            Action act = () => _contestService.Delete(_contest);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
            _mockContestRepository.Verify(rp => rp.Delete(_contest));
        }

        [Test]
        public void Contest_DeleteInvalidContestId_ShouldBFail()
        {
            //Cenário
            _contest.Id = 0;
            _mockContestRepository.Setup(rp => rp.Delete(_contest));

            //Ação
            Action act = () => _contestService.Delete(_contest);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockContestRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_Get_ShouldBeOk()
        {
            //Cenário
            _contest = ObjectMother.ValidContestWithId();
            _mockContestRepository.Setup(rp => rp.Get(_contest.Id)).Returns(_contest);

            //Ação
            Contest getContest = _contestService.Get(_contest);

            //Verificar
            getContest.Should().Be(_contest);
            _mockContestRepository.Verify(rp => rp.Get(_contest.Id));
        }

        [Test]
        public void Contest_GetInvalidContestId_ShouldFail()
        {
            //Cenário
            _contest.Id = 0;
            _mockContestRepository.Setup(rp => rp.Get(_contest.Id)).Returns(_contest);

            //Ação
            Action act = () => _contestService.Get(_contest);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockContestRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_GetAll_ShouldBeOk()
        {
            //Cenário
            _mockContestRepository.Setup(rp => rp.GetAll()).Returns(new List<Contest> { _contest });

            //Ação
            IEnumerable<Contest> contests = _contestService.GetAll();

            //Verificar
            contests.Should().NotBeNull();
            contests.Count().Should().BeGreaterThan(0);
            contests.Should().HaveCount(1);
            contests.First().Should().Be(_contest);
            _mockContestRepository.Verify(rp => rp.GetAll());
        }

        [TearDown]
        public void TearDown()
        {
            _contest = null;
            _mockContestRepository = null;
            _contestService = null;
        }
    }
}
