using System;
using System.Data.SqlClient;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public class TeamMemberRepository : IRepository<TeamMember>
    {
        private const string CONNECTION_STRING = "Server=Home-PC;Database=WeeklyTeamReportsDB;Trusted_Connection=True;";

        private static SqlConnection GetSqlConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static TeamMember MapTeamMember(SqlDataReader reader)
        {
            return new TeamMember(reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["Title"].ToString(),
                reader["InviteLink"].ToString(), null, null, null)
            {
                TeamMemberId = (int)reader["TeamMemberId"],
                CompanyId = (int)reader["CompanyId"]
            };
        }

        public TeamMember Create(TeamMember teamMember)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("INSERT INTO TeamMembers (CompanyId, FirstName, LastName, Title, InviteLink) " +
                                             "VALUES (@CompanyId, @FirstName, @LastName, @Title, @InviteLink);" +
                                             "SELECT * FROM TeamMembers WHERE TeamMemberId = SCOPE_IDENTITY()",
                                             connection);

                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = teamMember.CompanyId
                };
                SqlParameter FirstName = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = teamMember.FirstName
                };
                SqlParameter LastName = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = teamMember.LastName
                };
                SqlParameter Title = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = teamMember.Title
                };
                SqlParameter InviteLink = new SqlParameter("@InviteLink", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = teamMember.InviteLink
                };
                command.Parameters.Add(CompanyId);
                command.Parameters.Add(FirstName);
                command.Parameters.Add(LastName);
                command.Parameters.Add(Title);
                command.Parameters.Add(InviteLink);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
            }
            return null;
        }

        public TeamMember Read(int teamMemberId)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("SELECT * FROM TeamMembers " +
                                             "WHERE TeamMemberId = @TeamMemberId",
                                             connection);

                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = teamMemberId
                };
                command.Parameters.Add(TeamMemberId);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
            }
            return null;
        }

        public void Update(TeamMember teamMember)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("UPDATE TeamMembers " +
                                             "SET CompanyId = @CompanyId, " +
                                             "FirstName = @FirstName, " +
                                             "LastName = @LastName, " +
                                             "Title = @Title, " +
                                             "InviteLink = @InviteLink " +
                                             "WHERE TeamMemberId = @TeamMemberId",
                                             connection);

                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = teamMember.CompanyId
                };
                SqlParameter FirstName = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = teamMember.FirstName
                };
                SqlParameter LastName = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = teamMember.LastName
                };
                SqlParameter Title = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = teamMember.Title
                };
                SqlParameter InviteLink = new SqlParameter("@InviteLink", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = teamMember.InviteLink
                };
                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = teamMember.TeamMemberId
                };
                command.Parameters.Add(CompanyId);
                command.Parameters.Add(FirstName);
                command.Parameters.Add(LastName);
                command.Parameters.Add(Title);
                command.Parameters.Add(InviteLink);
                command.Parameters.Add(TeamMemberId);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int teamMemberId)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("DELETE FROM TeamMembers " +
                                             "WHERE TeamMemberId = @TeamMemberId",
                                             connection);

                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = teamMemberId
                };
                command.Parameters.Add(TeamMemberId);

                command.ExecuteNonQuery();
            }
        }
    }
}
