using Loterica.Domain.Features.Contests;
using Loterica.Domain.Features.GroupBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public class Bet
    {
        public long Id { get; set; }
        public virtual DateTime BetDate { get; set; }
        public List<int> NumbersBet { get; set; }
        public virtual double Value { get { return CalculateBet(); } }
        public Contest Contest { get; set; }
        public GroupBet GroupBet { get; set; }

        public void Validate()
        {
            if (Value == 0)
                throw new QuantityNumbersBetException();
            if (BetDate > DateTime.Now)
                throw new InvalidBetDateException();
            foreach (int i in NumbersBet)
                if (i > 60 || i == 0)
                    throw new InvalidNumbersBetException();
            if (NumbersBet.Distinct().Count() != NumbersBet.Count())
                throw new RepeatedNumberException();
            if (Contest == null)
                throw new BetEmptyContestException();
        }

        protected double CalculateBet()
        {
            switch (NumbersBet.Count)
            {
                case 6:
                    return 3.50;
                case 7:
                    return 24.50;
                case 8:
                    return 98.00;
                case 9:
                    return 294.00;
                case 10:
                    return 735.00;
                case 11:
                    return 1617.00;
                case 12:
                    return 3234.00;
                case 13:
                    return 6006.00;
                case 14:
                    return 10510.50;
                case 15:
                    return 17517.50;
                default: return 0;
            }
        }
    }
}
