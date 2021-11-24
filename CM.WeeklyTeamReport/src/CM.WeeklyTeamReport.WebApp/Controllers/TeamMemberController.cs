﻿using CM.WeeklyTeamReport.Domain;
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
        public ActionResult Get(int memberId)
        {
            var result = _repository.Read(memberId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAllByCompanyId(int companyId)
        {
            var result = _repository.ReadAllByParentId(companyId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromQuery] TeamMember teamMember)
        {
            var result = _repository.Create(teamMember);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Put([FromQuery] TeamMember teamMember)
        {
            var result = _repository.Read(teamMember.TeamMemberId);
            if (result == null)
            {
                return NotFound();
            }
            _repository.Update(teamMember);
            return Ok();
        }

        [HttpDelete("{memberId}")]
        public ActionResult Delete(int memberId)
        {
            var result = _repository.Read(memberId);
            if (result == null)
            {
                return NotFound();
            }
            _repository.Delete(memberId);
            return Ok();
        }
    }
}
