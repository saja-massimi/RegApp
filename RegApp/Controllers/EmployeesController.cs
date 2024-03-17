using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegApp.Data;
using RegApp.Models;

namespace RegApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompDBcontext _context;

        public EmployeesController(CompDBcontext context)
        {
            _context = context;
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesAsync(int id)
        {

         
            var res = await _context.Employees
         .FromSqlRaw("EXEC RetrieveEmployee {0}", id) 
         .ToListAsync();


            foreach (var employee in res)
            {
                _context.Entry(employee).Reference(e => e.Department).Load();
            }

            return Ok(res);



        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployees(int id, EmployeesModel employeesModel)
        {

            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateEmployee @id, @EmpNameEN, @EmpNameAR, @ManagerID, @isManager, @Salary, @HireDate,@JobTitle,@DepartmentID,@LeaveBalance,@Created,@CreatedBy,@Modified,@ModifiedBy",
                new SqlParameter("@id", id),
                new SqlParameter("@EmpNameEN", employeesModel.EmpNameEN),
                new SqlParameter("@EmpNameAR", employeesModel.EmpNameAR),
                new SqlParameter("@ManagerID", employeesModel.ManagerID),
                new SqlParameter("@isManager", employeesModel.isManger),
                new SqlParameter("@Salary", employeesModel.Salary),
                new SqlParameter("@HireDate", employeesModel.HireDate),
                new SqlParameter("@JobTitle", employeesModel.JobTitle),
                new SqlParameter("@DepartmentID", employeesModel.DepartmentID),
                new SqlParameter("@LeaveBalance", employeesModel.LeaveBalance),
                new SqlParameter("@Created", employeesModel.empCreated),
                new SqlParameter("@CreatedBy", employeesModel.empCreatedBy),
                new SqlParameter("@Modified", employeesModel.empModified),
                new SqlParameter("@ModifiedBy", employeesModel.empModifiedBy));

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployees(EmployeesModel employeesModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC AddEmployee @EmpNameEN, @EmpNameAR, @ManagerID, @isManager, @Salary, @HireDate,@JobTitle,@DepartmentID,@LeaveBalance,@Created,@CreatedBy,@Modified,@ModifiedBy",

              new SqlParameter("@EmpNameEN", employeesModel.EmpNameEN),
                new SqlParameter("@EmpNameAR", employeesModel.EmpNameAR),
                new SqlParameter("@ManagerID", employeesModel.ManagerID),
                new SqlParameter("@isManager", employeesModel.isManger),
                new SqlParameter("@Salary", employeesModel.Salary),
                new SqlParameter("@HireDate", employeesModel.HireDate),
                new SqlParameter("@JobTitle", employeesModel.JobTitle),
                new SqlParameter("@DepartmentID", employeesModel.DepartmentID),
                new SqlParameter("@LeaveBalance", employeesModel.LeaveBalance),
                new SqlParameter("@Created", employeesModel.empCreated),
                new SqlParameter("@CreatedBy", employeesModel.empCreatedBy),
                new SqlParameter("@Modified", employeesModel.empModified),
                new SqlParameter("@ModifiedBy", employeesModel.empModifiedBy));

            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC deleteEmployee " + id);

            return Ok();

        }


    }
}
