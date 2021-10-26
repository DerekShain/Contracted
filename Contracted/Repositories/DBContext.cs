using System.Data;

namespace Contracted.Repositories

{

  public class DbContext

  {

    protected readonly IDbConnection _db;

    public DbContext(IDbConnection db)

    {

      _db = db;

    }

  }

}
