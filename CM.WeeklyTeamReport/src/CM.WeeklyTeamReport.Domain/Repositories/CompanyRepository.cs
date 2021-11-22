using System;
using System.Data.SqlClient;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private const string CONNECTION_STRING = "Server=Home-PC;Database=WeeklyTeamReportsDB;Trusted_Connection=True;";

        private static SqlConnection GetSqlConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static Company MapCompany(SqlDataReader reader)
        {
            return new Company((int)reader["CompanyId"], reader["CompanyName"].ToString(),
                (DateTime)reader["JoinedDate"]);
        }

        public Company Create(Company company)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("INSERT INTO Companies (CompanyName,  JoinedDate)" +
                                             "VALUES (@CompanyName, @JoinedDate);" +
                                             "SELECT * FROM Companies WHERE CompanyId = SCOPE_IDENTITY()",
                                             connection);

                SqlParameter CompanyName = new SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = company.Name
                };
                SqlParameter JoinedDate = new SqlParameter("@JoinedDate", System.Data.SqlDbType.Date)
                {
                    Value = company.JoinedDate.ToString()
                };
                command.Parameters.Add(CompanyName);
                command.Parameters.Add(JoinedDate);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapCompany(reader);
                }
            }
            return null;
        }

        public Company Read(int companyId)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("SELECT * FROM Companies " +
                                             "WHERE CompanyId = @CompanyId",
                                             connection);

                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = companyId
                };
                command.Parameters.Add(CompanyId);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapCompany(reader);
                }
            }
            return null;
        }

        public void Update(Company company)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("UPDATE Companies " +
                                             "SET CompanyName = @CompanyName, " +
                                             "JoinedDate = @JoinedDate " +
                                             "WHERE CompanyId = @CompanyId ",
                                             connection);

                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = company.CompanyId
                };

                SqlParameter CompanyName = new SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = company.Name
                };
                SqlParameter JoinedDate = new SqlParameter("@JoinedDate", System.Data.SqlDbType.Date)
                {
                    Value = company.JoinedDate.ToString()
                };
                command.Parameters.Add(CompanyId);
                command.Parameters.Add(CompanyName);
                command.Parameters.Add(JoinedDate);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int companyId)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("DELETE FROM Companies " +
                                             "WHERE CompanyId = @CompanyId",
                                             connection);

                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = companyId
                };
                command.Parameters.Add(CompanyId);

                command.ExecuteNonQuery();
            }
        }
    }
}
