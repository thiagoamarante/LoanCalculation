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
        public double PropertyTax { get; set; }       
        public double CondoTax { get; set; }
        public double Insurance { get; set; }
        public DateTime StartLoan { get; set; }        
    }
}
