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
    public class LeaveTypeController : ControllerBase
    {
        private readonly CompDBcontext _context;

        public LeaveTypeController(CompDBcontext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeModel>> GetLeaveTypeModel(int id)
        {
            List<LeaveTypeModel> results = await _context.LeaveType.FromSqlRaw("EXEC RetrieveLeavesType "+id).ToListAsync();

            return Ok(results);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveTypeModel(int id, LeaveTypeModel leaveTypeModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateLeavesType @id, @Type, @LeaveBalance, @created, @createdBy, @modified, @modifiedBy",
               new SqlParameter("@id", id),
               new SqlParameter("@Type", leaveTypeModel.Type),
               new SqlParameter("@LeaveBalance", leaveTypeModel.LeaveBalance),
               new SqlParameter("@created", leaveTypeModel.Created),
               new SqlParameter("@createdBy", leaveTypeModel.CreatedBy),
               new SqlParameter("@modified", leaveTypeModel.Modified),
               new SqlParameter("@modifiedBy", leaveTypeModel.ModifiedBy));
            return Ok();

        }

        

        [HttpPost]
        public async Task<ActionResult<LeaveTypeModel>> PostLeaveTypeModel(LeaveTypeModel leaveTypeModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC AddLeavesType  @Type, @LeaveBalance, @created, @createdBy, @modified, @modifiedBy",
               new SqlParameter("@Type", leaveTypeModel.Type),
               new SqlParameter("@LeaveBalance", leaveTypeModel.LeaveBalance),
               new SqlParameter("@created", leaveTypeModel.Created),
               new SqlParameter("@createdBy", leaveTypeModel.CreatedBy),
               new SqlParameter("@modified", leaveTypeModel.Modified),
               new SqlParameter("@modifiedBy", leaveTypeModel.ModifiedBy));

            return Ok();

        }


    

    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveTypeModel(int id)
        {

        await _context.Database.ExecuteSqlRawAsync("EXEC DeleteLeavesType " + id);


        return Ok();

    }

}
}

