using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public string Name { get; set; }
        public string JoinedDate { get; set; }
        public List<TeamMember> TeamMembers { get; set; }

        public Company(string name, string joinedDate, List<TeamMember> teamMembers)
        {
            Name = name;
            JoinedDate = joinedDate;
            TeamMembers = teamMembers;
        }
    }
}
