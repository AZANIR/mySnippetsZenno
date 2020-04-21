//тут много разного - всё ненужное удаляйте

//из Unix Time в обычное время

string unixTimeStamp = project.Variables["bd_now_unixtime"].Value;
var unixTimeStampd = double.Parse(unixTimeStamp);
System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
dtDateTime = dtDateTime.AddSeconds(unixTimeStampd).ToLocalTime();
return dtDateTime.ToString("dd.MM.yyyy hh:mm:ss");


//Простой способ получить Unix Time в C#

int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

//Простой способ получить DateTime из UnixTime в C#

DateTime pDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(timestamp);

//Функция конвертирования Unix Timestamp в DateTime

static DateTime ConvertFromUnixTimestamp(double timestamp)
{
    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
    return origin.AddSeconds(timestamp);
}

//Функция обратного конвертирования DateTime в Unix Timestamp

static double ConvertToUnixTimestamp(DateTime date)
{
    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
    TimeSpan diff = date - origin;
    return Math.Floor(diff.TotalSeconds);
}

//time to UnixTime
int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
return unixTime;
