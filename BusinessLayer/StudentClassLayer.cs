using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
   public class StudentClassLayer
    {
        // Reading from DB
        public IEnumerable<Student> Students
        {
            get // Read only property
            {
                // getting data from Web.config file, reading a connection string from Web.config file
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                // Listing (Reading ) from DB
                List<Student> students = new List<Student>();

                // Sql Connection Object, Reading from web.config file
                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); //Opening Connection
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from Student";
                    
                    SqlDataReader rdr = cmd.ExecuteReader();                  
                    // SqlDataReader rdr = cmd.ExecuteReader(); 

                    while (rdr.Read()) //reading through each row
                    {
                        Student student = new Student();
                       //  student.StudentID = Convert.ToInt32(rdr["StudentID"]); 
                        student.Name = rdr["name"].ToString();
                        student.Home_City = rdr["Home_City"].ToString();
                        student.Department_Name = rdr["Department_Name"].ToString();
                        student.Course_Enrolled = rdr["Course_Enrolled"].ToString();

                        students.Add(student);
                    }
                }
                return students;
            }
        }


        // -----------------------------------------------------------------------
        // Adding Students Data from View > Database
        // ------------------------------------------------------------------------
       
        public void AddStudent(Student student)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open(); // Opening a connection.

                SqlCommand cmd = new SqlCommand("SpAddStudent", con); // Reading from stored procedure

                cmd.CommandType = CommandType.StoredProcedure;


                // Adding new Query
                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = student.Name;
                cmd.Parameters.Add(paramName);


                // Adding new Query
                SqlParameter paramHome_City = new SqlParameter();
                paramHome_City.ParameterName = "@Home_City";
                paramHome_City.Value = student.Home_City;
                cmd.Parameters.Add(paramHome_City);

                // Adding new query
                SqlParameter paramDepartment_Name = new SqlParameter();
                paramDepartment_Name.ParameterName = "@Department_Name";
                paramDepartment_Name.Value = student.Department_Name;
                cmd.Parameters.Add(paramDepartment_Name);

                // Adding new Query   
                SqlParameter paramCourse_Enrolled = new SqlParameter();
                paramCourse_Enrolled.ParameterName = "@Course_Enrolled";
                paramCourse_Enrolled.Value = student.Course_Enrolled;
                cmd.Parameters.Add(paramCourse_Enrolled);

                cmd.ExecuteNonQuery();
            }
        }


    }
}
