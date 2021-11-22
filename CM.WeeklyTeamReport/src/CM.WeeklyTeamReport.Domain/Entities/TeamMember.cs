using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string InviteLink { get; set; }

        public TeamMember(int teamMemberId, int companyId, string firstName,
            string lastName, string title, string inviteLink)
        {
            TeamMemberId = teamMemberId;
            CompanyId = companyId;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            InviteLink = inviteLink;
        }
    }
}
