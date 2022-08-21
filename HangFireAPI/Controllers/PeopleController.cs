using Hangfire;
using HangFireAPI.Models;
using HangFireAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBackgroundJobClient _jobClient;

        public PeopleController(ApplicationDbContext context, IBackgroundJobClient backgroundJobClient)
        {
            _context = context;
            _jobClient = backgroundJobClient;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(string personName)
        {
          
            _jobClient.Enqueue<IPeaopleRepository> (repository => 
            repository.CreatePerson(personName));
            return Ok(); 
        }


        [HttpPost("schedule")]
        public async Task<ActionResult> Schedule(string personName)
        {
          var jobId =  _jobClient.Schedule(() => Console.WriteLine("The name is" +personName), 
                TimeSpan.FromMinutes(5));

            _jobClient.ContinueJobWith(jobId, () => Console.WriteLine($"The job {jobId} has finished"));
            return Ok();
        }

    
       
    }
}
