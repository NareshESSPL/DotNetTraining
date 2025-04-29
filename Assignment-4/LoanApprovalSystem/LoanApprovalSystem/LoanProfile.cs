namespace LoanApprovalSystem
 {
        public class LoanProfile
        {
            public string LoanerName { get; set; }
            public string LoanedID { get; set; }
            public double LoanAmount { get; set; }
            public double AnnualIncome { get; set; }
            public string IDCardNo { get; set; }
        }

        public class LoanProcessor
        {
            public bool SanctionLoan(LoanProfile profile)
            {
                if (string.IsNullOrWhiteSpace(profile.LoanerName)) return false;
                if (string.IsNullOrWhiteSpace(profile.LoanedID)) return false;
                if (profile.LoanAmount <= 0) return false;
                if (profile.AnnualIncome <= 0) return false;
                if (string.IsNullOrWhiteSpace(profile.IDCardNo)) return false;
                return true;
            }
        }
    }
