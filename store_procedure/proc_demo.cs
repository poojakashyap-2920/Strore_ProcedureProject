using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;


namespace review_proc
{
    
    internal class proc_demo
    {
        static SqlConnection con = null;
     
        public static void Main(string[] args)
        {
            string cs = "server=LAPTOP-8UBL005A\\SQLEXPRESS03; Initial Catalog =review; Integrated Security=SSPI;MultipleActiveResultSets=True;";
            con = new SqlConnection(cs);
            con.Open();
            //[dbo].[spgetval]
           while(true)
            {
                Console.WriteLine("1.ShowId Detail\n" +
               "2.Insert\n"
               + "3.Update\n" +
               "4.Delete\n" +
               "5.select");
                Console.WriteLine("enter option...");
                int option = int.Parse(Console.ReadLine());
                switch(option)
                    {
                    case 1:
                        proc_demo.ShowD(con);
                        Console.WriteLine();
                        break;
                    case 2:
                        proc_demo.InsertD(con);
                        Console.WriteLine("record inserted successfully..");
                        break;
                   case 3:
                       proc_demo.UpdateD(con);
                        Console.WriteLine("record updated successfully");
                        break;
                    case 4:
                        proc_demo.deleteD(con);
                        Console.WriteLine("record deleted successfully...");
                        break;
                    case 5:
                        spselectv(con);
                        Console.WriteLine();
                        break;

                }

            }




        }
        static void ShowD(SqlConnection con)
        {
            string sp = "spgetval";
            SqlCommand cmd = new SqlCommand(sp, con);
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("enter name");
            string name = Console.ReadLine();


            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"] + " " + reader["name"] + " " + reader["age"] + " " + reader["dept"] + " " + reader["salary"]);
            }
        }
        static void InsertD(SqlConnection con)
        {
            string si = "spinsertv"; //spinsertv
            SqlCommand cmd = new SqlCommand(si, con);
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("enter name");
            string name = Console.ReadLine();

            Console.WriteLine("enter age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("enter dept");
            string dept = Console.ReadLine();

            Console.WriteLine("enter salary");
            int salary = int.Parse(Console.ReadLine());

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            Console.WriteLine("stored all deteils...");

        }

        static void deleteD(SqlConnection con)
        {
            Console.WriteLine("enter id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("spdelete1", con);

            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
           // SqlDataReader.Close();

        }

        static void UpdateD(SqlConnection con)
        {
            Console.WriteLine("Enter id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter dept");
            string dept = Console.ReadLine();

            Console.WriteLine("Enter salary");
            int salary = int.Parse(Console.ReadLine());

            // Assuming the stored procedure name is "UpdateEmployee"
            using (SqlCommand cmd = new SqlCommand("spupdate1", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Dept", dept);
                cmd.Parameters.AddWithValue("@Salary", salary);

                // Execute the command
                cmd.ExecuteNonQuery();

                Console.WriteLine("Record updated successfully.");
            }
        }

        static void spselectv(SqlConnection con)
        {
            string insertsp = "spselectv";
           

            SqlCommand cmd = new SqlCommand(insertsp, con);
           
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"] + " " + reader["name"] + " " + reader["age"] + " " + reader["dept"] + " " + reader["salary"]);
            }
            

        }


    }
}

