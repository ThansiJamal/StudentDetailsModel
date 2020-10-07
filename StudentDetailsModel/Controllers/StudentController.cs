using StudentDetailsModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDetailsModel.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentDetails()
        {
            Student s = new Student();
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=StudentDetails;trusted_connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("StudentGet", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", 1);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                s.Id = 1;
                s.Name = dr["Name"].ToString();
                s.Email = dr["Email"].ToString();
                s.Mobile = dr["Mobile"].ToString();

            }
            connect.Close();
            return View(s);
        }
        public ActionResult StudentList()
        {
            List<Student> students = new List<Student>();
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=StudentDetails;trusted_connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("StudentGetAll", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
           // Student temp = new Student();
            while (dr.Read())
            {
                Student temp = new Student();
                temp.Id=Convert.ToInt32( dr["Id"].ToString());
                temp.Name = dr["Name"].ToString();
                temp.Email = dr["Email"].ToString();
                temp.Mobile = dr["Mobile"].ToString();
                students.Add(temp);
            }
            connect.Close();

            return View(students);
        }
    }
}