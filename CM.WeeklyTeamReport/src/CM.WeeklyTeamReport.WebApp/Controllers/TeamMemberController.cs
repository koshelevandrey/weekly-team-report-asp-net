using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public List<TeamMember> Get(int companyId)
        {
            return _repository.ReadAllByParentId(companyId);
        }
    }
}
