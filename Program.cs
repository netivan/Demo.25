using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADONET.demo
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Lettura();
            Console.WriteLine("___________");
           // Aggiorna("update Persons set Lastname = 'Longo' where Firstname = 'Anna'");
            Aggiorna("insert into Persons values ('23443-5565', 'Jimmy', 'Åkesson', 1970)");
            Lettura();

        }
        
    


     static void Lettura()
        {

            List<Person> listPerson = new List<Person>();

            SqlConnection ProDB = new SqlConnection() ;

                ProDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                ProDB.Open();
                SqlCommand comand = new SqlCommand();
                comand.CommandText = "select * from Persons";
                comand.CommandType = System.Data.CommandType.Text;
                comand.Connection = ProDB;
                SqlDataReader result = comand.ExecuteReader();

                while (result.Read())
                {
                Person p = new Person();
                p.SSN = result[1].ToString();
                p.FirstName = result[2].ToString();
                p.LastName = result[3].ToString();
                p.Year = (decimal)result[4];


              //  if (result.IsDBNull(4))  (decimal)result[4]/* p.Year = 0*/;
                //else
                //    p.Year = (int)result[4];

                listPerson.Add(p);

                //   !reader.IsDBNull("PricePerKg") ? (decimal?)reader["PricePerKg"] : null;

                //   Console.WriteLine($"{result["Persnnr"]}  {result["Firstname"]} {result["Lastname"]}");

                Console.WriteLine($"{result[1]}  {result[2]} {result[3]} {result[4]}");
                }

                ProDB.Close();

                Console.ReadLine();

            }
           public static void Aggiorna(string s)
        {
            using (SqlConnection ProDB = new SqlConnection())
            {
                   try
                {
                    ProDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                    ProDB.Open();
                    SqlCommand comand = new SqlCommand();
                    comand.CommandText = s;                      //"update Persons set Lastname = 'Johanson' where Firstname = 'Håkan'";
                    comand.CommandType = System.Data.CommandType.Text;
                    comand.Connection = ProDB;

                    int rowUpdated = comand.ExecuteNonQuery();
                    
                    if (rowUpdated < 1)
                        Console.WriteLine("nessuna riga modificata");
                    else
                        Console.WriteLine($"righe modificate {rowUpdated}");
                } 
                     catch 
                     (Exception Errore)
                { Console.WriteLine($" Errore : {Errore.Message} ");
                }

                }
                


            }
        }

         }






//using ADONETDemo01.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;

//namespace ADONETDemo01
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            SqlDataReaderDemo();
//            UpdateDemo();
//            DeleteDemo();
//            SafeDeleteDemo("Valencia");
//            InsertDemo();
//            StoredProcedureDemo();
//        }

//        private static void StoredProcedureDemo()
//        {
//            List<Employee> employees = new List<Employee>();

//            using (SqlConnection mercuryDB = new SqlConnection())
//            {
//                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//                try
//                {
//                    mercuryDB.Open();

//                    using (SqlCommand command = new SqlCommand())
//                    {
//                        command.CommandText = "PersonalMedTitel";
//                        command.CommandType = CommandType.StoredProcedure;
//                        command.Connection = mercuryDB;

//                        Add parameter.
//                        SqlParameter parameter = new SqlParameter();
//                        parameter.Value = "lagerarbetare";
//                        parameter.ParameterName = "@titel";
//                        parameter.SqlDbType = SqlDbType.VarChar;
//                        parameter.Size = 32;
//                        parameter.Direction = ParameterDirection.Input;
//                        command.Parameters.Add(parameter);

//                        using (SqlDataReader reader = command.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                Employee employee = new Employee()
//                                {
//                                    Namn = reader["Namn"].ToString(),
//                                    Lön = (decimal)reader["Lön"],
//                                    Titel = reader["Titel"].ToString()
//                                };

//                                employees.Add(employee);
//                            }
//                        }
//                    }
//                }
//                catch (SqlException e)
//                {
//                    Console.WriteLine(e.Message);
//                    Console.WriteLine("Problem med SQL");
//                }

//                foreach (Employee employee1 in employees)
//                {
//                    Console.WriteLine(employee1);
//                }
//            }
//        }

//        private static void InsertDemo()
//        {
//            using (SqlConnection mercuryDB = new SqlConnection())
//            {
//                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//                try
//                {
//                    mercuryDB.Open();

//                    using (SqlCommand command = new SqlCommand())
//                    {
//                        command.CommandText = "insert into Fruits values('Pear', 'Conference', 34.67)";
//                        command.CommandType = CommandType.Text;
//                        command.Connection = mercuryDB;
//                        int rowsAffectd = command.ExecuteNonQuery();

