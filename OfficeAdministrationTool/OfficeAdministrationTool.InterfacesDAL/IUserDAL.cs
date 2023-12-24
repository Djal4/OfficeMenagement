using OfficeAdministrationTool.Entity;

namespace OfficeAdministrationTool.InterfacesDAL
{
    public interface IUserDAL : IBaseDAL<User>
    {
        Task<string> getName();
    }
}