using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.Domain.Repositories;
using CM.WeeklyTeamReport.WebApp.Controllers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.WebApp.Tests
{
    public class CompanyControllerTests
    {
        [Fact]
        public void ShouldReturnAllCompanies()
        {
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.ReadAll())
                .Returns(new List<Company>()
                {
                    new Company(1, "ANKO", new DateTime(2020, 11, 20)),
                    new Company(2, "Magnit", new DateTime(2010, 05, 13)),
                    new Company(3, "Pyaterochka", new DateTime(2015, 07, 29))
                });

            var controller = fixture.GetCompanyController();
            var companies = controller.GetAll();

            companies.Should().NotBeNull();
            companies.Should().HaveCount(3);

            fixture.CompanyRepository.Verify(x => x.ReadAll(), Times.Once);
        }

        [Fact]
        public void ShouldReturnCompany()
        {
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.Read(11))
                .Returns(new Company(11, "Pyaterochka", new DateTime(2015, 07, 29)));

            var controller = fixture.GetCompanyController();
            var company = controller.Get(11);

            company.Should().NotBeNull();

            fixture.CompanyRepository.Verify(x => x.Read(11), Times.Once);
        }

        [Fact]
        public void ShouldCreateCompany()
        {
            var fixture = new CompanyControllerFixture();
            var company = new Company(-1, "Pyaterochka", new DateTime(2015, 07, 29));
            fixture.CompanyRepository
                .Setup(x => x.Create(company));

            var controller = fixture.GetCompanyController();
            controller.Post(company);

            fixture.CompanyRepository.Verify(x => x.Create(company),
            Times.Once);
        }
    }

    public class CompanyControllerFixture
    {
        public Mock<IRepository<Company>> CompanyRepository { get; set; }

        public CompanyControllerFixture()
        {
            CompanyRepository = new Mock<IRepository<Company>>();
        }

        public CompanyController GetCompanyController()
        {
            return new CompanyController(CompanyRepository.Object);
        }
    }
}
