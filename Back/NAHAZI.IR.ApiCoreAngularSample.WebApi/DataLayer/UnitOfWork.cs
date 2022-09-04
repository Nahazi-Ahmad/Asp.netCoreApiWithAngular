using NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer.Repositories;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer
{
   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext _context;

        public UnitOfWork(ProjectDbContext context)
        {
            _context = context;
            User =  new UserManagementRepository(this._context);
        }

        public IUserManagementRepository User { get; set; }
        public int Save()=> _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
