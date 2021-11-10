using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class TeamMember
    {
        public string FirstName;
        public string LastName;
        public string Title;
        public string InviteLink;
        public List<WeeklyReport> Reports;
        public List<TeamMember> ReportsTo;
        public List<TeamMember> GetReportsFrom;

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
