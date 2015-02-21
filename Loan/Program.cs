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

            //
            //var parameter = new Parameters()
            //{
            //    PropertyValue = 130000,
            //    DownPayment = 32500,
            //    InterestRate = 4,
            //    LoanTerm = 7,

            //    PropertyTax = 1776,
            //    CondoTax = 296,
            //    Insurance = 100,
            //    StartLoan = new DateTime(2015, 2, 1)
            //};

            //SunTrust
            //var parameter = new Parameters()
            //{
            //    PropertyValue = 150000,
            //    DownPayment = 26000,
            //    InterestRate = 2.8,
            //    LoanTerm = 15,

            //    PropertyTax = 1776,
            //    CondoTax = 170,
            //    Insurance = 80,
            //    StartLoan = new DateTime(2015, 2, 1)
            //};

            //Jeff
            var parameter = new Parameters()
            {
                PropertyValue = 150000,
                DownPayment = 45000,
                InterestRate = 4.25,
                LoanTerm = 15,

                PropertyTax = 1750,
                CondoTax = 300,
                Insurance = 70,
                StartLoan = DateTime.Now
            };

            var summary = LoanCalculation.Calc(parameter);

            var summaryFormated = new
            {
                PropertyValue = summary.PropertyValue.ToString("C0"),
                DownPayment = summary.DownPayment.ToString("C0"),
                DownPaymentPercent = summary.DownPaymentPercent + " % ",
                TwentyPercent = summary.TwentyPercent.ToString("C0"),
                InterestRate = summary.InterestRate + " % ",
                PropertyTax = summary.PropertyTax.ToString("C0"),
                CondoTax = summary.CondoTax.ToString("C0"),
                Insurance = summary.Insurance.ToString("C0"),            
                LoanTerm = summary.LoanTerm + " years",
                LoanTermMonths = summary.LoanTermMonths + " months",
                LoanAmount = summary.LoanAmount.ToString("C0"),
                LoanAmountPercent = summary.LoanAmountPercent + " %",
                InitialInterest = summary.InitialInterest.ToString("C0"),
                MonthlyMortgage = summary.MonthlyMortgage.ToString("C0"),
                TotalInterest = summary.TotalInterest.ToString("C0"),
                TotalPayment = summary.TotalPayment.ToString("C0"),
                StartLoan = summary.StartLoan.ToString("MMMM d, yyyy"),
                EndLoan = summary.EndLoan.ToString("MMMM d, yyyy"),

                Amortization = summary.Amortization
            };

            Console.WriteLine();
            Console.WriteLine("PropertyValue: " + summaryFormated.PropertyValue);
            Console.WriteLine("DownPayment: " + summaryFormated.DownPayment);
            Console.WriteLine("DownPaymentPercent: " + summaryFormated.DownPaymentPercent);
            Console.WriteLine("TwentyPercent: " + summaryFormated.TwentyPercent);
            Console.WriteLine();
            Console.WriteLine("InterestRate: " + summaryFormated.InterestRate);
            Console.WriteLine();
            Console.WriteLine("PropertyTax: " + summaryFormated.PropertyTax);            
            Console.WriteLine("CondoTax: " + summaryFormated.CondoTax);
            Console.WriteLine("Insurance: " + summaryFormated.Insurance);
            Console.WriteLine();
            Console.WriteLine("LoanTerm: " + summaryFormated.LoanTerm);
            Console.WriteLine("LoanTermMonths: " + summaryFormated.LoanTermMonths);
            Console.WriteLine();
            Console.WriteLine("LoanAmount: " + summaryFormated.LoanAmount);
            Console.WriteLine("LoanAmountPercent: " + summaryFormated.LoanAmountPercent);
            Console.WriteLine();
            Console.WriteLine("InitialInterest: " + summaryFormated.InitialInterest);
            Console.WriteLine("MonthlyMortgage: " + summaryFormated.MonthlyMortgage);
            Console.WriteLine("TotalInterest: " + summaryFormated.TotalInterest);
            Console.WriteLine("TotalPayment: " + summaryFormated.TotalPayment);
            Console.WriteLine();
            Console.WriteLine("StartLoan: " + summaryFormated.StartLoan);
            Console.WriteLine("EndLoan: " + summaryFormated.EndLoan);

            Console.WriteLine();
            Console.WriteLine("Generate file (y/n)?");
            if (Console.ReadLine() == "y")
            {
                System.IO.File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "summary.txt", Newtonsoft.Json.JsonConvert.SerializeObject(summaryFormated, Newtonsoft.Json.Formatting.Indented));
                System.IO.File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "parameters.txt", Newtonsoft.Json.JsonConvert.SerializeObject(parameter, Newtonsoft.Json.Formatting.Indented));
            }

            Console.WriteLine();
            Console.WriteLine("Amortization Table (y/n)?");
            if (Console.ReadLine() == "y")
            {

                int currentYear = 0;
                int countYear = 0;
                Console.WriteLine();
                foreach (var amortization in summary.Amortization)
                {
                    if (currentYear != amortization.Date.Year)
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
}
