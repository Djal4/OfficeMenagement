using OfficeAdministrationTool.Entity;

namespace OfficeAdministrationTool.InterfacesBL
{
    public interface IUserBL
    {
        Task<string> getName();
        Task<List<User>> getAllUsers();
        Task<User> getUserById(long id);
        void insertUser(User user);
        void updateUserName(User userToUpdate);
        void updateUserMail(User userToUpdate);
        void updateUserPassword(User userToUpdate);
        void updateUserRole(User userToUpdate);
        void deleteUser(User userToDelete);
    }
}