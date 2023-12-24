using Microsoft.EntityFrameworkCore;
using OfficeAdministrationTool.ImplementationsDAL.Context;
using OfficeAdministrationTool.InterfacesDAL;

namespace OfficeAdministrationTool.ImplementationsDAL
{
    public class BaseDAL<TEntity> : BaseDAL, IBaseDAL<TEntity> where TEntity: class
    {
        public BaseDAL() { }

        protected DbSet<TEntity> Table => Context.Set<TEntity>();

        public async Task Delete(long id)
        {
            TEntity? entityToDelete = await Table.FindAsync(id);
            if( entityToDelete != null )
                Table.Remove(entityToDelete);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<TEntity?> GetById(long id)
        {
            return await Table.FindAsync(id);
        }

        public async Task Insert(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            Table.Update(entity);
        }
    }

    public class BaseDAL
    {
        protected OfficeAdministrationToolContext Context { get; private set; }

        public void SetDbContext(OfficeAdministrationToolContext context)
        {
            Context = context;
        }
    }
}