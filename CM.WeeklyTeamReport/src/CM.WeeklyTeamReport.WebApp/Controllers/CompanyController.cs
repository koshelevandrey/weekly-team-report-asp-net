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
        public Company Get(int companyId)
        {
            var result = _repository.Read(companyId);
            return result;
        }

        [HttpGet]
        public List<Company> GetAll()
        {
            return _repository.ReadAll();
        }

        [HttpPost]
        public void Post([BindRequired] string companyName, [BindRequired] DateTime joinedDate)
        {
            _repository.Create(new Company(-1, companyName, joinedDate));
        }

        [HttpPut]
        public void Put([BindRequired] int companyId, [BindRequired] string companyName,
            [BindRequired] DateTime joinedDate)
        {
            _repository.Update(new Company(companyId, companyName, joinedDate));
        }

        [HttpDelete("{companyId}")]
        public void Delete(int companyId)
        {
            _repository.Delete(companyId);
        }
    }
}
