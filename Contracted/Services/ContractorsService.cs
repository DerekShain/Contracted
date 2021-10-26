using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _contractorsRepository;

    public ContractorsService(ContractorsRepository contractorsRepository)
    {
      _contractorsRepository = contractorsRepository;
    }

    public List<Contractor> GetAll()
    {
      return _contractorsRepository.Get();
    }

    public Contractor GetById(int contractorId)
    {
      Contractor foundContractor = _contractorsRepository.Get(contractorId);
      if (foundContractor == null)
      {
        throw new Exception("Unable to find");
      }
      return foundContractor;
    }

    public Contractor Create(Contractor contractorData)
    {
      return _contractorsRepository.Create(contractorData);
    }

    public void DeleteContractor(int contractorId, string userId)
    {
      Contractor foundContractor = GetById(contractorId);
      if (foundContractor.CreatorId != userId)
      {
        throw new Exception("NOT your contractors");
      }
      _contractorsRepository.Delete(contractorId);
    }

    public Contractor Post(Contractor contractorData)
    {
      return _contractorsRepository.Create(contractorData);
    }

    internal ActionResult<Contractor> Update(Contractor updatedContractor, int id)
    {
      Contractor contractor = GetById(updatedContractor.Id);
      if (contractor.CreatorId != null)
      {
        throw new Exception("not allowed");
      }
      contractor.Id = updatedContractor.Id;
      return _contractorsRepository.Update(contractor);
    }
  }
}