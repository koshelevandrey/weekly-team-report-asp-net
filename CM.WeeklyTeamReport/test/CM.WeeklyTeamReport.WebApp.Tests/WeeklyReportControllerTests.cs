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

            var weeklyReports = controller.GetAllByMember(1);

            weeklyReports.Should().NotBeNull();
            weeklyReports.Should().HaveCount(1);

            fixture.WeeklyReportRepository.Verify(x => x.ReadAllByParentId(1), Times.Once);
        }

        [Fact]
        public void ShouldReturnWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var weeklyReport = new WeeklyReport(10, 11, new DateTime(2021, 10, 07), new DateTime(2021, 10, 13),
                                     WeeklyStatus.Okay, WeeklyStatus.Great, WeeklyStatus.Good,
                                     "some morale comment 2", "some stress comment 2", "some workload comment 2",
                                     "Some weekly high text 2", "Some weekly low text 2", "Some else text 2");
            fixture.WeeklyReportRepository.Setup(x => x.Read(1))
                .Returns(weeklyReport);

            var controller = fixture.GetWeeklyReportController();
            weeklyReport = controller.Get(1);

            fixture.WeeklyReportRepository.Verify(x => x.Read(1), Times.Once);
        }

        [Fact]
        public void ShouldAddWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var weeklyReport = new WeeklyReport(10, 11, new DateTime(2021, 10, 07), new DateTime(2021, 10, 13),
                                     WeeklyStatus.Okay, WeeklyStatus.Great, WeeklyStatus.Good,
                                     "some morale comment 2", "some stress comment 2", "some workload comment 2",
                                     "Some weekly high text 2", "Some weekly low text 2", "Some else text 2");
            fixture.WeeklyReportRepository.Setup(x => x.Create(weeklyReport));

            var controller = fixture.GetWeeklyReportController();
            controller.Post(weeklyReport);

            fixture.WeeklyReportRepository.Verify(x => x.Create(weeklyReport), Times.Once);
        }

        [Fact]
        public void ShouldUpdateWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var weeklyReport = new WeeklyReport(10, 11, new DateTime(2021, 10, 07), new DateTime(2021, 10, 13),
                                     WeeklyStatus.Okay, WeeklyStatus.Great, WeeklyStatus.Good,
                                     "some morale comment 2", "some stress comment 2", "some workload comment 2",
                                     "Some weekly high text 2", "Some weekly low text 2", "Some else text 2");
            fixture.WeeklyReportRepository.Setup(x => x.Update(weeklyReport));

            var controller = fixture.GetWeeklyReportController();
            controller.Put(weeklyReport);

            fixture.WeeklyReportRepository.Verify(x => x.Update(weeklyReport), Times.Once);
        }

        [Fact]
        public void ShouldDeleteWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            var weeklyReportId = 5;
            fixture.WeeklyReportRepository.Setup(x => x.Delete(weeklyReportId));

            var controller = fixture.GetWeeklyReportController();
            controller.Delete(weeklyReportId);

            fixture.WeeklyReportRepository.Verify(x => x.Delete(weeklyReportId), Times.Once);
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
