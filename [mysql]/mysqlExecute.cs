//http://zennolab.com/discussion/threads/zennoposter-kladez-bezgranichnyx-idej-i-vozmozhnostej-chast-1-js-mysql.19925/

var result = String.Empty;
var command = new MySql.Data.MySqlClient.MySqlCommand();
var connectionSTring = "server=mysql.myname.myjino.ru;user=lexone;database=lexone;port=3306;password=parol;";
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
    string request = "INSERT INTO vk1 (avatar, Data, group1, post) VALUES (@avatar, @Data, @group1, @post);";  \\ ищем в таблице vk1 столбцы, куда будем добавлять данные с лога.
 
    MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(request, command.Connection);
    string avatar = project.Variables["avatar"].Value;
    string Data = project.Variables["Data"].Value;
    string group1 = project.Variables["group1"].Value;
    string post = project.Variables["post"].Value;
 
       \\   ищем столбцы и добавляем в них данные из выше перечисленных переменных
 
    com.Parameters.AddWithValue("@avatar", avatar);
    com.Parameters.AddWithValue("@Data", Data);
    com.Parameters.AddWithValue("@group1", group1);
    com.Parameters.AddWithValue("@post", post);
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
