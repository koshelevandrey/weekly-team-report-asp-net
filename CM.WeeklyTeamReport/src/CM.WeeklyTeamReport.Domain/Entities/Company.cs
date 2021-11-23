using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }

        public Company(int companyId, string name, DateTime joinedDate)
        {
            CompanyId = companyId;
            Name = name;
            JoinedDate = joinedDate;
        }

        public Company() { }
    }
}
