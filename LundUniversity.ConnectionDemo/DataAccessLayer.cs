using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LundUniversity.ConnectionDemo
{
    public class DataAccessLayer
    {
        public SqlConnection GetDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDepartmentConnectionString"].ConnectionString;

            SqlConnectionStringBuilder builder = new(connectionString);

            SqlConnection connection = new(builder.ConnectionString);

            return connection;
        }

        public void PrintAllEmployees()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Employee";
            connection.Open();

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Console.WriteLine(sqlDataReader.GetString(0));
                Console.WriteLine(sqlDataReader.GetString(1));
                Console.WriteLine(sqlDataReader.GetInt32(2));
                Console.WriteLine(sqlDataReader.GetString(3));
                Console.WriteLine("------------------------");
            }

            sqlDataReader.Close();
            connection.Close();
            connection.Dispose();
        }

        public void InsertEmployee(string empId, string empName, int empSalary, string deptName)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Employee VALUES(@EmpId, @EmpName, @EmpSalary, @DeptName)";
            command.Parameters.Add(new SqlParameter("@EmpId", empId));
            command.Parameters.Add(new SqlParameter("@EmpName", empName));
            command.Parameters.Add(new SqlParameter("@EmpSalary", empSalary));
            command.Parameters.Add(new SqlParameter("@DeptName", deptName));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }
    }
}
