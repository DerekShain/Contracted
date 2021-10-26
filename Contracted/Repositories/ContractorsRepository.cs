using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Interfaces;
using Contracted.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Repositories
{
  public class ContractorsRepository : DbContext, IRepository<Contractor>
  {
    public ContractorsRepository(IDbConnection db) : base(db)
    {
    }

    public Contractor Create(Contractor data)
    {
      string sql = @"
      INSERT INTO contractors(
        name,
        picture,
        creator,
        creatorId
      )
      VALUES(
        @Name,
        @Picture,
        @Creator,
        @CreatorId
      );
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int id)
    {
      var affected = _db.Execute("DELETE FROM contractors WHERE id = @id", new { id });
      if (affected > 1)
      {
        throw new System.Exception("Somethings Wrong");
      }
      if (affected == 0)
      {
        throw new System.Exception("Delete Failed");
      }
    }

    public Contractor Edit(int id, contractorData)
    {

    }

    public Contractor Edit(int id, Contractor data)
    {
      throw new System.NotImplementedException();
    }

    public List<Contractor> Get()
    {
      string sql = @"
      SELECT *
      FROM contractors
      ";
      return _db.Query<Contractor>(sql).ToList();
    }

    public Contractor Get(int id)
    {
      string sql = @"
      SELECT *
      FROM contractors
      WHERE id = @id
      ";
      return _db.Query<Contractor>(sql, new { id }).FirstOrDefault();
    }

    internal ActionResult<Contractor> Update(Contractor contractor)
    {
      throw new System.NotImplementedException();
    }
  }
}