//                        if (rowsAffectd >= 1)
//                            Console.WriteLine("En eller flera rader infogade!");
//                        else
//                            Console.WriteLine("Ingen rad infogad.");
//                    }
//                }
//                catch (SqlException)
//                {
//                    Console.WriteLine("Problem med SQL");
//                }
//            }
//        }

//        private static void DeleteDemo()
//        {
//            using (SqlConnection mercuryDB = new SqlConnection())
//            {
//                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//                try
//                {
//                    mercuryDB.Open();

//                    using (SqlCommand command = new SqlCommand())
//                    {
//                        command.CommandText = "delete from Fruits where FruitName = 'Conference'";
//                        command.CommandType = CommandType.Text;
//                        command.Connection = mercuryDB;
//                        int rowsAffectd = command.ExecuteNonQuery();

//                        if (rowsAffectd >= 1)
//                            Console.WriteLine("En eller flera rader raderade!");
//                        else
//                            Console.WriteLine("Ingen rad raderad.");
//                    }
//                }
//                catch (SqlException)
//                {
//                    Console.WriteLine("Problem med SQL");
//                }
//            }
//        }

//        private static void SafeDeleteDemo(string fruitName)
//        {
//            using (SqlConnection mercuryDB = new SqlConnection())
//            {
//                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//                try
//                {
//                    mercuryDB.Open();

//                    using (SqlCommand command = new SqlCommand())
//                    {
//                        command.CommandText = $"delete from Fruits where FruitName = @fruitName";

//                        SqlParameter parameter = new SqlParameter();
//                        parameter.Value = fruitName;
//                        parameter.ParameterName = "@fruitName";
//                        parameter.SqlDbType = SqlDbType.VarChar;
//                        parameter.Size = 32;
//                        parameter.Direction = ParameterDirection.Input;
//                        command.Parameters.Add(parameter);

//                        command.CommandType = CommandType.Text;
//                        command.Connection = mercuryDB;
//                        int rowsAffectd = command.ExecuteNonQuery();

//                        if (rowsAffectd >= 1)
//                            Console.WriteLine("En eller flera rader raderade!");
//                        else
//                            Console.WriteLine("Ingen rad raderad.");
//                    }
//                }
//                catch (SqlException e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//        }

//        private static void UpdateDemo()
//        {
//            using (SqlConnection mercuryDB = new SqlConnection())
//            {
//                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//                try
//                {
//                    mercuryDB.Open();

//                    using (SqlCommand command = new SqlCommand())
//                    {
//                        command.CommandText = "update Fruits set PricePerKg = 300.00 where FruitName = 'Conference'";
//                        command.CommandType = CommandType.Text;
//                        command.Connection = mercuryDB;
//                        int rowsAffectd = command.ExecuteNonQuery();

//                        if (rowsAffectd >= 1)
//                            Console.WriteLine("En eller flera rader uppdaterade!");
//                        else
//                            Console.WriteLine("Ingen rad uppdaterad.");
//                    }
//                }
//                catch (SqlException)
//                {
//                    Console.WriteLine("Problem med SQL");
//                }
//            }
//        }

//        private static void SqlDataReaderDemo()
//        {
//            List<Fruit> fruits = new List<Fruit>();

//            using (SqlConnection mercuryDB = new SqlConnection())
//            {
//                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//                try
//                {
//                    mercuryDB.Open();

//                    using (SqlCommand command = new SqlCommand())
//                    {
//                        command.CommandText = "select * from Fruits";
//                        command.CommandType = CommandType.Text;
//                        command.Connection = mercuryDB;

//                        using (SqlDataReader reader = command.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                Fruit aFruit = new Fruit();
//                                aFruit.ID = (int)reader["ID"];
//                                aFruit.FruitType = reader["FruitType"].ToString();
//                                aFruit.FruitName = reader["FruitName"].ToString();
//                                aFruit.PricePerKg = !reader.IsDBNull("PricePerKg") ? (decimal?)reader["PricePerKg"] : null;
//                                fruits.Add(aFruit);
//                            }
//                        }
//                    }
//                }
//                catch (DivideByZeroException)
//                {
//                    Console.WriteLine("Tyvärr misslyckades anslutningen.");
//                }
//            }

//            Console.WriteLine("----------------------");

//            var resultSet = fruits
//                .Where(f => f.PricePerKg < 25);

//            foreach (Fruit fruit in resultSet)
//            {
//                Console.WriteLine(fruit);
//            }
//        }
//    }
//}
