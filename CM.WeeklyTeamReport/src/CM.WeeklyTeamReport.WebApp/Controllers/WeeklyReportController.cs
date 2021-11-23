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
        public void Post([BindRequired] int memberId, [BindRequired] DateTime dateStart,
            [BindRequired] DateTime dateEnd, [BindRequired] int morale, [BindRequired] int stress,
            [BindRequired] int workload, [BindRequired] string moraleComment,
            [BindRequired] string stressComment, [BindRequired] string workloadComment,
            [BindRequired] string weeklyHighText, [BindRequired] string weeklyLowText,
            [BindRequired] string anythingElseText)
        {
            _repository.Create(new WeeklyReport(-1, memberId, dateStart, dateEnd,
                (WeeklyStatus)morale, (WeeklyStatus)stress, (WeeklyStatus)workload,
                moraleComment, stressComment, workloadComment, weeklyHighText,
                weeklyLowText, anythingElseText));
        }

        [HttpPut]
        public void Put([BindRequired] int reportId, int memberId,
            [BindRequired] DateTime dateStart, [BindRequired] DateTime dateEnd,
            [BindRequired] int morale, [BindRequired] int stress,
            [BindRequired] int workload, [BindRequired] string moraleComment,
            [BindRequired] string stressComment, [BindRequired] string workloadComment,
            [BindRequired] string weeklyHighText, [BindRequired] string weeklyLowText,
            [BindRequired] string anythingElseText)
        {
            _repository.Update(new WeeklyReport(reportId, memberId, dateStart, dateEnd,
                (WeeklyStatus)morale, (WeeklyStatus)stress, (WeeklyStatus)workload,
                moraleComment, stressComment, workloadComment, weeklyHighText,
                weeklyLowText, anythingElseText));
        }

        [HttpDelete("{reportId}")]
        public void Delete(int reportId)
        {
            _repository.Delete(reportId);
        }
    }
}
