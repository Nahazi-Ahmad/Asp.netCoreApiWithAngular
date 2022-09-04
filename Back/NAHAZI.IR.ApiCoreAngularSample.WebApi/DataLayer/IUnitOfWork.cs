using NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer.Repositories;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IUserManagementRepository User { get; set; }
        int Save();
    }
}
