using LoanApprovalSystem;

namespace TestMain
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            var profile = new LoanProfile
            {
                LoanerName = "Jayadev",
                LoanedID = "L12345",
                LoanAmount = 500000,
                AnnualIncome = 800000,
                IDCardNo = "ID998877"
            };

            var processor = new LoanProcessor();
            bool isApproved = processor.SanctionLoan(profile);

            Console.WriteLine(isApproved ?  "Loan Sanctioned!" : "Loan Rejected.");
        }
    }
    }
