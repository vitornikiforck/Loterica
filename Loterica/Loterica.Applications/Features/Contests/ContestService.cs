using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Features.Contests
{
    public class ContestService : IContestService
    {
        IContestRepository _contestRepository;

        public ContestService(IContestRepository contestRepository)
        {
            _contestRepository = contestRepository;
        }

        public Contest Add(Contest contest)
        {
            contest.Validate();
            return _contestRepository.Save(contest);
        }

        public void Delete(Contest contest)
        {
            if (contest.Id == 0)
                throw new IdentifierUndefinedException();

            _contestRepository.Delete(contest);
        }

        public Contest Get(Contest contest)
        {
            if (contest.Id == 0)
                throw new IdentifierUndefinedException();

            return _contestRepository.Get(contest.Id);
        }

        public IEnumerable<Contest> GetAll()
        {
            return _contestRepository.GetAll();
        }

        public Contest Update(Contest contest)
        {
            contest.Validate();
            return _contestRepository.Update(contest);
        }
    }
}
