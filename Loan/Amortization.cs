using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan
{
    public class Amortization
    {
        public int Pmt { get; set; }
        public DateTime Date { get; set; }
        public double Interest { get; set; }
        public double LoanBalance { get; set; }       
        public double Principal { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPrincipal { get; set; }

        public override string ToString()
        {
            return string.Concat(this.Pmt, " - ", this.Date.ToString("MMMM d, yyyy"), " - ", this.LoanBalance.ToString("C0"), " - ", this.Interest.ToString("C0"), " - ", this.Principal.ToString("C0"), " - ", this.TotalInterest.ToString("C0"));
        }
    }
}
