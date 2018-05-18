using FluentAssertions;
using Loterica.Applications.Features.GroupBets;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.Bets;
using Loterica.Domain.Features.GroupBets;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Tests.Features.GroupBets
{
    [TestFixture]
    public class GroupBetServiceTest
    {
        GroupBet _groupBet;
        Mock<IGroupBetRepository> _mockGroupBetRepository;
        GroupBetService _groupBetService;

        [SetUp]
        public void Initialize()
        {
            _groupBet = ObjectMother.GroupBetWithBet();
            _mockGroupBetRepository = new Mock<IGroupBetRepository>();
            _groupBetService = new GroupBetService(_mockGroupBetRepository.Object);
        }

        [Test]
        public void GroupBet_Add_ShouldBeOk()
        {
            //Cenário
            _mockGroupBetRepository.Setup(rp => rp.Save(_groupBet)).Returns(_groupBet);

            //Ação
            GroupBet savedGroupBet = _groupBetService.Add(_groupBet);

            //Verificar
            savedGroupBet.Should().Be(_groupBet);
            _mockGroupBetRepository.Verify(rp => rp.Save(_groupBet));
        }

        [Test]
        public void GroupBet_Add_InvalidCreateGroupBetDate_ShouldFail()
        {
            //Cenário
            _groupBet.CreateDate = DateTime.Now.AddDays(1);
            _mockGroupBetRepository.Setup(rp => rp.Save(_groupBet)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Add(_groupBet);

            //Verificar
            act.Should().Throw<InvalidCreateGroupBetDateException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Add_InvalidOrganizerException_ShouldFail()
        {
            //Cenário
            _groupBet.Organizer = "";
            _mockGroupBetRepository.Setup(rp => rp.Save(_groupBet)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Add(_groupBet);

            //Verificar
            act.Should().Throw<InvalidOrganizerException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Add_GroupBetEmptyBetsException_ShouldFail()
        {
            //Cenário
            _groupBet.Bets.Clear();
            _mockGroupBetRepository.Setup(rp => rp.Save(_groupBet)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Add(_groupBet);

            //Verificar
            act.Should().Throw<GroupBetEmptyBetsException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Update_ShouldBeOk()
        {
            //cenário
            _groupBet.Organizer = "Lotérica";
            _mockGroupBetRepository.Setup(rp => rp.Update(_groupBet)).Returns(_groupBet);

            //Ação
            GroupBet updatedGroupBet = _groupBetService.Update(_groupBet);

            //Verificar
            updatedGroupBet.Should().Be(_groupBet);
            _mockGroupBetRepository.Verify(rp => rp.Update(_groupBet));
        }

        [Test]
        public void GroupBet_Update_InvalidCreateGroupBetDate_ShouldFail()
        {
            //Cenário
            _groupBet.CreateDate = DateTime.Now.AddDays(1);
            _mockGroupBetRepository.Setup(rp => rp.Update(_groupBet)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Update(_groupBet);

            //Verificar
            act.Should().Throw<InvalidCreateGroupBetDateException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Update_InvalidOrganizerException_ShouldFail()
        {
            //Cenário
            _groupBet.Organizer = "";
            _mockGroupBetRepository.Setup(rp => rp.Update(_groupBet)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Update(_groupBet);

            //Verificar
            act.Should().Throw<InvalidOrganizerException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Update_GroupBetEmptyBetsException_ShouldFail()
        {
            //Cenário
            _groupBet.Bets.Clear();
            _mockGroupBetRepository.Setup(rp => rp.Update(_groupBet)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Update(_groupBet);

            //Verificar
            act.Should().Throw<GroupBetEmptyBetsException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Delete_ShouldBeOk()
        {
            //Cenário
            _mockGroupBetRepository.Setup(rp => rp.Delete(_groupBet));

            //Ação
            _groupBetService.Delete(_groupBet);
            Action act = () => _groupBetService.Delete(_groupBet);

            //Verificar
            _mockGroupBetRepository.Verify(rp => rp.Delete(_groupBet));
            act.Should().NotThrow<IdentifierUndefinedException>();
        }

        [Test]
        public void GroupBet_DeleteInvalidGroupBetId_ShouldFail()
        {
            //Cenário
            _groupBet.Id = 0;
            _mockGroupBetRepository.Setup(rp => rp.Delete(_groupBet));

            //Ação
            Action act = () => _groupBetService.Delete(_groupBet);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_Get_ShouldBeOk()
        {
            //Cenário
            _mockGroupBetRepository.Setup(rp => rp.Get(_groupBet.Id)).Returns(_groupBet);

            //Ação
            GroupBet getGroupBet = _groupBetService.Get(_groupBet);

            //Verificar
            getGroupBet.Should().Be(_groupBet);
            _mockGroupBetRepository.Verify(rp => rp.Get(_groupBet.Id));
        }

        [Test]
        public void GroupBet_GetInvalidGroupBetId_ShouldFail()
        {
            //Cenário
            _groupBet.Id = 0;
            _mockGroupBetRepository.Setup(rp => rp.Get(_groupBet.Id)).Returns(_groupBet);

            //Ação
            Action act = () => _groupBetService.Get(_groupBet);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockGroupBetRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void GroupBet_GetAll_ShouldBeOk()
        {
            //Cenário
            _mockGroupBetRepository.Setup(rp => rp.GetAll()).Returns(new List<GroupBet>() { _groupBet });

            //Ação
            IEnumerable<GroupBet> groupBets = _groupBetService.GetAll();

            //Verificar
            groupBets.Should().NotBeNullOrEmpty();
            groupBets.Count().Should().Be(1);
            groupBets.First().Should().Be(_groupBet);
            _mockGroupBetRepository.Verify(rp => rp.GetAll());
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
