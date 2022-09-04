using NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.DomainClasses;
using System;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer.Repositories
{
    public interface IUserManagementRepository : IGenericRepository<User>
    {

    }
    public class UserManagementRepository : GenericRepository<User>, IUserManagementRepository
    {
        public UserManagementRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
