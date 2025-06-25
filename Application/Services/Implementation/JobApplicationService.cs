using Domain.Entities;
using Application.Interfaces;
using Application.Services.Interface;

namespace Application.Services.Implementation
{
    public class JobApplicationService : IJobApplicationService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobApplicationService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public Task AddJobApplicationAsync(JobApplication jobApplication)
        {
            _unitOfWork.JobApplicationRepository.AddJobApplication(jobApplication);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<JobApplication>> GetAllJobApplicationsAsync()
        {
            return Task.FromResult(_unitOfWork.JobApplicationRepository.GetAllJobApplications());
        }

        public Task<JobApplication> GetJobApplicationByIdAsync(int id)
        {
            return Task.FromResult(_unitOfWork.JobApplicationRepository.GetJobApplication(id));
        }

        public Task UpdateJobApplicationAsync(JobApplication jobApplication)
        {
            _unitOfWork.JobApplicationRepository.UpdateJobApplication(jobApplication);
            return _unitOfWork.SaveChangesAsync();
        }
    }
}
