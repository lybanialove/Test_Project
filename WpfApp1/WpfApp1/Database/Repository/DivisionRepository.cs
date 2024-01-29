using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Database.Abstractions;
using WpfApp1.Database.Entity;

namespace WpfApp1.Database.Repository
{
    public class DivisionRepository : IRepository<Division>
    {
        Connection connection;
        List<Division> divisions;
        public DivisionRepository()
        {
            connection = new Connection();
            divisions = new List<Division>();
        }

        public async Task<int> Create(Division item)
        {
            int res;
            using (SqlConnection con = new SqlConnection(connection.connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand($"INSERT INTO Division (id, name, description) VALUES ({item.id},'{item.name}','{item.description}');INSERT INTO Orders (OrderID, CustomerID, OrderDate)VALUES (1, 1, '2022-01-01');", con);
                res = await command.ExecuteNonQueryAsync();
            }
            return res;
        }

        public async Task<Division> FindById(Guid id)
        {
            using (SqlConnection con = new SqlConnection(connection.connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand($"sql script", con);
                int res = await command.ExecuteNonQueryAsync();
            }
            return new Division();
        }

        public async Task<IEnumerable<Division>> Get()
        {
            using (SqlConnection con = new SqlConnection(connection.connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand($"sql script", con);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows) 
                {
                    while (await reader.ReadAsync()) 
                    {
                        Division division = new Division();
                        division.id = Guid.Parse(reader.GetValue(0).ToString());
                        division.name = reader.GetValue(1).ToString();
                        division.description = reader.GetValue(2).ToString();

                        divisions.Add(division);
                    }
                    await reader.CloseAsync();
                    return divisions;
                }
            }
            return null;
        }

        public async Task<int> Remove(Division item)
        {
            int res;
            using (SqlConnection con = new SqlConnection(connection.connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand($"sql script", con);
                res = await command.ExecuteNonQueryAsync();
            }
            return res;
        }

        public async Task<int> Update(Division item)
        {
            int res;
            using (SqlConnection con = new SqlConnection(connection.connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand($"sql script", con);
                 res = await command.ExecuteNonQueryAsync();
            }
            return res;
        }
    }
}
