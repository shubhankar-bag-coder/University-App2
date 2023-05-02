using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ProfessorBusinessLayer
    {
        public IEnumerable<Professors> Professors
        {
            get
            {
                // getting data from Web.config file, reading a connection string from Web.config file
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


                // Listing (Reading ) from DB

                List<Professors> professorss = new List<Professors>();

                // Sql Connection Object, Reading from web.config file
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); //Opening Connection
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from Professors";

                    SqlDataReader rdr = cmd.ExecuteReader();
                    // SqlDataReader rdr = cmd.ExecuteReader(); 

                    while (rdr.Read()) //reading through each row
                    {
                        Professors professors = new Professors();
                         //professors.Professor_ID = Convert.ToInt32(rdr["Professor_ID"]);
                        professors.Professors_Name = rdr["Professors_Name"].ToString();
                        professors.Department_Name = rdr["Department_Name"].ToString();
                        professors.Listof_Courses_taught = rdr["Listof_Courses_taught"].ToString();

                        professorss.Add(professors);
                    }
                }
                return professorss;

            }
        }

        public void AddProfessor(Professors professors)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open(); // Opening a connection.

                SqlCommand cmd = new SqlCommand("SpAddProfessor", con); // Reading from stored procedure

                cmd.CommandType = CommandType.StoredProcedure;


                // Adding new Query
                SqlParameter paramProfessors_Name = new SqlParameter();
                paramProfessors_Name.ParameterName = "@Professors_Name";
                paramProfessors_Name.Value = professors.Professors_Name;
                cmd.Parameters.Add(paramProfessors_Name);

                // Adding new Query
                SqlParameter paramDepartment_Name = new SqlParameter();
                paramDepartment_Name.ParameterName = "@Department_Name";
                paramDepartment_Name.Value = professors.Department_Name;
                cmd.Parameters.Add(paramDepartment_Name);

                // Adding new Query
                SqlParameter paramListof_Courses_taught = new SqlParameter();
                paramListof_Courses_taught.ParameterName = "@Listof_Courses_taught";
                paramListof_Courses_taught.Value = professors.Listof_Courses_taught;
                cmd.Parameters.Add(paramListof_Courses_taught);

                cmd.ExecuteNonQuery();
            }

        }

    }
 
}