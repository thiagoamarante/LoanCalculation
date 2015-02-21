using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan
{
    public class Summary : Parameters
    {
        public Summary()
        {
            this.Amortization = new List<Amortization>();
        }

        public int LoanTermMonths { get; set; }
        public double DownPaymentPercent { get; set; }

        public double TwentyPercent { get; set; }
        public double LoanAmount { get; set; }
        public double LoanAmountPercent { get; set; }
               
        public double TotalPayment { get; set; }
        public double MonthlyMortgage { get; set; }
        public double InitialInterest { get; set; }

        public DateTime EndLoan { get; set; }

        public double TotalInterest { get; set; }

        public List<Amortization> Amortization { get; set; }
    }
}
