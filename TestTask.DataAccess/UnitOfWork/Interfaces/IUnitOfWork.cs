using TestTask.DataAccess.Repositories.Implementations;

namespace TestTask.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        public CitizenRepository CitizenRepository { get; }

        Task Save();
    }
}
