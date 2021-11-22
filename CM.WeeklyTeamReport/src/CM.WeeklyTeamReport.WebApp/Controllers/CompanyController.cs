using CM.WeeklyTeamReport.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public List<Company> Get()
        {
            return new List<Company>()
            {
                new Company(1, "ANKO", new DateTime(2020, 11, 20))
            };
        }
    }
}
