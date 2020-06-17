string server = "127.0.0.1";//ip сервера
string database = "db";//имя базы данных
int port = 3306;//номер порта
string user = "root";//имя пользователя базы данных
string password = "";//пароль пользователя базы данных
string charset = "utf8";//кодировка
string delimiterColumn = ";";//разделитель столбцов
string lineConn = String.Format("Server={0};Database={1};port={2};User={3};password={4};charset={5}", server, database, port, user, password, charset);// Формируем строку подключения
string ErrorMsg = "";//переменная для текста ошибки

string lastName = "Смычковская";
string firstName = "Валентина";
string surName = "Ивановна";
int age = 25;
string country = "Беларусь";
string nickName = "smychok";
string dateBirth = "1996-02-05";
string webSite = "smychok.net";
string eMail = "lady@smychok.net";
string proxy = "85.45.96.25:4569";
string status = "free";
string query = String.Format("INSERT INTO `data`(`lastname`, `firstname`, `surname`, `age`, `country`, `nickname`, `datebith`, `web-site`, `email`, `proxy`, `statuse`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", lastName, firstName, surName, age, country, nickName, dateBirth, webSite, eMail, proxy, status);//строка запроса


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
		project.SendInfoToLog(ErrorMsg);
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
			project.SendInfoToLog(ErrorMsg);
			return -1;
		}
	}

	//закрываем подключение к БД
	connection.Close();
}
return Result;