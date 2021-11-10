using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public string Name;
        public string JoinedDate;
        public List<TeamMember> TeamMembers;

        public Company(string name, string joinedDate, List<TeamMember> teamMembers)
        {
            Name = name;
            JoinedDate = joinedDate;
            TeamMembers = teamMembers;
        }
    }
}
