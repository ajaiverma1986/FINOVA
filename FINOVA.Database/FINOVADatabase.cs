using FINOVA.Configuration;

namespace FINOVA.Database
{
    public class FINOVADatabase : BaseDatabase, IFINOVADatabase
    {
        private string _connectionString;
        public override string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    try
                    {
                        _connectionString = FINOVAApplicationConfiguration.Instance.FIADB;
                    }
                    catch
                    {
                        throw;
                    }
                }
                return _connectionString;
            }
        }
    }
}
