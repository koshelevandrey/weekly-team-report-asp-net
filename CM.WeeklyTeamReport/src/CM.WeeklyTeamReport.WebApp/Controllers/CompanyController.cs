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
        public void Post([FromQuery] Company company)
        {
            _repository.Create(company);
        }

        [HttpPut]
        public void Put([FromQuery] Company company)
        {
            _repository.Update(company);
        }

        [HttpDelete("{companyId}")]
        public void Delete(int companyId)
        {
            _repository.Delete(companyId);
        }
    }
}
