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
    public class LeavesTypeController : ControllerBase
    {
        private readonly CompDBcontext _context;

        public LeavesTypeController(CompDBcontext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LeavesTypeModel>> GetLeaveTypeModel(int id)
        {
            List<LeavesTypeModel> results = await _context.LeaveType.FromSqlRaw("EXEC RetrieveLeavesType "+id).ToListAsync();

            return Ok(results);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveTypeModel(int id, LeavesTypeModel leaveTypeModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateLeavesType @id, @Type, @LeaveBalance, @created, @createdBy, @modified, @modifiedBy",
               new SqlParameter("@id", id),
               new SqlParameter("@Type", leaveTypeModel.Type),
               new SqlParameter("@LeaveBalance", leaveTypeModel.LeaveBalance),
               new SqlParameter("@created", leaveTypeModel.leaveCreated),
               new SqlParameter("@createdBy", leaveTypeModel.leaveCreatedBy),
               new SqlParameter("@modified", leaveTypeModel.leaveModified),
               new SqlParameter("@modifiedBy", leaveTypeModel.leaveModifiedBy));
            return Ok();

        }

        

        [HttpPost]
        public async Task<ActionResult<LeavesTypeModel>> PostLeaveTypeModel(LeavesTypeModel leaveTypeModel)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC AddLeavesType  @Type, @LeaveBalance, @created, @createdBy, @modified, @modifiedBy",
               new SqlParameter("@Type", leaveTypeModel.Type),
               new SqlParameter("@LeaveBalance", leaveTypeModel.LeaveBalance),
               new SqlParameter("@created", leaveTypeModel.leaveCreated),
               new SqlParameter("@createdBy", leaveTypeModel.leaveCreatedBy),
               new SqlParameter("@modified", leaveTypeModel.leaveModified),
               new SqlParameter("@modifiedBy", leaveTypeModel.leaveModifiedBy));

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

