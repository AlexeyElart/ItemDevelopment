using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDevelopment.Repositories
{
    public class AsvelaRepository
    {
        readonly string _baseName = "asvela";
        readonly MySqlConnection _connection;

        public AsvelaRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<string> GetSuppliers()
        {
            return _connection.Query<string>($"select distinct supplier from {_baseName}.supplier_data;").Where(t => !string.IsNullOrWhiteSpace(t));
        }
    }
}
