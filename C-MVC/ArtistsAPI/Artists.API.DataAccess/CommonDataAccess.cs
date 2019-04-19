using Album.API.DataAccess.EntityModel;
using System;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;

namespace Album.API.DataAccess
{
    public abstract class CommonDataAccess : DbContext
    {
        readonly Type providerService = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        public dbmusicEntities DBSessionFactory { get; private set; }

        public CommonDataAccess()
        {
            DBSessionFactory = new dbmusicEntities();
        }

        public override int SaveChanges()
        {
            int iRow = 0;
            // Default isolation level for TransactionScope is Serializable
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot }))
            {
                iRow = base.SaveChanges();
                scope.Complete();
            }
            return iRow;
        }

        public override Task<int> SaveChangesAsync()
        {
            int iRow = 0;
            // Default isolation level for TransactionScope is Serializable
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { IsolationLevel = IsolationLevel.Snapshot }))
            {
                iRow = base.SaveChanges();
                scope.Complete();
            }
            return Task.FromResult(iRow);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
