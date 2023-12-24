using OfficeAdministrationTool.Entity;
using OfficeAdministrationTool.InterfacesDAL;

namespace OfficeAdministrationTool.ImplementationsDAL
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        public async Task<string> getName()
        {
            return await Task.FromResult("Hello, World!");
        }

        public async Task<User> getUserByEmailAndActive(string email)
        {
            return await Table
                .Where(u => u.Email == email
                && u.IsActive == true
                && u.IsDeleted == false)
                .Select(u =>)
        }
    }
}