namespace Contracted.Models
{
  public class Job
  {
    public int Id { get; set; }
    public int ContractorId { get; set; }
    public int CompanyId { get; set; }
  }
  public class JobSiteViewModel : Contractor
  {
    public int ContractorId { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string ContractorName { get; set; }
  }
}