namespace OfficeAdministrationTool.InterfacesDAL
{
    public interface IBaseDAL<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity?> GetById(long id);

        Task Insert(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(long id);
    }
}