using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.BufferWidth = 500;
            System.Console.BufferHeight = 1600;
            System.Console.WindowWidth = System.Console.LargestWindowWidth;
            System.Console.WindowHeight = System.Console.LargestWindowHeight;             

            var summary = LoanCalculation.Calc(new Parameters()
            {
                PropertyValue = 150000,
                DownPayment = 30000,
                InterestRate = 3.0,
                LoanTerm = 15,

                PropertyTaxPercent = 0,
                PMIPercent = 0,
                StartLoan = new DateTime(2015, 2, 1)
            });

            Console.WriteLine();
            Console.WriteLine("PropertyValue: " + summary.PropertyValue.ToString("C0"));
            Console.WriteLine("DownPayment: " + summary.DownPayment.ToString("C0"));
            Console.WriteLine("DownPaymentPercent: " + summary.DownPaymentPercent + " %");
            Console.WriteLine("TwentyPercent: " + summary.TwentyPercent.ToString("C0"));
            Console.WriteLine();
            Console.WriteLine("InterestRate: " + summary.InterestRate + " %");
            Console.WriteLine();
            Console.WriteLine("LoanTerm: " + summary.LoanTerm + " years");
            Console.WriteLine("LoanTermMonths: " + summary.LoanTermMonths + " months");
            Console.WriteLine();
            Console.WriteLine("LoanAmount: " + summary.LoanAmount.ToString("C0"));
            Console.WriteLine("LoanAmountPercent: " + summary.LoanAmountPercent + " %");
            Console.WriteLine();
            Console.WriteLine("InitialInterest: " + summary.InitialInterest.ToString("C0"));
            Console.WriteLine("MonthlyMortgage: " + summary.MonthlyMortgage.ToString("C0"));
            Console.WriteLine();
            Console.WriteLine("StartLoan: " + summary.StartLoan.ToString("MMMM d, yyyy"));
            Console.WriteLine("EndLoan: " + summary.EndLoan.ToString("MMMM d, yyyy"));

            Console.WriteLine();
            Console.WriteLine("Amortization Table?");
            Console.ReadKey();

            int currentYear = 0;
            int countYear = 0;            
            Console.WriteLine();
            foreach(var amortization in summary.Amortization)
            {
                if(currentYear != amortization.Date.Year)
                {
                    countYear++;
                    currentYear = amortization.Date.Year;
                    Console.WriteLine(countYear + " ############### " + currentYear + " ###############");
                    Console.WriteLine();
                }

                Console.WriteLine(amortization.Pmt + " - " + amortization.Date.ToString("MMMM d, yyyy"));
                Console.WriteLine("     LoanBalance: " + amortization.LoanBalance.ToString("C0"));
                Console.WriteLine("     Interest: " + amortization.Interest.ToString("C0"));
                Console.WriteLine("     Principal: " + amortization.Principal.ToString("C0"));
                Console.WriteLine("     TotalInterest: " + amortization.TotalInterest.ToString("C0"));
                Console.WriteLine("     TotalPrincipal: " + amortization.TotalPrincipal.ToString("C0"));                
                Console.WriteLine();
            }

            Console.ReadLine();
        }    
    }  
}
