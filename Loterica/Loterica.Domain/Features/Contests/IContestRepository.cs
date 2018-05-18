using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Contests
{
    public interface IContestRepository
    {
        Contest Save(Contest contest);
        Contest Update(Contest contest);
        Contest Get(long id);
        IEnumerable<Contest> GetAll();
        void Delete(Contest contest);
    }
}
