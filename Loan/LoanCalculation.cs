using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan
{
    public class LoanCalculation
    {
        public static Summary Calc(Parameters parameters)
        {
            Summary summary = new Summary()
            {
                InterestRate = parameters.InterestRate,
                LoanTerm = parameters.LoanTerm,
                PropertyValue = parameters.PropertyValue,

                DownPayment = parameters.DownPayment,           
                PropertyTax = parameters.PropertyTax,
                Insurance = parameters.Insurance,
                CondoTax = parameters.CondoTax,

                StartLoan = parameters.StartLoan
            };

            double interestRatePercent = parameters.InterestRate / 100;
            summary.LoanTermMonths = parameters.LoanTerm * 12;
            summary.LoanAmount = parameters.PropertyValue - parameters.DownPayment;
            summary.LoanAmountPercent = (summary.LoanAmount * 100) / parameters.PropertyValue;
            summary.DownPaymentPercent = (parameters.DownPayment * 100) / parameters.PropertyValue;
            summary.InitialInterest = CalcInterestMonth(summary.LoanAmount, parameters.InterestRate);
            summary.MonthlyMortgage = Math.Round(summary.LoanAmount * (Math.Pow((1 + interestRatePercent / 12), summary.LoanTermMonths) * interestRatePercent) / (12 * (Math.Pow((1 + interestRatePercent / 12), summary.LoanTermMonths) - 1)), 2);
            summary.EndLoan = parameters.StartLoan.AddYears(parameters.LoanTerm);
            
            summary.TwentyPercent = 20 * parameters.PropertyValue / 100;
            summary.TotalPayment = summary.MonthlyMortgage + summary.Insurance + summary.CondoTax + (summary.PropertyTax / 12);

            int current = 1;
           
            double totalPrincipal = parameters.DownPayment;
            double loanBalance = summary.LoanAmount;

            while (current <= summary.LoanTermMonths)
            {
                Amortization amortization = new Amortization()
                {
                    Pmt = current,
                    Date = parameters.StartLoan.AddMonths(current - 1),
                    Interest = CalcInterestMonth(loanBalance, parameters.InterestRate)
                };
                amortization.Principal = summary.MonthlyMortgage - amortization.Interest;
                totalPrincipal += amortization.Principal;
                amortization.TotalPrincipal = totalPrincipal;

                summary.TotalInterest += amortization.Interest;
                loanBalance -= amortization.Principal;

                amortization.TotalInterest = Math.Round(summary.TotalInterest, 2);
                amortization.LoanBalance = Math.Round(loanBalance, 2);

                summary.Amortization.Add(amortization);
                current++;
            }
            
            return summary;
        }

        public static double CalcInterestMonth(double amount, double rate)
        {
            return Math.Round( ((amount * rate) / 100) / 12, 2);
        }
    }
}
