using System.ComponentModel.DataAnnotations;
namespace TestApp1.DTO
{
    public class EmployeeView
    {
        public EmployeeView EmployeeSingle;
        public List<EmployeeView> EmployeeList;
        public EmployeeView()
        {
            EmployeeList = new List<EmployeeView>();
        }
    }
}
