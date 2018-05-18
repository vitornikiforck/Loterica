using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Contests
{
    public class Contest
    {
        public long Id { get; set; }
        public virtual DateTime ContestDate { get; set; }

        public void Validate()
        {
            if (ContestDate < DateTime.Now)
                throw new InvalidDateContestException();
        }
    }
}
