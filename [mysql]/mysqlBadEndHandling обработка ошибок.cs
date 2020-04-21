//http://zennolab.com/discussion/threads/zennoposter-kladez-bezgranichnyx-idej-i-vozmozhnostej-chast-1-js-mysql.19925/

var result = String.Empty;
var command = new MySql.Data.MySqlClient.MySqlCommand();
var connectionSTring = "server=mysql..myjino.ru;user=;database=;port=3306;password=;";
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
string request = "UPDATE projects SET active  = '1' WHERE id = '"+
    project.Variables["id"].Value+
    "' ";
MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(request, command.Connection);
com.ExecuteNonQuery();
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