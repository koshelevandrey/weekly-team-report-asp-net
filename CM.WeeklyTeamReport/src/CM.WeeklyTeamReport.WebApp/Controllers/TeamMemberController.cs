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
        public void Post(int companyId, [BindRequired] string firstName, [BindRequired] string lastName,
            [BindRequired] string title, [BindRequired] string inviteLink)
        {
            _repository.Create(new TeamMember(-1, companyId, firstName, lastName, title, inviteLink));
        }

        [HttpPut]
        public void Put([BindRequired] int teamMemberId, [BindRequired] int companyId,
            [BindRequired] string firstName, [BindRequired] string lastName,
            [BindRequired] string title, [BindRequired] string inviteLink)
        {
            _repository.Update(new TeamMember(teamMemberId, companyId, firstName, lastName, title, inviteLink));
        }

        [HttpDelete("{teamMemberId}")]
        public void Delete(int teamMemberId)
        {
            _repository.Delete(teamMemberId);
        }
    }
}
