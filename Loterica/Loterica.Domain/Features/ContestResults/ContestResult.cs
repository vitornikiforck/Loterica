using Loterica.Domain.Features.Bets;
using Loterica.Domain.Features.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public class ContestResult
    {
        public long Id { get; set; }
        public Contest Contest { get; set; }
        public List<Bet> Bets { get; set; }
        public virtual double TotalPrize { get { return SumPrize(); } }
        public DateTime ContestResultDate { get; set; }
        public virtual List<int> WinnerNumbers { get; set; }

        public void Validate()
        {
            if (Contest == null)
                throw new ContestResultEmptyContestException();
            if (Bets.Count() == 0)
                throw new InvalidContestPrizeException();
            foreach (Bet b in Bets)
                if (b.BetDate > ContestResultDate)
                    throw new BetDateHigherThanContestResultDateException();
            if (Contest.ContestDate > ContestResultDate)
                throw new ContestDateHigherThanContestResultDateException();
            if (WinnerNumbers.Distinct().Count() != WinnerNumbers.Count())
                throw new InvalidWinnerNumbersException();
        }

        public double SumPrize()
        {
            double totalPrize = 0;

            foreach (Bet b in Bets)
                totalPrize += b.Value;

            return totalPrize;
        }

        public List<int> PickContestWinnerNumbers()
        {
            Random random = new Random();
            List<int> winnerNumbers = new List<int>();

            int i = 0;
            while (i < 6)
            {
                int number = random.Next(1, 61);

                if (!winnerNumbers.Contains(number))
                {
                    winnerNumbers.Add(number);
                    i++;
                }
            }

            return winnerNumbers;
        }
    }
}
