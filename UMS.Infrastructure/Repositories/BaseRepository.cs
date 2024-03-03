namespace UMS.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using UMS.Infrastructure.Data;
    using UMS.Infrastructure.Interfaces;
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly UMSDbContext _dbContext;
        protected DbSet<T> DbSet => _dbContext.Set<T>();

        public BaseRepository(UMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T model, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(model, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return model;
        }
    }
}