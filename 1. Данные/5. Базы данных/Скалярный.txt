//Демонстрация выполнения запроса без предварительной подготовки (параметров). Запрос с подготовкой параметров вы можете выполнить по аналогии с типом запроса "Без ответа"
//Создаём переменную, содержащую строку подключения к БД
string strDBConnString = "Data source=gagarin8.beget.ru;UserId=admin25_testdb;Password=skladchik;database=admin25_testdb;Charset=utf8;";
//Создаём переменную, содержащую SQL-запрос
string strSQLQuery = "SELECT COUNT(*) FROM City;"; //SELECT id FROM City WHERE NAME='Kabul';
//ZennoPoster.Db.ExecuteScalar: получаем единственный результат выполнения запроса
string strQueryResult = ZennoPoster.Db.ExecuteScalar(strSQLQuery, null, ZennoLab.InterfacesLibrary.Enums.Db.DbProvider.MySqlClient, strDBConnString);

project.SendInfoToLog("Запрос выполнен. Результат выполнения: " + strQueryResult);

//Примечания:
//1. Документация по методу ZennoPoster.Db.ExecuteScalar находится здесь: https://help.zennolab.com/en/v5/zennoposter/5.9.8/topic455.html

//2. Параметры метода ZennoPoster.Db.ExecuteScalar:
//	первый - Текст SQL-запроса;
//	второй - Параметры SQL-запроса (объект класса OrderedDictionary), либо null
//	третий - Перечисление, обозначающее тип базы данных. Возможные варианты: "MySqlClient" (MySQL), "Odbc" (ODBC-подключение), "OleDb" (Microsoft OLEDB), "SqlClient" (Microsoft SQL Server).
//	четвёртый - строка подключения к базе данных.

//3. Для использования в проекте объектов класса OrderedDictionary необходимо прописать в OwnCodeUsings строку: using System.Collections.Specialized;