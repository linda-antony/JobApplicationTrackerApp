using Domain.Entities;

namespace Application.Services.Interface
{
    public interface IJobApplicationService
    {
        public Task AddJobApplicationAsync(JobApplication jobApplication);

        public Task<IEnumerable<JobApplication>> GetAllJobApplicationsAsync();

        public Task<JobApplication> GetJobApplicationByIdAsync(int id);

        public Task UpdateJobApplicationAsync(JobApplication jobApplication);
    }
}
