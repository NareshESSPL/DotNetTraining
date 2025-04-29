
namespace EmployeeManagementSystem
{
    public abstract class BaseEmployee
    {

       public int EmployeeID { get; set; }

       public string? EmployeeName { get; set; }

       public int EmployeeWorkingDays { get; set; }

		

		public virtual int CalculateNoOfDays()
		{
			return EmployeeWorkingDays;
		}

		public abstract double CalculateSalary();

    }

	public class PermanentEmployee: BaseEmployee
	{

        internal double EmployeeSalary { get; set; }

		public int EmployeeWorkingDays { get; set; }

		public PermanentEmployee( double EmployeeSalary, int EmployeeWorkingDays)
		{
			this.EmployeeSalary = EmployeeSalary;
			this.EmployeeWorkingDays = EmployeeWorkingDays;
		}
        public override double CalculateSalary()
        {

			return EmployeeSalary ;
        }

        public override int CalculateNoOfDays()
        {
			return EmployeeWorkingDays;
        }

        public void GenerateReport()
        {


            Console.WriteLine($"Employee Working Days: {CalculateNoOfDays()}");
            Console.WriteLine($"Name : {base.EmployeeName}");

            Console.WriteLine($"Employee Salary: {CalculateSalary()}");
            Console.WriteLine($"Employee Working Days: {CalculateNoOfDays()}");

        }

    }

	public class ContractEmployee: BaseEmployee
	{
		internal double ContractSalary { get; set; }

		public int ContractWorkingDays { get; set; }

		public ContractEmployee(double EmployeeSalary, int EmployeeWorkingDays)
		{
			this.ContractSalary = EmployeeSalary;
			this.ContractWorkingDays = EmployeeWorkingDays;
		}

        public override int CalculateNoOfDays()
        {
			if (ContractWorkingDays < base.EmployeeWorkingDays)
			{
                ContractWorkingDays -= base.EmployeeWorkingDays;
			}
			else
			{
                ContractWorkingDays = base.EmployeeWorkingDays;
			}

			return ContractWorkingDays;
			
        }

        public override double CalculateSalary()
        {
			return ContractSalary;
        }

        public void GenerateReport()
        {

           
            Console.WriteLine($"Employee Working Days: {CalculateNoOfDays()}");
            Console.WriteLine($"Name : {base.EmployeeName}");
       
            Console.WriteLine($"Employee Salary: {CalculateSalary()}");
            Console.WriteLine($"Employee Working Days: {CalculateNoOfDays()}");

        }



    }

    public enum EmployeeType
    {
        Permanent,
        Contract,
        None
    }


    public class HumanResource
    {
        public readonly BaseEmployee BaseEmployee;
		  

		public HumanResource(string EmployeeName)
		{
			if (EmployeeName == "Permanent")
			{
				BaseEmployee = new PermanentEmployee(544, 5);

            }
			else
			{
				BaseEmployee = new ContractEmployee(654,9);
			}
		}


        public HumanResource(EmployeeType EmployeeName)
		{

			switch ((int)EmployeeName)
			{
				case 0:
					BaseEmployee = new PermanentEmployee(23,6554);
						break;
				case 1:
					 BaseEmployee = new ContractEmployee(54,8976);
					break;
				default:
					Console.WriteLine("Please enter valid category!!!");
					break;
			}

		}

        public void GenerateReport()
        {
			double ES = BaseEmployee.CalculateSalary();
			double EWD = BaseEmployee.CalculateNoOfDays();
            
			Console.WriteLine($"Employee Salary: {ES}");
			Console.WriteLine($"Employee Working Days: {EWD}");
			Console.WriteLine($"Name : {BaseEmployee.EmployeeName}");
			Console.WriteLine($"ID : {BaseEmployee.EmployeeID}");
            Console.WriteLine($"Employee Type : {BaseEmployee.GetType().Name}");
			Console.WriteLine($"Employee Salary: {BaseEmployee.CalculateSalary()}");
            Console.WriteLine($"Employee Working Days: {BaseEmployee.CalculateNoOfDays()}");



        }



    }



}
