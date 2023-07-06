using MVCPractical12.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical12.Controllers
{
    public class Test2Controller : Controller
    {
        [NonAction]
        public static List<Employee2> FetchData()
        {
            List<Employee2> empList = new List<Employee2>();
            string ConString = "data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                var sqlcmd = new SqlCommand("SELECT * FROM Employee2;", connection);
                var result = sqlcmd.ExecuteReader();
                while (result.Read())
                {
                    Employee2 emp = new Employee2();
                    emp.Id = (int)result["Id"];
                    emp.FirstName = (string)result["FirstName"];
                    emp.MiddleName = string.IsNullOrEmpty(result["MiddleName"].ToString()) ? "NULL": result["MiddleName"].ToString();
                    emp.LastName = (string)result["LastName"];
                    emp.FirstName = (string)result["FirstName"];
                    emp.DOB = (DateTime)result["DOB"];
                    emp.MobileNumber = (string)result["MobileNumber"];
                    emp.Address = (string)result["Address"];
                    emp.Salary = (decimal)result["Salary"];
                    
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
            return View();
        }

        [HttpPost]
        public ActionResult Query1(Employee2 emp)
        {
            if (ModelState.IsValid)
            {
                var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
                var cmd = new SqlCommand($"INSERT INTO Employee2 VALUES ('{emp.FirstName}', '{emp.MiddleName}', '{emp.LastName}', '{emp.DOB.Year}-{emp.DOB.Month}-{emp.DOB.Day}', '{emp.MobileNumber}', '{emp.Address}', {emp.Salary})", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Query2()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT SUM(Salary) FROM Employee2;", con);
            con.Open();
            ViewBag.TotalSalary = cmd.ExecuteScalar();
            con.Close();
            return View();
        }

        public ActionResult Query3()
        {
            List<Employee2> empList = new List<Employee2>();
            string ConString = "data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                var sqlcmd = new SqlCommand("SELECT * FROM Employee2 WHERE DOB<'2000-01-01';", connection);
                var result = sqlcmd.ExecuteReader();
                while (result.Read())
                {
                    Employee2 emp = new Employee2();
                    emp.Id = (int)result["Id"];
                    emp.FirstName = (string)result["FirstName"];
                    emp.MiddleName = string.IsNullOrEmpty(result["MiddleName"].ToString()) ? "NULL" : result["MiddleName"].ToString();
                    emp.LastName = (string)result["LastName"];
                    emp.FirstName = (string)result["FirstName"];
                    emp.DOB = (DateTime)result["DOB"];
                    emp.MobileNumber = (string)result["MobileNumber"];
                    emp.Address = (string)result["Address"];
                    emp.Salary = (decimal)result["Salary"];

                    empList.Add(emp);
                }
            }
            return View(empList);
        }

        public ActionResult Query4()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Employee2 WHERE MiddleName IS null;", con);
            con.Open();
            ViewBag.NullEmployees = cmd.ExecuteScalar();
            con.Close();
            return View();
        }
    }
}