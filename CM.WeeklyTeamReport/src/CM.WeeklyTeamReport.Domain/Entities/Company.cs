using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<TeamMember> TeamMembers { get; set; }

        public Company(string name, DateTime joinedDate, List<TeamMember> teamMembers)
        {
            Name = name;
            JoinedDate = joinedDate;
            TeamMembers = teamMembers;
        }

        public void AddTeamMember(TeamMember teamMember)
        {

        }
    }
}
