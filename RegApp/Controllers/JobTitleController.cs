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
    public class JobTitleController : ControllerBase
    {
        private readonly CompDBcontext _context;

        public JobTitleController(CompDBcontext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobTitleModel()
        {

            List<JobTitleModel> results = await _context.JobTitle.FromSqlRaw("EXEC RetrieveJobTitles").ToListAsync();

            return Ok(results);





        }

       //ALL WORKING EXCEPT THIS CANT CONVERT VARCHAR TO Datetime
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTitleModel(int id, JobTitleModel jobTitleModel)
        {


            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateJobTitle @TitleEN, @TitleAR, @created, @createdBy, @modified, @modifiedBy, @id",
               new SqlParameter("@TitleEN", jobTitleModel.TitleEn),
               new SqlParameter("@TitleAR", jobTitleModel.TitleAR),
               new SqlParameter("@created", jobTitleModel.Created),
               new SqlParameter("@createdBy", jobTitleModel.CreatedBy),
               new SqlParameter("@modified", jobTitleModel.Modified),
               new SqlParameter("@modifiedBy", jobTitleModel.ModifiedBy),
               new SqlParameter("@id", id)
               );

            return Ok();



        }

       
        [HttpPost]
        public async Task<ActionResult<JobTitleModel>> PostJobTitleModel(JobTitleModel jobTitleModel)
        {
          

                await _context.Database.ExecuteSqlRawAsync("EXEC AddJobTitles @TitleEN, @TitleAR, @created, @createdBy, @modified, @modifiedBy",
                   new SqlParameter("@TitleEN", jobTitleModel.TitleEn),
                   new SqlParameter("@TitleAR", jobTitleModel.TitleAR),
                   new SqlParameter("@created", jobTitleModel.Created),
                   new SqlParameter("@createdBy", jobTitleModel.CreatedBy),
                   new SqlParameter("@modified", jobTitleModel.Modified),
                   new SqlParameter("@modifiedBy", jobTitleModel.ModifiedBy));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTitleModel(int id)
        {


            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteJobTitles " + id);
            return Ok();

        }


    }
}
