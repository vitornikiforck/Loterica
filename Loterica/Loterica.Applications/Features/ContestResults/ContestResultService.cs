using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.ContestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Features.ContestResults
{
    public class ContestResultService : IContestResultService
    {
        IContestResultRepository _contestResultRepository;

        public ContestResultService(IContestResultRepository contestRepository)
        {
            _contestResultRepository = contestRepository;
        }

        public ContestResult Add(ContestResult contestResult)
        {
            contestResult.Validate();
            return _contestResultRepository.Save(contestResult);
        }

        public void Delete(ContestResult contestResult)
        {
            if (contestResult.Id == 0)
                throw new IdentifierUndefinedException();

            _contestResultRepository.Delete(contestResult);
        }

        public ContestResult Get(ContestResult contestResult)
        {
            if (contestResult.Id == 0)
                throw new IdentifierUndefinedException();

            return _contestResultRepository.Get(contestResult.Id);
        }

        public IEnumerable<ContestResult> GetAll()
        {
            return _contestResultRepository.GetAll();
        }

        public ContestResult Update(ContestResult contestResult)
        {
            contestResult.Validate();
            return _contestResultRepository.Update(contestResult);
        }
    }
}
