namespace ConciergeBackend.Data
{
    public abstract class BaseDatabase
    {
        protected readonly string _localConn;
        protected readonly string _remoteConn;

        public BaseDatabase(IConfiguration configuration)
        {
            _localConn = configuration.GetConnectionString("localConnString"); 
            _remoteConn = configuration.GetConnectionString("remoteConnString"); 
        }
    }
}
