using System;
using Xunit;
using CM.WeeklyTeamReport.Domain.Repositories;
using System.Collections.Generic;


namespace CM.WeeklyTeamReport.Domain.IntegrationTests
{
    public class WeeklyReportRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateWeeklyReportRepository()
        {
            var weeklyReportRepository = new WeeklyReportRepository();

            Assert.NotNull(weeklyReportRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateWeeklyReportAndSaveItToDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var weeklyReport = new WeeklyReport(new DateTime(2021, 11, 07), new DateTime(2021, 11, 13), WeeklyStatus.Good,
                WeeklyStatus.Okay, WeeklyStatus.VeryLow, "Some weekly high text", "Some weekly low text" , "Some else text")
            { TeamMemberId = 10, MoraleComment = "some morale comment", StressComment = "some stress comment",
              WorkloadComment = "some workload comment"};
            weeklyReport = weeklyReportRepository.Create(weeklyReport);

            Assert.NotNull(weeklyReportRepository);
            Assert.True(weeklyReport.WeeklyReportId > 0);
            Assert.Equal(10, weeklyReport.TeamMemberId);
            Assert.Equal(new DateTime(2021, 11, 07), weeklyReport.DateStart);
        }

        [Fact]
        public void ShouldBeAbleToReadWeeklyReportFromDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var weeklyReport = weeklyReportRepository.Read(8);

            Assert.NotNull(weeklyReport);
            Assert.Equal(8, weeklyReport.WeeklyReportId);
            Assert.Equal(10, weeklyReport.TeamMemberId);
            Assert.Equal(new DateTime(2021, 11, 07), weeklyReport.DateStart);
            Assert.Equal(new DateTime(2021, 11, 13), weeklyReport.DateEnd);
            Assert.Equal(WeeklyStatus.Good, weeklyReport.Morale);
            Assert.Equal(WeeklyStatus.Okay, weeklyReport.Stress);
            Assert.Equal(WeeklyStatus.VeryLow, weeklyReport.Workload);
            Assert.Equal("some morale comment", weeklyReport.MoraleComment);
            Assert.Equal("some stress comment", weeklyReport.StressComment);
            Assert.Equal("some workload comment", weeklyReport.WorkloadComment);
            Assert.Equal("Some weekly high text", weeklyReport.WeeklyHighText);
            Assert.Equal("Some weekly low text", weeklyReport.WeeklyLowText);
            Assert.Equal("Some else text", weeklyReport.AnythingElseText);
        }

        [Fact]
        public void ShouldBeAbleToUpdateWeeklyReportInDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var weeklyReport = new WeeklyReport(new DateTime(2021, 10, 07), new DateTime(2021, 10, 13), WeeklyStatus.Okay,
                WeeklyStatus.Great, WeeklyStatus.Good, "Some weekly high text 2", "Some weekly low text 2", "Some else text 2")
            {
                WeeklyReportId = 10,
                TeamMemberId = 11,
                MoraleComment = "some morale comment 2",
                StressComment = "some stress comment 2",
                WorkloadComment = "some workload comment 2"
            };
            weeklyReportRepository.Update(weeklyReport);

            weeklyReport = weeklyReportRepository.Read(10);

            Assert.NotNull(weeklyReport);
            Assert.Equal(10, weeklyReport.WeeklyReportId);
            Assert.Equal(11, weeklyReport.TeamMemberId);
            Assert.Equal(new DateTime(2021, 10, 07), weeklyReport.DateStart);
            Assert.Equal(new DateTime(2021, 10, 13), weeklyReport.DateEnd);
            Assert.Equal(WeeklyStatus.Okay, weeklyReport.Morale);
            Assert.Equal(WeeklyStatus.Great, weeklyReport.Stress);
            Assert.Equal(WeeklyStatus.Good, weeklyReport.Workload);
            Assert.Equal("some morale comment 2", weeklyReport.MoraleComment);
            Assert.Equal("some stress comment 2", weeklyReport.StressComment);
            Assert.Equal("some workload comment 2", weeklyReport.WorkloadComment);
            Assert.Equal("Some weekly high text 2", weeklyReport.WeeklyHighText);
            Assert.Equal("Some weekly low text 2", weeklyReport.WeeklyLowText);
            Assert.Equal("Some else text 2", weeklyReport.AnythingElseText);
        }

        [Fact]
        public void ShouldBeAbleToDeleteWeeklyReportFromDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            weeklyReportRepository.Delete(18);

            Assert.Null(weeklyReportRepository.Read(18));
        }
    }
}
