//http://zennolab.com/discussion/threads/ehmuljacija-zheleza.25791/#post-179248
//очень удобно пользоваться, не нужны никакие списки или генерация древнейших Агентов Зенки. Но данный код //генерирует только UA Mozilla Firefox. Хотя, в большинстве случаев этого вполне достаточно.

//Добавил Windows 10 + обновил генерируемые версии Мозиллы (v30-44)

var rnd = new Random();
//ID сборки
var dt = new DateTime(2000 + rnd.Next(13,15), rnd.Next(1,13), rnd.Next(1,29), rnd.Next(0,24), rnd.Next(0,31), rnd.Next(0,31));
string buildID = dt.ToString("yyyyMMddHHmmss");
// Версия винды
string [] os = {"5", "6", "7", "8", "10"};
string oscpu = String.Format("Windows NT {0}.{1}", os[rnd.Next(0,5)], rnd.Next(0,2));
string [] osarr = {"; WOW64", "; Win64", ""};
oscpu += osarr[rnd.Next(0,3)];
// Версия браузера
string version = String.Format("{0}.{1}", rnd.Next(30,45).ToString(), rnd.Next(0,2).ToString());
string UserAgent = String.Format("Mozilla/5.0 ({0}; rv:{1}) Gecko/20100101 Firefox/{1}", oscpu, version);
 
instance.SetHeader(ZennoLab.InterfacesLibrary.Enums.Browser.NavigatorField.BuildId, buildID);
project.Profile.UserAgentOsCpu = oscpu;
project.Profile.UserAgent = UserAgent;
 
return UserAgent;
