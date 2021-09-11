using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW_WF_Ado_31._08._2021.Entity
{
    public class Position
    {
        public Position()
        {

        }
        public Position(string name , ICollection<Employee> employees)
        {
            Employees = employees;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
