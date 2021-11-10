using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class TeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string InviteLink { get; set; }
        public List<WeeklyReport> Reports { get; set; }
        public List<TeamMember> ReportsTo { get; set; }
        public List<TeamMember> GetReportsFrom { get; set; }

        public TeamMember(string firstName, string lastName, string title, string inviteLink,
            List<WeeklyReport> reports, List<TeamMember> reportsTo, List<TeamMember> getReportsFrom)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            InviteLink = inviteLink;
            Reports = reports;
            ReportsTo = reportsTo;
            GetReportsFrom = getReportsFrom;
        }
    }
}
