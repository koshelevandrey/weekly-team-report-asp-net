using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        [HttpGet("{reportId}")]
        public WeeklyReport Get(int reportId)
        {
            var result = _repository.Read(reportId);
            return result;
        }

        [HttpGet]
        public List<WeeklyReport> GetAllByMember(int memberId)
        {
            return _repository.ReadAllByParentId(memberId);
        }

        [HttpPost]
        public void Post([FromQuery] WeeklyReport weeklyReport)
        {
            _repository.Create(weeklyReport);
        }

        [HttpPut]
        public void Put([FromQuery] WeeklyReport weeklyReport)
        {
            _repository.Update(weeklyReport);
        }

        [HttpDelete("{reportId}")]
        public void Delete(int reportId)
        {
            _repository.Delete(reportId);
        }
    }
}
