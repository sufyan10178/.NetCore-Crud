using EmployeeCrud.Data;
using EmployeeCrud.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext dbContext;

        public EmployeeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel) 
        
        {
            var Employee = new Employee
            {
                Name = viewModel.Name,
                DepartmentName = viewModel.DepartmentName,
                Salary = viewModel.Salary,

            };
            await dbContext.Employees.AddAsync(Employee);
            await dbContext.SaveChangesAsync();
            
  
            //return View(Employee);

            return RedirectToAction("List", "Employee");


        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var employee = await dbContext.Employees.FindAsync(Id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)

        {

            var employee = await dbContext.Employees.FindAsync(viewModel.Id);
            if (employee is not null)
            {
                employee.Name = viewModel.Name;
                employee.DepartmentName = viewModel.DepartmentName; 
                employee.Salary= viewModel.Salary;

                await dbContext.SaveChangesAsync();

            }

         return RedirectToAction("List","Employee");
            
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Employee Model)
        {
            try
            {
                var employe
               = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Model.Id);
                if (employe is not null)
                {
                    dbContext.Employees.Remove(employe);
                    await dbContext.SaveChangesAsync();
                }
         
            }catch (Exception )
            {
                throw;
            }

            return RedirectToAction("List", "Employee");
        }

    }
}
