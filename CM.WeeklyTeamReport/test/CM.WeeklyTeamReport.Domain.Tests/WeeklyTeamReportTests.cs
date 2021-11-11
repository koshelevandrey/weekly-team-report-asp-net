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
            DateTime dateStart = new DateTime(2020, 2, 16);
            DateTime dateEnd = new DateTime(2020, 2, 22);
            WeeklyStatus morale = WeeklyStatus.Great;
            WeeklyStatus stress = WeeklyStatus.Good;
            WeeklyStatus workload = WeeklyStatus.Okay;
            string weeklyHighText = "Identified our goal and priorities";
            string weeklyLowText = "Cold weather";
            string anythingElseText = "Looking forward to launching our first product";
            WeeklyReport weeklyReport = new WeeklyReport(dateStart, dateEnd, morale,
                stress, workload, weeklyHighText, weeklyLowText, anythingElseText);
            weeklyReport.MoraleComment = "1";
            weeklyReport.StressComment = "2";
            weeklyReport.WorkloadComment = "3";

            Assert.NotNull(weeklyReport);

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
            TeamMember teamMember = new TeamMember(firstName, lastName, title, inviteLink, reports,
                reportsTo, getReportsFrom);

            Assert.NotNull(teamMember);

            Assert.Equal("Ivan", teamMember.FirstName);
            Assert.Equal("Petrov", teamMember.LastName);
            Assert.Equal("Engineer", teamMember.Title);
            Assert.Equal("www.example.com", teamMember.InviteLink);
            Assert.Equal(reports, teamMember.Reports);
            Assert.Equal(reportsTo, teamMember.ReportsTo);
            Assert.Equal(getReportsFrom, teamMember.GetReportsFrom);
        }

        [Fact]
        public void ShouldBeAbleToCreateCompany()
        {
            string name = "ANKO";
            DateTime joinedDate = new DateTime(2020, 1, 2);
            List<TeamMember> teamMembers = new List<TeamMember>();
            Company company = new Company(name, joinedDate, teamMembers);

            Assert.NotNull(company);

            Assert.Equal("ANKO", company.Name);
            Assert.Equal(new DateTime(2020, 1, 2), company.JoinedDate);
            Assert.Equal(teamMembers, company.TeamMembers);
        }
    }
}
