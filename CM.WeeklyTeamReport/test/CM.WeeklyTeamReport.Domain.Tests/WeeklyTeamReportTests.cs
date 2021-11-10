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
            weeklyReport.MoraleComment = "Not bad";
            weeklyReport.StressComment = "Not good";
            weeklyReport.WorkloadComment = "Not good and not bad";

            Assert.NotNull(weeklyReport);
        }

        [Fact]
        public void ShouldBeAbleToCreateTeamMember()
        {
            string firstName = "Ivan";
            string lastName = "Petrov";
            string title = "Engineer";
            string inviteLing = "www.example.com";
            List<WeeklyReport> reports = new List<WeeklyReport>();
            List<TeamMember> reportsTo = new List<TeamMember>();
            List<TeamMember> getReportsFrom = new List<TeamMember>();
            TeamMember teamMember = new TeamMember(firstName, lastName, title, inviteLing, reports,
                reportsTo, getReportsFrom);

            Assert.NotNull(teamMember);
        }

        [Fact]
        public void ShouldBeAbleToCreateCompany()
        {
            string name = "ANKO";
            string joinedDate = "January 2020";
            List<TeamMember> teamMembers = new List<TeamMember>();
            Company company = new Company(name, joinedDate, teamMembers);

            Assert.NotNull(company);
        }
    }
}
