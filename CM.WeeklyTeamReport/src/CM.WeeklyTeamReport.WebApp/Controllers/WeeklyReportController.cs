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
        public ActionResult Get(int reportId)
        {
            var result = _repository.Read(reportId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAllByMember(int memberId)
        {
            var result = _repository.ReadAllByParentId(memberId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromQuery] WeeklyReport weeklyReport)
        {
            var result = _repository.Create(weeklyReport);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Put([FromQuery] WeeklyReport weeklyReport)
        {
            var result = _repository.Read(weeklyReport.WeeklyReportId);
            if (result == null)
            {
                return NotFound();
            }
            _repository.Update(weeklyReport);
            return Ok();
        }

        [HttpDelete("{reportId}")]
        public ActionResult Delete(int reportId)
        {
            var result = _repository.Read(reportId);
            if (result == null)
            {
                return NotFound();
            }
            _repository.Delete(reportId);
            return Ok();
        }
    }
}
