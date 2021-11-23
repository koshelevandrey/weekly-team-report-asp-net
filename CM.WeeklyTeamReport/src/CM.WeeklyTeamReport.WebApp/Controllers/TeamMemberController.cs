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
    [Route("api/companies/{companyId}/members")]
    public class TeamMemberController : ControllerBase
    {
        private readonly IRepository<TeamMember> _repository;

        public TeamMemberController(IRepository<TeamMember> repository)
        {
            _repository = repository;
        }

        [HttpGet("{memberId}")]
        public TeamMember Get(int memberId)
        {
            var result = _repository.Read(memberId);
            return result;
        }

        [HttpGet]
        public List<TeamMember> GetAllByCompanyId(int companyId)
        {
            return _repository.ReadAllByParentId(companyId);
        }

        [HttpPost]
        public void Post([FromQuery] TeamMember teamMember)
        {
            _repository.Create(teamMember);
        }

        [HttpPut]
        public void Put([FromQuery] TeamMember teamMember)
        {
            _repository.Update(teamMember);
        }

        [HttpDelete("{memberId}")]
        public void Delete(int memberId)
        {
            _repository.Delete(memberId);
        }
    }
}
