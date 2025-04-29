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
        public bool SanctionLoan(LoanProfile profile)
        {
            // Check if any required field is null, empty, or zero
            if (string.IsNullOrWhiteSpace(profile.LoanerName)) return false;
            if (string.IsNullOrWhiteSpace(profile.LoanedID)) return false;
            if (string.IsNullOrWhiteSpace(profile.IDCardNo)) return false;
            if (profile.LoanAmount <= 0) return false;
            if (profile.AnnualIncome <= 0) return false;

            return true; 
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            LoanProfile profile = new LoanProfile
            {
                LoanerName = "John Doe",
                LoanedID = "LN12345",
                LoanAmount = 50000,
                AnnualIncome = 120000,
                IDCardNo = "ID987654"
            };

            LoanProcessor processor = new LoanProcessor();
            bool result = processor.SanctionLoan(profile);

            Console.WriteLine(result ? "Loan Sanctioned." : "Loan Rejected.");
        
    }
    }
}
