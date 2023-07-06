using MVCPractical12.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical12.Controllers
{
    public class Test3Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Query1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query1(Employee3 emp)
        {
            if(ModelState.IsValid)
            {
                var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
                var cmd1 = new SqlCommand($"INSERT INTO Employee3 VALUES ('{emp.FirstName}', '{emp.MiddleName}', '{emp.LastName}', '{emp.DOB.Year}-{emp.DOB.Month}-{emp.DOB.Day}', '{emp.MobileNumber}', '{emp.Address}', {emp.Salary}, {emp.DesignationId})", con);

                con.Open();

                cmd1.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
            return View();
        }
            

        public ActionResult Query2()
        {
            List<Query2> query2 = new List<Query2>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT d.Designation, COUNT(*) AS Number_of_Employees FROM Employee3 e, Designation d WHERE d.Id = e.DesignationId GROUP BY Designation;", con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while(resultSet.Read())
            {
                Query2 query = new Query2();
                query.Designation = (string)resultSet["Designation"];
                query.Number_of_Employees = (int)resultSet["Number_of_Employees"];
                query2.Add(query);
            }
            con.Close();
            return View(query2);
        }

        public ActionResult Query3()
        {
            List<Query3> query3 = new List<Query3>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT e.FirstName, e.MiddleName, e.LastName, d.Designation FROM Employee3 e JOIN Designation d ON e.DesignationId = d.Id;", con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                Query3 query = new Query3();
                query.FirstName = (string)resultSet["FirstName"];
                query.MiddleName = (string)resultSet["MiddleName"];
                query.LastName = (string)resultSet["LastName"];
                query.Designation = (string)resultSet["Designation"];
                query3.Add(query);
            }
            con.Close();
            return View(query3);
        }

        public ActionResult Query4()
        {
            List<Query4> query4 = new List<Query4>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT * FROM getEmpDesignation;", con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                var query = new Query4();
                query.FirstName = (string)resultSet["FirstName"];
                query.MiddleName = (string)resultSet["MiddleName"];
                query.LastName = (string)resultSet["LastName"];
                query.Designation = (string)resultSet["Designation"];
                query.DOB = (DateTime)resultSet["DOB"];
                query.MobileNumber = (string)resultSet["MobileNumber"];
                query.Address = (string)resultSet["Address"];
                query.Salary = (decimal)resultSet["Salary"];
                query4.Add(query);
            }
            con.Close();
            return View(query4);
        }

        public ActionResult Query5()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"insertDataInDesignation", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("Designation", "Junior Engineer");
            cmd.Parameters.Add(param);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Query6()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand(@"insertDataInEmployee3", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("fName", "Abhay");
            SqlParameter param2 = new SqlParameter("mName", "H");
            SqlParameter param3 = new SqlParameter("lname", "Chothani");
            SqlParameter param4 = new SqlParameter("dob", Convert.ToDateTime("2001-07-21").Date);
            SqlParameter param5 = new SqlParameter("mobileNumber", "6787676530");
            SqlParameter param6 = new SqlParameter("address", "Gondal");
            SqlParameter param7 = new SqlParameter("salary", 45000.00);
            SqlParameter param8 = new SqlParameter("designationId", 3);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Query7()
        {
            List<Query7> query7 = new List<Query7>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT d.Designation, COUNT(e.DesignationId) Number_of_Employee FROM Employee3 e, Designation d WHERE d.Id = e.DesignationId GROUP BY Designation HAVING COUNT(e.DesignationId)>1;", con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                Query7 query = new Query7();
                query.Designation = (string)resultSet["Designation"];
                query.Number_of_Employee = (int)resultSet["Number_of_Employee"];
                query7.Add(query);
            }
            con.Close();
            return View(query7);
        }

        public ActionResult Query8()
        {
            List<Query8> query8 = new List<Query8>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("getEmployeeDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                var query = new Query8();
                query.Id = (int)resultSet["Id"];
                query.FirstName = (string)resultSet["FirstName"];
                query.MiddleName = (string)resultSet["MiddleName"];
                query.LastName = (string)resultSet["LastName"];
                query.Designation = (string)resultSet["Designation"];
                query.DOB = (DateTime)resultSet["DOB"];
                query.MobileNumber = (string)resultSet["MobileNumber"];
                query.Address = (string)resultSet["Address"];
                query.Salary = (decimal)resultSet["Salary"];
                query8.Add(query);
            }
            con.Close();
            return View(query8);
        }

        public ActionResult Query9()
        {
            List<Employee3> query9 = new List<Employee3>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("getEmployeeDetailsByDesignationId", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("designationId", 2);
            cmd.Parameters.Add(param);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                var query = new Employee3();
                query.Id = (int)resultSet["Id"];
                query.FirstName = (string)resultSet["FirstName"];
                query.MiddleName = (string)resultSet["MiddleName"];
                query.LastName = (string)resultSet["LastName"];
                query.DOB = (DateTime)resultSet["DOB"];
                query.MobileNumber = (string)resultSet["MobileNumber"];
                query.Address = (string)resultSet["Address"];
                query.Salary = (decimal)resultSet["Salary"];
                query9.Add(query);
            }
            con.Close();
            return View(query9);
        }

        public ActionResult Query10()
        {
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("CREATE NONCLUSTERED INDEX Non_Clustered_Index_On_DesignationId ON Employee3(DesignationId ASC);", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Query11()
        {
            List<Employee3> query11 = new List<Employee3>();
            var con = new SqlConnection("data source=.; database=MVCPracticals; user id=parthiv; password=Rmha@12345678;");
            var cmd = new SqlCommand("SELECT FirstName, LastName, Salary FROM Employee3 WHERE Salary IN (SELECT MAX(Salary) FROM Employee3);", con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                var query = new Employee3();
                query.FirstName = (string)resultSet["FirstName"];
                query.LastName = (string)resultSet["LastName"];
                query.Salary = (decimal)resultSet["Salary"];
                query11.Add(query);
            }
            con.Close();
            return View(query11);
        }
    }
}