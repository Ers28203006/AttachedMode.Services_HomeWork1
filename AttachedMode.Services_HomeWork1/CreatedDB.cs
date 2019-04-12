using AttachedMode.Services.Abstract_HomeWork1;
using System.Data.SqlClient;
using System.Threading;

namespace AttachedMode.Services_HomeWork1
{
    public class CreatedDB
    {
       public IReporter Reporter { get; set; }
        public void CreatedDataBase()
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS; Initial Catalog=Database; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }

            catch (SqlException exeption)
            {
                if (exeption.Number==4060)
                {
                    Reporter?.SendReporter("Подождите идет создание базы данных");
                    connection.Close();
                    string tempConnectionString = @"Data Source=(local)\SQLEXPRESS; Integrated Security=True";
                    connection =new SqlConnection(tempConnectionString);
                    SqlCommand cmdCreateDataBase = new SqlCommand(string.Format("CREATE DATABASE [{0}]", "Database"), connection);
                    connection.Open();
                    Reporter?.SendReporter("Посылаем запрос");
                    cmdCreateDataBase.ExecuteNonQuery();
                    connection.Close();
                    Thread.Sleep(5000);
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
            }

            finally
            {
                Reporter?.SendReporter("Соединение успешно произведено");
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
