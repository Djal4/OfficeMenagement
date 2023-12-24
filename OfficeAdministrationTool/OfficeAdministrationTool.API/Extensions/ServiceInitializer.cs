using Microsoft.EntityFrameworkCore;
using OfficeAdministrationTool.Helpers;
using OfficeAdministrationTool.ImplementationsBL;
using OfficeAdministrationTool.ImplementationsDAL;
using OfficeAdministrationTool.ImplementationsDAL.Context;
using OfficeAdministrationTool.InterfacesBL;
using OfficeAdministrationTool.InterfacesDAL;

namespace OfficeAdministrationTool.API.Extensions
{
    public static class ServiceInitializer
    {
        public static void InitializeServices(this IServiceCollection services) 
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            InitializeCommonServices(services);
            InitializeDAL(services);
            InitializeBL(services);
        }

        private static void InitializeCommonServices(IServiceCollection services)
        {

        }

        private static void InitializeBL(IServiceCollection services)
        {
            services.AddScoped<IUserBL, UserBL>();
        }

        private static void InitializeDAL(IServiceCollection services)
        {
            services.AddDbContext<OfficeAdministrationToolContext>(
                options => options.UseSqlServer(ConfigProvider.ConnectionString));
            services.AddSingleton<IUnitOfWorkProvider, UnitOfWorkProvider>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
