using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegApp.Data;
using RegApp.Models;

namespace RegApp.Controllers

{   //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly CompDBcontext _context;

        public DepartmentsController(CompDBcontext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetDepartments ()
        {


            List<DepartmentsModel> results = await _context.Departments.FromSqlRaw("EXEC RetrieveDepartments").ToListAsync();

            return Ok(results);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartments(int id, DepartmentsModel departmentsModel)
        {


            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateDepartments @id, @departmentNameEN, @departmentNameAR, @created, @createdBy, @modified, @modifiedBy",
                new SqlParameter("@id", id),
                new SqlParameter("@departmentNameEN", departmentsModel.DepartmentNameEN),
                new SqlParameter("@departmentNameAR", departmentsModel.DepartmentNameAR),
                new SqlParameter("@created", departmentsModel.Created),
                new SqlParameter("@createdBy", departmentsModel.CreatedBy),
                new SqlParameter("@modified", departmentsModel.Modified),
                new SqlParameter("@modifiedBy", departmentsModel.ModifiedBy));

            return Ok();


        }

        [HttpPost]
        public async Task<ActionResult<DepartmentsModel>> PostDepartments(DepartmentsModel departmentsModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC AddDepartments @departmentNameEN, @departmentNameAR, @created, @createdBy, @modified, @modifiedBy",
               
                new SqlParameter("@departmentNameEN", departmentsModel.DepartmentNameEN),
                new SqlParameter("@departmentNameAR", departmentsModel.DepartmentNameAR),
                new SqlParameter("@created", departmentsModel.Created),
                new SqlParameter("@createdBy", departmentsModel.CreatedBy),
                new SqlParameter("@modified", departmentsModel.Modified),
                new SqlParameter("@modifiedBy", departmentsModel.ModifiedBy));

            return Ok();
       
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartments(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteDepartments "+id);


            return Ok();
            
        }

        
    }
}
