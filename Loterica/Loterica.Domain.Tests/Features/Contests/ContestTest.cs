using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Domain.Features.Contests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Tests.Features.Contests
{
    [TestFixture]
    public class ContestTest
    {
        Contest _contest;

        [SetUp]
        public void Initialize()
        {
            _contest = new Contest();
        }

        [Test]
        public void Contest_ValidDateContest_ShouldBeOk()
        {
            //Cenário
            _contest = ObjectMother.ValidContestWithoutId();

            //Ação
            Action act = () => _contest.Validate();

            //Verificar
            act.Should().NotThrow<InvalidDateContestException>();
        }

        [Test]
        public void Contest_InvalidDateContest_ShouldBeOk()
        {
            //Cenário
            _contest = ObjectMother.InvalidContestWithoutId();

            //Ação
            Action act = () => _contest.Validate();

            //Verificar
            act.Should().Throw<InvalidDateContestException>();
        }
    }
}
