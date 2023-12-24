using Microsoft.Extensions.DependencyInjection;
using OfficeAdministrationTool.InterfacesDAL;

namespace OfficeAdministrationTool.ImplementationsDAL
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWorkProvider(IServiceProvider serviceProvider) 
        {
            this._serviceProvider = serviceProvider;
        }

        public IUnitOfWork Begin()
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}