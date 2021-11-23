using System;
using Xunit;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class WeeklyTeamReportTests
    {
        [Fact]
        public void ShouldBeAbleToCreateWeeklyReport()
        {
            int weeklyReportId = 1;
            int teamMemberId = 2;
            DateTime dateStart = new DateTime(2020, 2, 16);
            DateTime dateEnd = new DateTime(2020, 2, 22);
            WeeklyStatus morale = WeeklyStatus.Great;
            WeeklyStatus stress = WeeklyStatus.Good;
            WeeklyStatus workload = WeeklyStatus.Okay;
            string moraleComment = "1";
            string stressComment = "2";
            string workloadComment = "3";
            string weeklyHighText = "Identified our goal and priorities";
            string weeklyLowText = "Cold weather";
            string anythingElseText = "Looking forward to launching our first product";
            WeeklyReport weeklyReport = new WeeklyReport(weeklyReportId, teamMemberId, dateStart, dateEnd, morale,
                stress, workload, moraleComment, stressComment, workloadComment,
                weeklyHighText, weeklyLowText, anythingElseText);

            Assert.NotNull(weeklyReport);
            Assert.Equal(1, weeklyReport.WeeklyReportId);
            Assert.Equal(2, weeklyReport.TeamMemberId);
            Assert.Equal(new DateTime(2020, 2, 16), weeklyReport.DateStart);
            Assert.Equal(new DateTime(2020, 2, 22), weeklyReport.DateEnd);
            Assert.Equal(WeeklyStatus.Great, weeklyReport.Morale);
            Assert.Equal(WeeklyStatus.Good, weeklyReport.Stress);
            Assert.Equal(WeeklyStatus.Okay, weeklyReport.Workload);
            Assert.Equal("1", weeklyReport.MoraleComment);
            Assert.Equal("2", weeklyReport.StressComment);
            Assert.Equal("3", weeklyReport.WorkloadComment);
            Assert.Equal("Identified our goal and priorities", weeklyReport.WeeklyHighText);
            Assert.Equal("Cold weather", weeklyReport.WeeklyLowText);
            Assert.Equal("Looking forward to launching our first product", weeklyReport.AnythingElseText);
        }

        [Fact]
        public void ShouldBeAbleToCreateTeamMember()
        {
            string firstName = "Ivan";
            string lastName = "Petrov";
            string title = "Engineer";
            string inviteLink = "www.example.com";
            List<WeeklyReport> reports = new List<WeeklyReport>();
            List<TeamMember> reportsTo = new List<TeamMember>();
            List<TeamMember> getReportsFrom = new List<TeamMember>();
            TeamMember teamMember = new TeamMember(2, 1, firstName, lastName, title, inviteLink);

            Assert.NotNull(teamMember);
            Assert.Equal(2, teamMember.TeamMemberId);
            Assert.Equal(1, teamMember.CompanyId);
            Assert.Equal("Ivan", teamMember.FirstName);
            Assert.Equal("Petrov", teamMember.LastName);
            Assert.Equal("Engineer", teamMember.Title);
            Assert.Equal("www.example.com", teamMember.InviteLink);
        }

        [Fact]
        public void ShouldBeAbleToCreateCompany()
        {
            int companyId = 1;
            string name = "ANKO";
            DateTime joinedDate = new DateTime(2020, 1, 2);
            Company company = new Company(companyId, name, joinedDate);

            Assert.NotNull(company);
            Assert.Equal(1, company.CompanyId);
            Assert.Equal("ANKO", company.Name);
            Assert.Equal(new DateTime(2020, 1, 2), company.JoinedDate);
        }
    }
}
