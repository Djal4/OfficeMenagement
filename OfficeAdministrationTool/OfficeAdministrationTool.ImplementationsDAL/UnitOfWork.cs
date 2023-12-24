using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using OfficeAdministrationTool.ImplementationsDAL.Context;
using OfficeAdministrationTool.InterfacesDAL;

namespace OfficeAdministrationTool.ImplementationsDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private OfficeAdministrationToolContext _context;

        public OfficeAdministrationToolContext Context
        {
            get
            {
                return _context;
            }
        }

        private IDbContextTransaction _transaction;

        private Dictionary<Type, object> _dictionaryDALs;
        private object _lock = new object();

        public IUserDAL UserDAL => GetOrInitDAL<UserDAL>();

        
        public UnitOfWork(OfficeAdministrationToolContext context)
        {
            _context = context;
            _dictionaryDALs = new Dictionary<Type, object>();
            _transaction = _context.Database.BeginTransaction();
        }

        private TEntity GetOrInitDAL<TEntity>() where TEntity : BaseDAL, new()
        {
            lock (_lock)
            {
                Type entityType = typeof(TEntity);

                if (_dictionaryDALs.ContainsKey(entityType))
                    return (TEntity)_dictionaryDALs[entityType];

                TEntity newDAL = new TEntity();
                newDAL.SetDbContext(_context);
                _dictionaryDALs.Add(entityType, newDAL);
                return newDAL;
            }
        }

        public async Task SaveChangesAsync()
        {
            _context.ChangeTracker.DetectChanges();

            List<EntityEntry> entityEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            foreach (EntityEntry entry in entityEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Property("DateCreated") != null)
                        {
                            entry.Property("DateCreated").CurrentValue = DateTime.Now;
                        }
                        break;

                    case EntityState.Modified:
                        if (entry.Property("DateModified") != null)
                        {
                            entry.Property("DateModified").CurrentValue = DateTime.Now;
                        }
                        break;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}