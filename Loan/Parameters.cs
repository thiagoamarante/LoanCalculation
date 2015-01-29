using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan
{
    public class Parameters
    {
        public int LoanTerm { get; set; }
        public double InterestRate { get; set; }
        public double PropertyValue { get; set; }
        public double DownPayment { get; set; }
        public double PropertyTaxPercent { get; set; }
        public double PMIPercent { get; set; }
        public DateTime StartLoan { get; set; }
    }
}
