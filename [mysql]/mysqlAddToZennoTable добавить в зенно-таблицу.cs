//http://zennolab.com/discussion/threads/zennoposter-kladez-bezgranichnyx-idej-i-vozmozhnostej-chast-1-js-mysql.19925/

var result = String.Empty;
var table = project.Tables["Data"];
var command = new MySql.Data.MySqlClient.MySqlCommand();
command.CommandText = "SELECT * FROM projects WHERE active=0;";  \\ Команда на поиск аккаунтов, где в таблице "projects" ищем аккаунты , в которых есть "0" в столбце "active"
var connectionSTring = "server=mysql.blablabla.myjino.ru;user=pashalka;database=win/no;port=3306;password=12345;";  \\ Авторизация
 
try
{
    command.Connection = new MySql.Data.MySqlClient.MySqlConnection(connectionSTring);
}
catch (Exception e)
{
    result = "Mysql ошибка подключения";
}
if (result!=String.Empty)
{
    return result;
}
try
{
    command.Connection.Open();
    var read = command.ExecuteReader();
    while (read.Read())
    {
        table.AddRow(
        read["acc"].ToString()+"\t");  \\ экспортируем полученные данные в таблицу "acc"
    }
}
catch (MySql.Data.MySqlClient.MySqlException e)
{
    result = "Mysql ошибка "+e.Message;
}
finally
{
    command.Connection.Close();
}
return result;    