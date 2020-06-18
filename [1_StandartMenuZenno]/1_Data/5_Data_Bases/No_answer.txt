//Демонстрация выполнения запроса без предварительной подготовки (параметров):
//Создаём переменную, содержащую строку подключения к БД
string strDBConnString = "Data source=gagarin8.beget.ru;UserId=admin25_testdb;Password=skladchik;database=admin25_testdb;Charset=utf8;";
//Создаём переменную, содержащую SQL-запрос
string strSQLQuery = "UPDATE City SET District='privet' WHERE id<10;";
//ZennoPoster.Db.ExecuteNonQuery: выполняем запрос, не возвращающий записей
int intAffectedRows = ZennoPoster.Db.ExecuteNonQuery(strSQLQuery, null, ZennoLab.InterfacesLibrary.Enums.Db.DbProvider.MySqlClient, strDBConnString);

//Демонстрация выполнения запроса с предварительной подготовкой (параметров):
OrderedDictionary odParams = new OrderedDictionary();
odParams.Add("supervalue", "Привет, запятая!");
odParams.Add("supervalue2", "12345");

string strSQLQuery2 = "UPDATE City SET District=@supervalue, Population=@supervalue2 WHERE id=1;";
//ZennoPoster.Db.ExecuteNonQuery: выполняем запрос, не возвращающий записей
int intAffectedRows2 = ZennoPoster.Db.ExecuteNonQuery(strSQLQuery2, odParams, ZennoLab.InterfacesLibrary.Enums.Db.DbProvider.MySqlClient, strDBConnString);

project.SendInfoToLog("Запрос выполнен. Изменено строк в таблице: " + intAffectedRows + " и " + intAffectedRows2);

//Примечания:
//1. Документация по методу ZennoPoster.Db.ExecuteNonQuery находится здесь: https://help.zennolab.com/en/v5/zennoposter/5.9.8/topic450.html

//2. Параметры метода ZennoPoster.Db.ExecuteNonQuery:
//	первый - Текст SQL-запроса;
//	второй - Параметры SQL-запроса (объект класса OrderedDictionary), либо null
//	третий - Перечисление, обозначающее тип базы данных. Возможные варианты: "MySqlClient" (MySQL), "Odbc" (ODBC-подключение), "OleDb" (Microsoft OLEDB), "SqlClient" (Microsoft SQL Server).
//	четвёртый - строка подключения к базе данных.

//3. Для использования в проекте объектов класса OrderedDictionary необходимо прописать в OwnCodeUsings строку: using System.Collections.Specialized;