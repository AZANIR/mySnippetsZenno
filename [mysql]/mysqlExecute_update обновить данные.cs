// блокируем выполнение, чтобы другие потоки не испортили
 
lock(SyncObject)
{
 
   var result = String.Empty;
   var command = new MySql.Data.MySqlClient.MySqlCommand();
   command.CommandText = "SELECT * FROM projects WHERE active=1 LIMIT 1 ;";
   var connectionSTring = "server=mysql.test.myjino.ru;user=test;database=test;port=3306;password=test;";
 
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
        project.Variables["id"].Value = read["id"].ToString();
        project.Variables["acc"].Value = read["acc"].ToString();
        project.Variables["image"].Value = read["img"].ToString();
        project.Variables["title"].Value = read["header"].ToString();
        project.Variables["col_vo"].Value = read["max"].ToString();
        project.Variables["count"].Value = read["done"].ToString();
        project.Variables["pause"].Value = read["pause"].ToString();
    }
}
catch (MySql.Data.MySqlClient.MySqlException e)
{
    result = "Mysql ошибка "+e.Message;
}
try
{
    command.Connection.Close();
    command.Connection.Open();
    var request = "UPDATE projects SET active = 0 WHERE id="+Convert.ToInt32(project.Variables["id"].Value)+";";
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
 
}
