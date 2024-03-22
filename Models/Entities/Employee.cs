namespace EmployeeCrud.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }  = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public int Salary { get; set; }
    }
}
