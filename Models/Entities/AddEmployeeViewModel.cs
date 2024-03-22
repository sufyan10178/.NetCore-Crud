namespace EmployeeCrud.Models.Entities
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public int Salary
        {
            get; set;
        }
    }
}
