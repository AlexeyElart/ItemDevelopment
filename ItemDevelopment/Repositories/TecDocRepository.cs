using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDevelopment.Repositories
{
    public class TecDocRepository
    {
        readonly MySqlConnection _connection;
        readonly string _baseName;

        public TecDocRepository(MySqlConnection connection, string techDocName)
        {
            _connection = connection;
            _baseName = techDocName;
        }

        public IEnumerable<string> GetSuppliers()
        {
            return _connection.Query<string>($"select distinct supplier from {_baseName}.supplier_data;").Where(t => !string.IsNullOrWhiteSpace(t));
        }
    }
}
