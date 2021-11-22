using System;
using Xunit;
using CM.WeeklyTeamReport.Domain.Repositories;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain.IntegrationTests
{
    public class TeamMemberRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateTeamMemberRepository()
        {
            var teamMemberRepository = new TeamMemberRepository();

            Assert.NotNull(teamMemberRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateTeamMemberAndSaveItToDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var teamMember = new TeamMember(1, 2, "Petr", "Smirnov", "Producer", "invite.com");
            teamMember = teamMemberRepository.Create(teamMember);

            Assert.NotNull(teamMember);
            Assert.Equal(2, teamMember.CompanyId);
            Assert.Equal("Petr", teamMember.FirstName);
            Assert.Equal("Smirnov", teamMember.LastName);
            Assert.Equal("Producer", teamMember.Title);
            Assert.Equal("invite.com", teamMember.InviteLink);
        }

        [Fact]
        public void ShouldBeAbleToReadTeamMemberFromDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var teamMember = teamMemberRepository.Read(4);

            Assert.NotNull(teamMember);
            Assert.Equal(2, teamMember.CompanyId);
            Assert.Equal("Petr", teamMember.FirstName);
            Assert.Equal("Smirnov", teamMember.LastName);
            Assert.Equal("Producer", teamMember.Title);
            Assert.Equal("invite.com", teamMember.InviteLink);
        }

        [Fact]
        public void ShouldBeAbleToUpdateTeamMemberInDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            teamMemberRepository.Update(new TeamMember(5, 2, "Nikita", "Kupcov", "Controller", "invite2.com"));

            var teamMember = teamMemberRepository.Read(5);
            Assert.NotNull(teamMember);
            Assert.Equal(5, teamMember.TeamMemberId);
            Assert.Equal(2, teamMember.CompanyId);
            Assert.Equal("Nikita", teamMember.FirstName);
            Assert.Equal("Kupcov", teamMember.LastName);
            Assert.Equal("Controller", teamMember.Title);
            Assert.Equal("invite2.com", teamMember.InviteLink);
        }

        [Fact]
        public void ShouldBeAbleToDeleteTeamMemberFromDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            teamMemberRepository.Delete(6);

            Assert.Null(teamMemberRepository.Read(6));
        }
    }
}
