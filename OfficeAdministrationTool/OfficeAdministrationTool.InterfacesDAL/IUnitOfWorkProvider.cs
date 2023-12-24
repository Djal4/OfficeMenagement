namespace OfficeAdministrationTool.InterfacesDAL
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Begin();
    }
}