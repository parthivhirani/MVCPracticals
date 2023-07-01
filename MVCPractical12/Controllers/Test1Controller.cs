using MVCPractical12.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical12.Controllers
{
    public class Test1Controller : Controller
    {
        [NonAction]
        public static List<Employee> FetchData()
        {
            List<Employee> empList = new List<Employee>();
            string ConString = "data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                var sqlcmd = new SqlCommand("SELECT * FROM Employee;", connection);
                var result = sqlcmd.ExecuteReader();
                while(result.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = (int)result["Id"];
                    emp.FirstName = (string)result["FirstName"];
                    emp.MiddleName = (string)result["MiddleName"];
                    emp.LastName = (string)result["LastName"];
                    emp.FirstName = (string)result["FirstName"];
                    emp.DOB = (DateTime)result["DOB"];
                    emp.MobileNumber = (string)result["MobileNumber"];
                    emp.Address = (string)result["Address"];
                    empList.Add(emp);
                }
                return empList;
            }
        }

        public ActionResult Index()
        {
            return View(FetchData());
        }

        public ActionResult Query1()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"INSERT INTO Employee VALUES ('Parthiv', 'VipulBhai', 'Hirani', '2001-10-27', '9574760899', 'Rajkot'),
                                       ('Vaidehi', 'VipulBhai', 'Hirani', '1995-08-20', '7665677577', 'Ahmedabad')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }


        public ActionResult Query2()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"UPDATE Employee SET FirstName='SQLPerson' WHERE Id=1;", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Query3()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"UPDATE Employee SET MiddleName='I';", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Query4()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"DELETE FROM Employee WHERE Id<2;", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Query5()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"TRUNCATE TABLE Employee;", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
    }
}