using TestTask.DataAccess.EF;
using TestTask.DataAccess.Repositories.Implementations;
using TestTask.DataAccess.UnitOfWork.Interfaces;

namespace TestTask.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private CitizenRepository? _citizenRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public CitizenRepository CitizenRepository => _citizenRepository ??= new CitizenRepository(_context);
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
