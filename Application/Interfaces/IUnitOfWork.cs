
namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IJobApplicationRepository JobApplicationRepository { get; }

        /// <summary>
        /// Saves all changes made in the unit of work to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Disposes of the unit of work, releasing any resources it holds.
        /// </summary>
        void Dispose();
    }
}
