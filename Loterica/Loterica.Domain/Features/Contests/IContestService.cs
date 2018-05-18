using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Contests
{
    public interface IContestService
    {
        Contest Add(Contest contest);
        Contest Update(Contest contest);
        Contest Get(Contest contest);
        IEnumerable<Contest> GetAll();
        void Delete(Contest contest);
    }
}
