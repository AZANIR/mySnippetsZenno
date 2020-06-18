//Объявляем таблицу, список и строковую переменную для размещения результатов
IZennoTable tblTest = project.Tables["Таблица 1"]; //таблица для размещения результата
tblTest.Clear(); //чистим таблицу
IZennoList lstTest = project.Lists["Список 1"]; //список для размещения результата
lstTest.Clear(); //чистим список
string strQueryResult = String.Empty; //строковая переменная для размещения результата

//Создаём переменную, содержащую строку подключения к БД
string strDBConnString = "Data source=gagarin8.beget.ru;UserId=admin25_testdb;Password=skladchik;database=admin25_testdb;Charset=utf8;";
//Создаём переменную, содержащую SQL-запрос
string strSQLQuery = "SELECT * FROM City WHERE id < 10;";

//ZennoPoster.Db.ExecuteQuery: выполняем запрос на выборку данных
int intTableRowCount = ZennoPoster.Db.ExecuteQuery(strSQLQuery, null, ZennoLab.InterfacesLibrary.Enums.Db.DbProvider.MySqlClient, strDBConnString, ref tblTest);
int intListRowCount = ZennoPoster.Db.ExecuteQuery(strSQLQuery, null, ZennoLab.InterfacesLibrary.Enums.Db.DbProvider.MySqlClient, strDBConnString, ref lstTest, " | ");
strQueryResult = ZennoPoster.Db.ExecuteQuery(strSQLQuery, null, ZennoLab.InterfacesLibrary.Enums.Db.DbProvider.MySqlClient, strDBConnString, " | ", Environment.NewLine);
project.Variables["test"].Value=strQueryResult;

project.SendInfoToLog(String.Format("Запрос выполнен. Результаты помещены в список ({0}) , в таблицу ({1}) и в переменную уровня проекта test", intListRowCount, intTableRowCount));

//Примечания:
//1. Документация по методу ZennoPoster.Db.ExecuteQuery находится здесь: https://help.zennolab.com/en/v5/zennoposter/5.9.8/topic451.html

//2. Параметры метода ZennoPoster.Db.ExecuteQuery (возврат данных в таблицу):
//	первый - Текст SQL-запроса;
//	второй - Параметры SQL-запроса (объект класса OrderedDictionary), либо null;
//	третий - Перечисление, обозначающее тип базы данных. Возможные варианты: "MySqlClient" (MySQL), "Odbc" (ODBC-подключение), "OleDb" (Microsoft OLEDB), "SqlClient" (Microsoft SQL Server);
//	четвёртый - строка подключения к базе данных;
//	пятый - таблица для помещения результатов запроса, передаваемая по ссылке (ref).

//3. Параметры метода ZennoPoster.Db.ExecuteQuery (возврат данных в список):
//	первый - Текст SQL-запроса;
//	второй - Параметры SQL-запроса (объект класса OrderedDictionary), либо null
//	третий - Перечисление, обозначающее тип базы данных. Возможные варианты: "MySqlClient" (MySQL), "Odbc" (ODBC-подключение), "OleDb" (Microsoft OLEDB), "SqlClient" (Microsoft SQL Server).
//	четвёртый - строка подключения к базе данных;
//	пятый - список для помещения результатов запроса, передаваемый по ссылке (ref);
//	шестой - строка, которая будет выступать разделителем отдельных полей (столбцов) в строках списка.

//4. Параметры метода ZennoPoster.Db.ExecuteQuery (возврат данных в строковую переменную):
//	первый - Текст SQL-запроса;
//	второй - Параметры SQL-запроса (объект класса OrderedDictionary), либо null;
//	третий - Перечисление, обозначающее тип базы данных. Возможные варианты: "MySqlClient" (MySQL), "Odbc" (ODBC-подключение), "OleDb" (Microsoft OLEDB), "SqlClient" (Microsoft SQL Server);
//	четвёртый - строка подключения к базе данных;
//	пятый - список для помещения результатов запроса, передаваемый по ссылке (ref);
//	шестой - строка, которая будет выступать разделителем отдельных полей (столбцов) в итоговой строке;
//	седьмой - строка, которая будет выступать разделителем отдельных записей (строк) в итоговой строке.

//5. Продемонстрировано только выполнение запроса без предварительной подготовки (параметров). Запрос с подготовкой параметров вы можете выполнить по аналогии с типом запроса "Без ответа"
//6. Для использования в проекте объектов класса OrderedDictionary необходимо прописать в OwnCodeUsings строку: using System.Collections.Specialized;