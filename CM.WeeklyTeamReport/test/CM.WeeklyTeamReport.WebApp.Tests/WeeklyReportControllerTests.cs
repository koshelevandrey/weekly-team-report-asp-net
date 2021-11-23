using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.Domain.Repositories;
using CM.WeeklyTeamReport.WebApp.Controllers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.WebApp.Tests
{
    public class WeeklyReportControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateWeeklyReportController()
        {
            var fixture = new WeeklyReportControllerFixture();
            var controller = fixture.GetWeeklyReportController();
        }

        [Fact]
        public void ShouldReturnAllWeeklyReportsByTeamMember()
        {
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository.Setup(x => x.ReadAllByParentId(1))
                .Returns(new List<WeeklyReport>()
                {
                    new WeeklyReport(10, 11, new DateTime(2021, 10, 07), new DateTime(2021, 10, 13),
                                     WeeklyStatus.Okay, WeeklyStatus.Great, WeeklyStatus.Good,
                                     "some morale comment 2", "some stress comment 2", "some workload comment 2",
                                     "Some weekly high text 2", "Some weekly low text 2", "Some else text 2")
                });

            var controller = fixture.GetWeeklyReportController();

            var weeklyReports = controller.Get(1);

            weeklyReports.Should().NotBeNull();
            weeklyReports.Should().HaveCount(1);

            fixture.WeeklyReportRepository.Verify(x => x.ReadAllByParentId(1), Times.Once);
        }
    }

    public class WeeklyReportControllerFixture
    {
        public Mock<IRepository<WeeklyReport>> WeeklyReportRepository { get; set; }

        public WeeklyReportControllerFixture()
        {
            WeeklyReportRepository = new Mock<IRepository<WeeklyReport>>();
        }

        public WeeklyReportController GetWeeklyReportController()
        {
            return new WeeklyReportController(WeeklyReportRepository.Object);
        }
    }
}
