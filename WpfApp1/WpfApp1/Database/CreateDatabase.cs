using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace WpfApp1.Database
{
    public class CreateDatabase
    {
        Connection connection;

        public CreateDatabase(Connection _connection)
        {
            connection = _connection;
        }
        public async Task<int> Create()
        {
            int res;
            using (SqlConnection conMaster = new SqlConnection(connection.connectionStringMaster))
            {
                await conMaster.OpenAsync();
                SqlCommand commandMaster = new SqlCommand($"CREATE DATABASE db", conMaster);
                res = await commandMaster.ExecuteNonQueryAsync();
                using (SqlConnection conDb = new SqlConnection(connection.connectionString))
                {
                    await conMaster.OpenAsync();
                    SqlCommand command = new SqlCommand("CREATE TABLE Division (division_id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),"+
                                                                                "name VARCHAR (50) NOT NULL, " +
                                                                                "description VARCHAR (100));" +
                                                        "CREATE TABLE Employee (employee_id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID()," +
                                                                                "fio VARCHAR (50) NOT NULL, " +
                                                                                "FOREIGN KEY (division_id) REFERENCES Customers(division_id));"
                                                                                , conMaster);
                    res += await command.ExecuteNonQueryAsync();
                }
            }
            return res;
        }
    }
}
