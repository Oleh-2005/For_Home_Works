using HomeW_WF_Ado_31._08._2021.Entity;
using System;
using System.Data.Entity;
using System.Linq;

namespace HomeW_WF_Ado_31._08._2021
{
    public class ApplicationContext : DbContext
    {
        
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer<ApplicationContext>(new DropCreateDatabaseAlways<ApplicationContext>());
        }


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

    }

}