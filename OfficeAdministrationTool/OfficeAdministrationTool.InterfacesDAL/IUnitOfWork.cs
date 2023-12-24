namespace OfficeAdministrationTool.InterfacesDAL
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        Task Commit();
        Task Rollback();

        IUserDAL UserDAL { get; }
    }
}