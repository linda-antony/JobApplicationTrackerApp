using Domain.Entities;

namespace Application.Interfaces
{
    public interface IJobApplicationRepository
    {
        public void AddJobApplication(JobApplication jobApplication);

        public IEnumerable<JobApplication> GetAllJobApplications();

        public JobApplication GetJobApplication(int id);

        public void UpdateJobApplication(JobApplication jobApplication);
    }
}
