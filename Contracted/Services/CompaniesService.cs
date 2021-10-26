using System;
using System.Collections.Generic;
using Contracted.Models;

namespace Contracted.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _CompaniesRepository;

    public CompaniesService(CompaniesRepository companiesRepository)
    {
      _companiesRepository = companiesRepository;
    }

    public List<Company> GetAll()
    {
      return _CompaniesRepository.GetAll();
    }

    public Company GetById(int companyId)
    {
      Company foundCompanies = _companiesRepository.GetById(companyId);
      if (foundCompanies == null)
      {
        throw new Exception('Unable to find Companies');
      }
      return foundCompanies;
    }

    public Company Post(Company companyData)
    {
      return _companiesRepository.Post(companyData);
    }

    public void RemoveCompany(int companyId, string userId)
    {
      Company foundCompany = GetById(companyId);
      if (foundCompany.CreatorId != userId)
      {
        throw new Exception('That aint your Companies');
      }
      _CompaniesRepository.RemoveCompanies(companyId);
    }

  }
}