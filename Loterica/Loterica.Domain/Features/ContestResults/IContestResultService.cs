using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public interface IContestResultService
    {
        ContestResult Add(ContestResult contestResult);
        ContestResult Update(ContestResult contestResult);
        ContestResult Get(ContestResult contestResult);
        IEnumerable<ContestResult> GetAll();
        void Delete(ContestResult contestResult);
    }
}
