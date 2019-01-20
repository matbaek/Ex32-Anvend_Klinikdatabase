using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ex32_Anvend_Klinikdatabase
{
    public class DatabaseConnection
    {
        private static string connectionString =
            "Data Source = EALSQL1.Eal.Local;" +
            "Database = Ex31Klinik;" +
            "User ID = C_STUDENT10;" +
            "Password = C_OPENDB10;";

        private SqlConnection SqlConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        private SqlCommand SqlCommand(string query, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(query, con);
            return command;
        }

        public void InsertAddress(string street, string number, string code)
        {
            string query = "EXEC IndsætAdresse '" + street + "', '" + number + "', '" + code + "'";
            SqlConnection con = SqlConnection();
            using (SqlCommand command = SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("Row has been added!");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }

        public void InsertDoctor(string name, string homeStreet, string homeNumber, string homeCode, string homeCity, 
            string workStreet, string workNumber, string workCode, string workCity, int clinicID, string salaryScale)
        {
            string query = "EXEC IndsætLæge '" + name + "', '" + homeStreet + "', '" + homeNumber + "', '" + homeCode + "', '" + homeCity + "', " +
                "'" + workStreet + "', '" + workNumber + "', '" + workCode + "', '" + workCity + "', " + clinicID + ", '" + salaryScale + "'";
            SqlConnection con = SqlConnection();
            using (SqlCommand command = SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("Row has been added!");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }

        public void ShowAppointment(int patientID)
        {
            string query = "EXEC VisAftalerForPatient " + patientID;
            SqlConnection con = SqlConnection();
            using (SqlCommand command = SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string doctor = reader["Læge"].ToString();
                            string clinic = reader["KlinikAdresse"].ToString();
                            string patient = reader["Patient"].ToString();
                            string relative = reader["Pårørende"].ToString();
                            string date = reader["Dato"].ToString();
                            string time = reader["Tidspunkt"].ToString();
                            
                            Console.WriteLine("Læge: " + doctor);
                            Console.WriteLine("Klinik: " + clinic);
                            Console.WriteLine("Patient: " + patient);
                            Console.WriteLine("Pårørende: " + relative);
                            Console.WriteLine("Dato: " + date);
                            Console.WriteLine("Tid: " + time);
                            Console.WriteLine();
                        }
                    }

                    con.Close();

                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
