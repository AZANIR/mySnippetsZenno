string server = "127.0.0.1";//ip сервера
string database = "db";//имя базы данных
int port = 3306;//номер порта
string user = "root";//имя пользователя базы данных
string password = "";//пароль пользователя базы данных
string charset = "utf8";//кодировка
string delimiterColumn = ";";//разделитель столбцов
string lineConn = String.Format("Server={0};Database={1};port={2};User={3};password={4};charset={5}", server, database, port, user, password, charset);// Формируем строку подключения
string ErrorMsg = "";//переменная для текста ошибки

string query = String.Format("UPDATE data SET age = '{0}', country = '{1}' WHERE id = '{2}'", "28", "Беларусь", "3");//строка запроса

int Result = 0;

//объект для установления соединения с БД
using (MySqlConnection connection = new MySqlConnection(lineConn))
{
	//открываем соединение
	try
	{
		connection.Open();   //открываем соединение с БД
	}
	catch (MySqlException ex)
	{
		ErrorMsg = "Ошибка подключения к базе DB: " + ex.Message;
		return -1;
	}

	//объект для выполнения SQL-запроса
	using (MySqlCommand command = new MySqlCommand(query, connection))
	{
		//выполняем запрос
		try
		{
			Result = command.ExecuteNonQuery();   //отправляем запрос к БД
		}
		catch (MySqlException ex)
		{
			ErrorMsg = "Ошибка выполнения команды " + command.CommandText + ": " + ex.Message;
			return -1;
		}
	}

	//закрываем подключение к БД
	connection.Close();
}
return Result;