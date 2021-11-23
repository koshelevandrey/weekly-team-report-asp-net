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
    public class TeamMemberControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateTeamMemberController()
        {
            var fixture = new TeamMemberControllerFixture();
            var controller = fixture.GetTeamMemberController();
        }

        [Fact]
        public void ShouldReturnAllTeamMembersByCompany()
        {
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository.Setup(x => x.ReadAllByParentId(1))
                .Returns(new List<TeamMember>()
                {
                    new TeamMember(1, 1, "Ivan", "Petrov", "CEO", "example.com")
                });

            var controller = fixture.GetTeamMemberController();

            var teamMembers = controller.GetAllByCompanyId(1);

            teamMembers.Should().NotBeNull();
            teamMembers.Should().HaveCount(1);

            fixture.TeamMemberRepository.Verify(x => x.ReadAllByParentId(1), Times.Once);
        }

        [Fact]
        public void ShouldReturnTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository.Setup(x => x.Read(1))
                .Returns(new TeamMember(1, 1, "Ivan", "Petrov", "CEO", "example.com"));

            var controller = fixture.GetTeamMemberController();

            var teamMembers = controller.Get(1);

            teamMembers.Should().NotBeNull();
            fixture.TeamMemberRepository.Verify(x => x.Read(1), Times.Once);
        }

        [Fact]
        public void ShouldAddTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            TeamMember teamMember = new TeamMember(1, 1, "Ivan", "Petrov", "CEO", "invite.com");
            fixture.TeamMemberRepository.Setup(x => x.Create(teamMember));

            var controller = fixture.GetTeamMemberController();
            controller.Post(teamMember);

            fixture.TeamMemberRepository.Verify(x => x.Create(teamMember), Times.Once);
        }

        [Fact]
        public void ShouldUpdateTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            TeamMember teamMember = new TeamMember(1, 1, "Ivan", "Petrov", "CEO", "invite.com");
            fixture.TeamMemberRepository.Setup(x => x.Update(teamMember));

            var controller = fixture.GetTeamMemberController();
            controller.Put(teamMember);

            fixture.TeamMemberRepository.Verify(x => x.Update(teamMember), Times.Once);
        }

        [Fact]
        public void ShouldDeleteTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            int teamMemberId = 5;
            fixture.TeamMemberRepository.Setup(x => x.Delete(teamMemberId));

            var controller = fixture.GetTeamMemberController();
            controller.Delete(teamMemberId);

            fixture.TeamMemberRepository.Verify(x => x.Delete(teamMemberId), Times.Once);
        }
    }

    public class TeamMemberControllerFixture
    {
        public Mock<IRepository<TeamMember>> TeamMemberRepository { get; set; }

        public TeamMemberControllerFixture()
        {
            TeamMemberRepository = new Mock<IRepository<TeamMember>>();
        }

        public TeamMemberController GetTeamMemberController()
        {
            return new TeamMemberController(TeamMemberRepository.Object);
        }
    }
}
