namespace DemoGrpcService.Models
{
    public class DemoDatabaseSettings : IDemoDatabaseSettings
    {
        public required string EmployeesCollectionName { get; set; }
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
    }
    public interface IDemoDatabaseSettings
    {
        string EmployeesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}