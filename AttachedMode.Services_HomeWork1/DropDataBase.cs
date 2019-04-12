using AttachedMode.Services.Abstract_HomeWork1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachedMode.Services_HomeWork1
{
    public class DropDataBase
    {
        IReporter Reporter { get; set; }
        public DropDataBase()
        {
            Reporter = new ConsoleReporter();
        }
        string connectionString = @"Data Source=(local)\SQLEXPRESS; Initial Catalog=Database; Integrated Security=True";
        public void Drop()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException exeption)
            {
                Reporter?.SendReporter("Ошибка подключения:{0}", exeption.Message);
                return;
            }

            SqlCommand command = new SqlCommand("Drop Table Gruppa", connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exeption)
            {

                Reporter?.SendReporter("Ошибка при удалении таблицы");
                return;
            }
            Reporter?.SendReporter("Таблица удалена успешно");
        }
    }
}
