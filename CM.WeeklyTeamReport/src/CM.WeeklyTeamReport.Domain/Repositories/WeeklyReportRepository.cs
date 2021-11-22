using System;
using System.Data.SqlClient;

namespace CM.WeeklyTeamReport.Domain.Repositories
{
    public class WeeklyReportRepository : IRepository<WeeklyReport>
    {
        private const string CONNECTION_STRING = "Server=Home-PC;Database=WeeklyTeamReportsDB;Trusted_Connection=True;";

        private static SqlConnection GetSqlConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static WeeklyReport MapWeeklyReport(SqlDataReader reader)
        {
            return new WeeklyReport((int)reader["WeeklyReportId"], (int)reader["TeamMemberId"],
                (DateTime)reader["DateStart"], (DateTime)reader["DateEnd"],
                (WeeklyStatus)reader["Morale"], (WeeklyStatus)reader["Stress"], (WeeklyStatus)reader["Workload"],
                reader["MoraleComment"].ToString(), reader["StressComment"].ToString(), reader["WorkloadComment"].ToString(),
                reader["WeeklyHighText"].ToString(), reader["WeeklyLowText"].ToString(), reader["AnythingElseText"].ToString());
        }
        public WeeklyReport Create(WeeklyReport weeklyReport)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("INSERT INTO WeeklyReports (TeamMemberId, DateStart, DateEnd, " +
                                             "Morale, Stress, Workload, MoraleComment, StressComment, WorkloadComment, " +
                                             "WeeklyHighText, WeeklyLowText, AnythingElseText) " +
                                             "VALUES (@TeamMemberId, @DateStart, @DateEnd, @Morale, @Stress, " +
                                             "@Workload, @MoraleComment, @StressComment, @WorkloadComment, " +
                                             "@WeeklyHighText, @WeeklyLowText, @AnythingElseText);" +
                                             "SELECT * FROM WeeklyReports WHERE WeeklyReportId = SCOPE_IDENTITY()", connection);

                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReport.TeamMemberId
                };
                SqlParameter DateStart = new SqlParameter("@DateStart", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.DateStart
                };
                SqlParameter DateEnd = new SqlParameter("@DateEnd", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.DateEnd
                };
                SqlParameter Morale = new SqlParameter("@Morale", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.Morale
                };
                SqlParameter Stress = new SqlParameter("@Stress", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.Stress
                };
                SqlParameter Workload = new SqlParameter("@Workload", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.Workload
                };
                SqlParameter MoraleComment = new SqlParameter("@MoraleComment", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.MoraleComment
                };
                SqlParameter StressComment = new SqlParameter("@StressComment", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.StressComment
                };
                SqlParameter WorkloadComment = new SqlParameter("@WorkloadComment", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.WorkloadComment
                };
                SqlParameter WeeklyHighText = new SqlParameter("@WeeklyHighText", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.WeeklyHighText
                };
                SqlParameter WeeklyLowText = new SqlParameter("@WeeklyLowText", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.WeeklyLowText
                };
                SqlParameter AnythingElseText = new SqlParameter("@AnythingElseText", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.AnythingElseText
                };

                command.Parameters.AddRange(new object[] { TeamMemberId, DateStart, DateEnd, Morale, Stress, Workload,
                                                           MoraleComment, StressComment, WorkloadComment,
                                                           WeeklyHighText, WeeklyLowText, AnythingElseText });

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapWeeklyReport(reader);
                }
            }
            return null;
        }

        public WeeklyReport Read(int weeklyReportId)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("SELECT * FROM WeeklyReports " +
                                             "WHERE WeeklyReportId = @WeeklyReportId",
                                             connection);

                SqlParameter WeeklyReportId = new SqlParameter("@WeeklyReportId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReportId
                };

                command.Parameters.Add(WeeklyReportId);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapWeeklyReport(reader);
                }
            }
            return null;
        }

        public void Update(WeeklyReport weeklyReport)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("UPDATE WeeklyReports " +
                                             "SET TeamMemberId = @TeamMemberId, " +
                                             "DateStart = @DateStart, " +
                                             "DateEnd = @DateEnd, " +
                                             "Morale = @Morale, " +
                                             "Stress = @Stress, " +
                                             "Workload = @Workload, " +
                                             "MoraleComment = @MoraleComment, " +
                                             "StressComment = @StressComment, " +
                                             "WorkloadComment = @WorkloadComment, " +
                                             "WeeklyHighText = @WeeklyHighText, " +
                                             "WeeklyLowText = @WeeklyLowText, " +
                                             "AnythingElseText = @AnythingElseText " +
                                             "WHERE WeeklyReportId = @WeeklyReportId",
                                             connection);

                SqlParameter WeeklyReportId = new SqlParameter("@WeeklyReportId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReport.WeeklyReportId
                }; SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReport.TeamMemberId
                };
                SqlParameter DateStart = new SqlParameter("@DateStart", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.DateStart
                };
                SqlParameter DateEnd = new SqlParameter("@DateEnd", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.DateEnd
                };
                SqlParameter Morale = new SqlParameter("@Morale", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.Morale
                };
                SqlParameter Stress = new SqlParameter("@Stress", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.Stress
                };
                SqlParameter Workload = new SqlParameter("@Workload", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.Workload
                };
                SqlParameter MoraleComment = new SqlParameter("@MoraleComment", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.MoraleComment
                };
                SqlParameter StressComment = new SqlParameter("@StressComment", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.StressComment
                };
                SqlParameter WorkloadComment = new SqlParameter("@WorkloadComment", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.WorkloadComment
                };
                SqlParameter WeeklyHighText = new SqlParameter("@WeeklyHighText", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.WeeklyHighText
                };
                SqlParameter WeeklyLowText = new SqlParameter("@WeeklyLowText", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.WeeklyLowText
                };
                SqlParameter AnythingElseText = new SqlParameter("@AnythingElseText", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = weeklyReport.AnythingElseText
                };

                command.Parameters.AddRange(new object[] { WeeklyReportId, TeamMemberId, DateStart, DateEnd, Morale, Stress, Workload,
                                                           MoraleComment, StressComment, WorkloadComment,
                                                           WeeklyHighText, WeeklyLowText, AnythingElseText });

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int weeklyReportId)
        {
            using (var connection = GetSqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand("DELETE FROM WeeklyReports " +
                                             "WHERE WeeklyReportId = @WeeklyReportId",
                                             connection);

                SqlParameter WeeklyReportId = new SqlParameter("@WeeklyReportId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReportId
                };

                command.Parameters.Add(WeeklyReportId);

                command.ExecuteNonQuery();
            }
        }
    }
}
