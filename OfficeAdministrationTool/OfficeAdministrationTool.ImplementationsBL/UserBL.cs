using OfficeAdministrationTool.Entity;
using OfficeAdministrationTool.Helpers;
using OfficeAdministrationTool.InterfacesBL;
using OfficeAdministrationTool.InterfacesDAL;
using OfficeAdministrationTool.Models.ViewModels;

namespace OfficeAdministrationTool.ImplementationsBL
{
    public class UserBL : IUserBL
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public UserBL(IUnitOfWorkProvider unitOfWorkProvider) 
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public async Task<string> getName()
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                return await unitOfWork.UserDAL.getName();
            }
        }

        public async Task<List<User>> getAllUsers()
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                return await unitOfWork.UserDAL.GetAll();
            }
        }

        public async Task<User> getUserById(long id)
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                return await unitOfWork.UserDAL.GetById(id);
            }
        }

        public async void insertUser(User user)
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                await unitOfWork.UserDAL.Insert(user);
            }
        }

        public async void updateUserName(User userToUpdate)
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                User? user = await unitOfWork.UserDAL.GetById(userToUpdate.Id);
                if (user != null)
                {
                    // IF USER DOESNT EXIST?
                }
                else {
                    user.FirstName = userToUpdate.FirstName;
                    user.LastName = userToUpdate.LastName;
                    await unitOfWork.UserDAL.Update(user);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        //MAIL SERVICE ADD
        public async void updateUserMail(User userToUpdate)
        {
            using (var unitOfWork = unitOfWorkProvider.Begin())
            {
                User? user = await unitOfWork.UserDAL.GetById(userToUpdate.Id);
                if (user != null)
                {
                    // IF USER DOESNT EXIST?
                }
                else
                {
                    user.Email = userToUpdate.Email;
                    await unitOfWork.UserDAL.Update(user);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        //TO FIX!
        public async void updateUserPassword(User userToUpdate)
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                User? user = await unitOfWork.UserDAL.GetById(userToUpdate.Id);

                if(user != null)
                {

                }
                else
                {
                    user.Password = userToUpdate.Password;
                    await unitOfWork.UserDAL.Update(user);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        //TO FIX!
        public async void updateUserRole(User userToUpdate)
        {
            using (var unitOfWork = unitOfWorkProvider.Begin())
            {
                User? user = await unitOfWork.UserDAL.GetById(userToUpdate.Id);

                if (user != null)
                {

                }
                else
                {
                    user.Role = userToUpdate.Role;
                    await unitOfWork.UserDAL.Update(user);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        public async void deleteUser(User userToDelete)
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                User? user = await unitOfWork.UserDAL.GetById(userToDelete.Id);
                
                if(user != null)
                {

                }
                else
                {
                    user.IsDeleted = true;
                    await unitOfWork.UserDAL.Update(user);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        public async Task<ActionResponse<User>>login(string email, string password)
        {
            using(var unitOfWork = unitOfWorkProvider.Begin())
            {
                User? user = await unitOfWork.UserDAL.getUserByEmailAndActive(email);
                if(user != null)
                {
                    if(PasswordHelper.verifyPassword(password, user.Password))
                    {

                    }
                }
            }
        }
    }
}