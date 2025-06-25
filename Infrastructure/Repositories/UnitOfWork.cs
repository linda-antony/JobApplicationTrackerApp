using Application.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IJobApplicationRepository JobApplicationRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            JobApplicationRepository = new JobApplicationRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
