using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public interface IContestResultRepository
    {
        ContestResult Save(ContestResult contestResult);
        ContestResult Update(ContestResult contestResult);
        ContestResult Get(long id);
        IEnumerable<ContestResult> GetAll();
        void Delete(ContestResult contestResult);
    }
}
