using EmplDataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CRUD_One_To_Many.Controllers
{
    public class EmployeeController : ApiController
    {
        //Создание тестовых таблиц
        [Route("api/CreateData")]
        public void Post()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                Company c1 = new Company();
                Company c2 = new Company();
                db.Companies.Add(c1);
                db.Companies.Add(c2);
                db.SaveChanges();
                Employee empl1 = new Employee { Name = "Роналду", Company = c1 };
                Employee empl2 = new Employee { Name = "Пётр", Company = c1 };
                Employee empl3 = new Employee { Name = "Семён", Company = c2 };
                db.Employees.AddRange(new List<Employee> { empl1, empl2, empl3 });
                db.SaveChanges();

            }
        }


        [Route("api/set/{id}/{CompanyId}/")]

        public void Post(int id, int companyid, [FromUri]Employee emploee, [FromUri]Company company)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var editempl = db.Employees.FirstOrDefault(e => e.id == id);
                var setcompany = db.Companies.FirstOrDefault(c => c.Companyid == companyid);
                editempl.CompanyId = setcompany.Companyid;
                db.SaveChanges();
            }
        }
                                            
        [Route("api/empl_from_company/{companyid}")]
        public IEnumerable<Employee> Get(int companyid)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employees = db.Employees.Where(e => e.CompanyId == companyid);

                return employees.ToList();
            }
        }

        
        [Route("api/AllEmpl")]
        public IEnumerable<Employee> Get()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                return db.Employees.ToList();
            }
        }

        
        [Route("api/CreateEmpl")]
        public void Post([FromBody]Employee employee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        
        [Route("api/EditEmpl/{Id}/")]
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            try
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    var editempl = db.Employees.FirstOrDefault(e => e.id == id);

                    if (editempl == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id = {id} not found to update");
                    }
                    else
                    {
                        editempl.Name = employee.Name;
                        editempl.Sername = employee.Sername;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, editempl);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
            
        }

        
        [Route("api/DeleteEmpl/{Id}/")]
        public void Delete(int id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Employees.Remove(db.Employees.FirstOrDefault(e => e.id == id));
                db.SaveChanges();
            }
        }
    }
}
