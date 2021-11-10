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
            string dateStart = "February 16";
            string dateEnd = "February 22";
            string year = "2020";
            WeeklyStatus morale = WeeklyStatus.Great;
            WeeklyStatus stress = WeeklyStatus.Good;
            WeeklyStatus workload = WeeklyStatus.Okay;
            string weeklyHighText = "Identified our goal and priorities";
            string weeklyLowText = "Cold weather";
            string anythingElseText = "Looking forward to launching our first product";
            WeeklyReport weeklyReport = new WeeklyReport(dateStart, dateEnd, year, morale,
                stress, workload, weeklyHighText, weeklyLowText, anythingElseText);
            weeklyReport.MoraleComment = "1";
            weeklyReport.StressComment = "2";
            weeklyReport.WorkloadComment = "3";

            Assert.NotNull(weeklyReport);

            Assert.True(weeklyReport.DateStart == "February 16");
            Assert.True(weeklyReport.DateEnd == "February 22");
            Assert.True(weeklyReport.Year == "2020");
            Assert.True(weeklyReport.Morale == WeeklyStatus.Great);
            Assert.True(weeklyReport.Stress == WeeklyStatus.Good);
            Assert.True(weeklyReport.Workload == WeeklyStatus.Okay);
            Assert.True(weeklyReport.MoraleComment == "1");
            Assert.True(weeklyReport.StressComment == "2");
            Assert.True(weeklyReport.WorkloadComment == "3");
            Assert.True(weeklyReport.WeeklyHighText == "Identified our goal and priorities");
            Assert.True(weeklyReport.WeeklyLowText == "Cold weather");
            Assert.True(weeklyReport.AnythingElseText == "Looking forward to launching our first product");
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

            Assert.True(teamMember.FirstName == "Ivan");
            Assert.True(teamMember.LastName == "Petrov");
            Assert.True(teamMember.Title == "Engineer");
            Assert.True(teamMember.InviteLink == "www.example.com");
            Assert.True(teamMember.Reports == reports);
            Assert.True(teamMember.ReportsTo == reportsTo);
            Assert.True(teamMember.GetReportsFrom == getReportsFrom);
        }

        [Fact]
        public void ShouldBeAbleToCreateCompany()
        {
            string name = "ANKO";
            string joinedDate = "January 2020";
            List<TeamMember> teamMembers = new List<TeamMember>();
            Company company = new Company(name, joinedDate, teamMembers);

            Assert.NotNull(company);

            Assert.True(company.Name == "ANKO");
            Assert.True(company.JoinedDate == "January 2020");
            Assert.True(company.TeamMembers == teamMembers);
        }
    }
}
