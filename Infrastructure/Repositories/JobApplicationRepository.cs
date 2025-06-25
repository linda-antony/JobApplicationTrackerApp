using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class JobApplicationRepository: IJobApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationRepository(ApplicationDbContext context) =>
            _context = context;

        public void AddJobApplication(JobApplication jobApplication) =>
            _context.JobApplications.Add(jobApplication);

        public IEnumerable<JobApplication> GetAllJobApplications() =>
            _context.JobApplications.ToList()
                .OrderByDescending(x => x.ApplicationDate)
                .ThenBy(y => y.CompanyName);

        public JobApplication GetJobApplication(int id) =>
            _context.JobApplications.Where(app => app.Id == id).First();

        public void UpdateJobApplication(JobApplication jobApplication) =>
            _context.JobApplications.Update(jobApplication);
    }
}
