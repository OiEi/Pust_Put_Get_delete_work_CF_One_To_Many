
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmplDataAcces
{


    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

        public string Sername { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }

        public Company Company { get; set; }
    }

    public class Company
    {
        
        [Key]
        public int Companyid { get; set; }
       
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

                
    }

}



