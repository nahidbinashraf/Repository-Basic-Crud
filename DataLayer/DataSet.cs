using System.Data.Entity;

namespace DataLayer
{
    public class DataSet : DbContext
    {
        public DataSet() : base("ListTestDB")
        {

        }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<Department> Departments { get; set; }
    }


}
