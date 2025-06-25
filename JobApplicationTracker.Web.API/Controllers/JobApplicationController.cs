using Microsoft.AspNetCore.Mvc;
using Application.Services.Interface;
using Domain.Entities;
using Application.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("applications")]
    public class JobApplicationController : ControllerBase
    {
        private readonly ILogger<JobApplicationController> _logger;
        private IJobApplicationService _jobApplicationService;

        public JobApplicationController(
            ILogger<JobApplicationController> logger,
            IJobApplicationService service)
        {
            _logger = logger;
            _jobApplicationService = service;
        }

        /// <summary>
        /// Get details of a job application by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplicationDto>> GetJobApplication(int id)
        {
            var result = await _jobApplicationService.GetJobApplicationByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            var job = new JobApplicationDto
            {
                Id = result.Id,
                CompanyName = result.CompanyName,
                Position = result.Position,
                Status = result.Status,
                ApplicationDate = result.ApplicationDate
            };

            return Ok(job);
        }

        /// <summary>
        /// Get details of all applied jobs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplicationDto>>> GetAllJobApplications()
        {
            var result = await _jobApplicationService.GetAllJobApplicationsAsync();

            var modelList = new List<JobApplicationDto>();
            foreach (var item in result)
            {
                modelList.Add(new JobApplicationDto
                {
                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    Position = item.Position,
                    Status = item.Status,
                    ApplicationDate = item.ApplicationDate
                });
            }

            return Ok(modelList);
        }

        /// <summary>
        /// Add a new job application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromBody] JobApplicationDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Enum.TryParse<ApplicationStatus>(model.Status, true, out var parsedStatus))
            {
                return BadRequest("Status must be either 'Applied' or 'Interview' or 'Offer' or 'Rejected'.");
            }

            var normalizedStatus = parsedStatus.ToString();

            var job = new JobApplication 
            (
                model.CompanyName,
                model.Position,
                normalizedStatus,
                model.ApplicationDate
            );

            await _jobApplicationService.AddJobApplicationAsync(job);

            model.Id = job.Id;
            return CreatedAtAction(nameof(GetJobApplication), new { id = job.Id }, model);
        }

        /// <summary>
        /// Update details of a job application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateApplication([FromBody] JobApplicationDto model)
        {
            if (model == null)
            {
                return BadRequest("Job application cannot be null.");
            }

            if (!Enum.TryParse<ApplicationStatus>(model.Status, true, out var parsedStatus))
            {
                return BadRequest("Status must be either 'Applied' or 'Interview' or 'Offer' or 'Rejected'.");
            }

            var normalizedStatus = parsedStatus.ToString();

            var job = new JobApplication
            (
                model.Id,
                model.CompanyName,
                model.Position,
                normalizedStatus,
                model.ApplicationDate
            );

            await _jobApplicationService.UpdateJobApplicationAsync(job);
            return CreatedAtAction(nameof(GetJobApplication), new { id = job.Id }, model);
        }

    }
}
