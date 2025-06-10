namespace Assignment4
{
    public class LoanProfile
    {
        public string LoanerName { get; set; }
        public string LoanedID { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal AnnualIncome { get; set; }
        public string IDCardNo { get; set; }
    }

    public class LoanProcessor
    {
        public bool SanctionLoan(LoanProfile loanProfile)
        {
            if (!string.IsNullOrWhiteSpace(loanProfile.LoanerName) &&
                !string.IsNullOrWhiteSpace(loanProfile.LoanedID) &&
                loanProfile.LoanAmount > 0 &&
                loanProfile.AnnualIncome > 0 &&
                !string.IsNullOrWhiteSpace(loanProfile.IDCardNo))
            {
                return true;
            }
            return false;
        }
    }

}
