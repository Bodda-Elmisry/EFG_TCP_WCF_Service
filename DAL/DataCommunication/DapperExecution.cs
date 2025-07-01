using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL.DataCommunication
{
    public class DapperExecution
    {
        private readonly string connectionString;

        public DapperExecution(string connectionString)
        {
            this.connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=OrderInstructionDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        }

        public int Execute(string sql, object parameters)
        {
            var rowsAffected = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                rowsAffected = connection.Execute(sql, parameters);
            }

            return rowsAffected;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);
                result = rows.ToList();
            }

            return result;
        }



        public IEnumerable<T> Query<T>(string sql, object parameters)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                var rows = connection.Query<T>(sql, parameters);
                result = rows.ToList();
            }

            return result;
        }





    }
}
