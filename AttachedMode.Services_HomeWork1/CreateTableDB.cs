using AttachedMode.Services.Abstract_HomeWork1;
using System.Data;
using System.Data.SqlClient;

namespace AttachedMode.Services_HomeWork1
{
    public class CreateTableDB
    {
        public IReporter Reporter { get; set; }

        string connectionString = @"Data Source=(local)\SQLEXPRESS; Initial Catalog=Database; Integrated Security=True";
        public void CreateTable()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException exeption)
            {
                Reporter?.SendReporter($"Ошибка подключения:\n {exeption.Message}");
                return;
            }

            SqlCommand command = new SqlCommand("CREATE TABLE Gruppa (Id int not null primary key identity, Name char(60) not null)", connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Reporter?.SendReporter("Ошибка при создании таблицы");
                return;
            }

            Reporter?.SendReporter("Таблица создана успешно\n");

            command = new SqlCommand("Select * from Gruppa", connection);

            using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Reporter?.SendReporter("", $"{dataReader.GetName(i).ToString().Trim()}\t");
                }
            }

                connection.Close();
            connection.Dispose();
        }
    }
}
