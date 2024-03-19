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
    public class EmployeesLeaveController : ControllerBase
    {
        private readonly CompDBcontext _context;

        public EmployeesLeaveController(CompDBcontext context)
        {
            _context = context;
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesLeave(int id)
        {

          
            
                   

            var res = await _context.EmployeesLeave
        .FromSqlInterpolated($"EXEC RetrieveEmpolyeesLeaves {id}")
        .ToListAsync();

            foreach (var type in res)
            {
                _context.Entry(type).Reference(e => e.LeavesType).Load();
            }





            return Ok(res);



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesLeaveModel(int id, EmployeesLeaveModel employeesLeaveModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC updateEmpolyeesLeaves @id, @StartDate ,@EndDate, @LeaveTypeID,@NumberOfDays,@Notes, @created, @createdBy, @modified, @modifiedBy",
                new SqlParameter("@id", id),
                new SqlParameter("@StartDate", employeesLeaveModel.StartDate),
                new SqlParameter("@EndDate", employeesLeaveModel.EndDate),
                new SqlParameter("@LeaveTypeID", employeesLeaveModel.LeaveTypeID),
                new SqlParameter("@NumberOfDays", employeesLeaveModel.NumberOfDays),
                new SqlParameter("@Notes", employeesLeaveModel.Notes),
                new SqlParameter("@created", employeesLeaveModel.Created),
                new SqlParameter("@createdBy", employeesLeaveModel.CreatedBy),
                new SqlParameter("@modified", employeesLeaveModel.Modified),
                new SqlParameter("@modifiedBy", employeesLeaveModel.MdifiedBy)) ;

            return Ok();


        }

       
        [HttpPost]
        public async Task<ActionResult<EmployeesLeaveModel>> PostEmployeesLeaveModel(EmployeesLeaveModel employeesLeaveModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC AddEmpolyeesLeaves  @StartDate ,@EndDate, @LeaveTypeID,@NumberOfDays,@Notes, @created, @createdBy, @modified, @modifiedBy",
                  new SqlParameter("@StartDate", employeesLeaveModel.StartDate),
                  new SqlParameter("@EndDate", employeesLeaveModel.EndDate),
                  new SqlParameter("@LeaveTypeID", employeesLeaveModel.LeaveTypeID),
                  new SqlParameter("@NumberOfDays", employeesLeaveModel.NumberOfDays),
                  new SqlParameter("@Notes", employeesLeaveModel.Notes),
                  new SqlParameter("@created", employeesLeaveModel.Created),
                  new SqlParameter("@createdBy", employeesLeaveModel.CreatedBy),
                  new SqlParameter("@modified", employeesLeaveModel.Modified),
                  new SqlParameter("@modifiedBy", employeesLeaveModel.MdifiedBy));

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesLeaveModel(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmpolyeesLeaves " + id);


            return Ok();
        }

       
    }
}
