using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public sealed class LoanProfile
    {
        public string LoanerName;
        public int LoanedID;
        public double LoanAmount;
        public double AnnualIncome;
        public int IDCardNo;

        public LoanProfile(string LoanerName, int LoanedID, double LoanAmount, double AnnualIncome, int IDCardNo)
        {
            this.LoanerName = LoanerName;
            this.LoanedID = LoanedID;
            this.LoanAmount = LoanAmount;
            this.AnnualIncome = AnnualIncome;
            this.IDCardNo = IDCardNo;
        }

    }

    public class LoanProcessor
    {
        public void LoanDetails()
        {
            LoanProfile loanProfile = new LoanProfile("John Doe", 12345, 500000, 1000000, 987654321);
            bool flag = true;

            if (string.IsNullOrEmpty(loanProfile.LoanerName) || string.IsNullOrEmpty("" + loanProfile.LoanAmount) || string.IsNullOrEmpty("" + loanProfile.LoanedID) || string.IsNullOrEmpty("" + loanProfile.IDCardNo) || string.IsNullOrEmpty("" + loanProfile.AnnualIncome))
                flag = false;

            if (flag)
                Console.WriteLine($"Loan to {loanProfile.LoanerName}  of Amount Rs {loanProfile.LoanAmount} has been sanctioned.");
            else
                Console.WriteLine("Loan Cannot be Sanctioned!!");

            loanProfile = null;

        }


    }
}
