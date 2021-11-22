using System;
using Xunit;
using CM.WeeklyTeamReport.Domain.Repositories;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain.IntegrationTests
{
    public class CompanyRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCompanyRepository()
        {
            var companyRepository = new CompanyRepository();

            Assert.NotNull(companyRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCompanyAndSaveItToDatabase()
        {
            var companyRepository = new CompanyRepository();
            var company = new Company(1, "ANKO", new DateTime(2010, 11, 21));
            company = companyRepository.Create(company);

            Assert.NotNull(company);
            Assert.True(company.CompanyId > 0);
            Assert.Equal("ANKO", company.Name);
            Assert.Equal(new DateTime(2010, 11, 21), company.JoinedDate);
        }

        [Fact]
        public void ShouldBeAbleToReadCompanyFromDatabase()
        {
            var companyRepository = new CompanyRepository();
            var company = companyRepository.Read(2);

            Assert.NotNull(company);
            Assert.Equal(2, company.CompanyId);
            Assert.Equal("ANKO", company.Name);
            Assert.Equal(new DateTime(2010, 11, 21), company.JoinedDate);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCompanyInDatabase()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Update(new Company(3, "Magnit", new DateTime(2008, 04, 10)));

            var company = companyRepository.Read(3);
            Assert.NotNull(company);
            Assert.Equal(3, company.CompanyId);
            Assert.Equal("Magnit", company.Name);
            Assert.Equal(new DateTime(2008, 04, 10), company.JoinedDate);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCompanyFromDatabase()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Delete(1);

            Assert.Null(companyRepository.Read(1));
        }
    }
}
