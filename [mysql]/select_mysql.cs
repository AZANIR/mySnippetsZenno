string server = "127.0.0.1";//ip сервера
string database = "db";//имя базы данных
int port = 3306;//номер порта
string user = "root";//имя пользователя базы данных
string password = "";//пароль пользователя базы данных
string charset = "utf8";//кодировка
string delimiterColumn = ";";//разделитель столбцов
string lineConn = String.Format("Server={0};Database={1};port={2};User={3};password={4};charset={5}", server, database, port, user, password, charset);// Формируем строку подключения
string ErrorMsg = "";//переменная для текста ошибки

string query = String.Format("SELECT * FROM data ORDER BY RAND() LIMIT 1");//строка запроса
string outLine = "";
string line = "";

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
		return ErrorMsg;
	}

	//объект для выполнения SQL-запроса
	using (MySqlCommand command = new MySqlCommand(query, connection))
	{
		try
		{
			//выполняем запрос и получаем ответ
			using (MySqlDataReader Reader = command.ExecuteReader())
			{
				//читаем ответ
				while (Reader.Read())   
				{
					//перебираем полученные поля
					for (int i = 0; i < Reader.FieldCount; i++)
					{   
						//составляем строку для добавления в таблицу, по количеству полей
						line = line + Reader[i].ToString() + delimiterColumn;
					}
					line = line.TrimEnd(delimiterColumn.ToCharArray()) + Environment.NewLine;    //обрезаем последний разделитель столбцов
				}
				line = line.TrimEnd('\r', '\n');;
			}
		}
		catch (MySqlException ex)
		{
			ErrorMsg = "Ошибка выполнения команды " + command.CommandText + ": " + ex.Message;
			return null;
		}
	}

	//закрываем соединение с БД
	connection.Close();
}

return line;