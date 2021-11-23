using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [Route("api/companies/{companyId}/members/{memberId}/reports")]
    public class WeeklyReportController : ControllerBase
    {
        private readonly IRepository<WeeklyReport> _repository;

        public WeeklyReportController(IRepository<WeeklyReport> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<WeeklyReport> Get(int memberId)
        {
            return _repository.ReadAllByParentId(memberId);
        }
    }
}
