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
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> _repository;

        public CompanyController(IRepository<Company> repository)
        {
            _repository = repository;
        }

        [HttpGet("{companyId}")]
        public IActionResult Get(int companyId)
        {
            var result = _repository.Read(companyId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.ReadAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromQuery] Company company)
        {
            var createdCompany = _repository.Create(company);
            if (createdCompany == null)
            {
                return BadRequest();
            }
            return Ok(createdCompany);
        }

        [HttpPut]
        public IActionResult Put([FromQuery] Company company)
        {
            var readCompany = _repository.Read(company.CompanyId);
            if (readCompany == null)
            {
                return NotFound();
            }

            _repository.Update(company);
            return Ok();
        }

        [HttpDelete("{companyId}")]
        public IActionResult Delete(int companyId)
        {
            var readCompany = _repository.Read(companyId);
            if (readCompany == null)
            {
                return NotFound();
            }

            _repository.Delete(companyId);
            return Ok();
        }
    }
}
