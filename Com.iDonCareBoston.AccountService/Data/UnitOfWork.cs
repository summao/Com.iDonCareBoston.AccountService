using System.Data;

namespace Com.iDonCareBoston.AccountService.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed = false;

        public UnitOfWork(IDbConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public void Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _connection?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
