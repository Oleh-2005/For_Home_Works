using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW_WF_Ado_31._08._2021.Entity
{
    public class Employee
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual Position Position { get; set; }
    }
}
