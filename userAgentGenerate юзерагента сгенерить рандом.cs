//http://zennolab.com/discussion/threads/ehmuljacija-zheleza.25791/#post-179248
//����� ������ ������������, �� ����� ������� ������ ��� ��������� ���������� ������� �����. �� ������ ��� //���������� ������ UA Mozilla Firefox. ����, � ����������� ������� ����� ������ ����������.

//������� Windows 10 + ������� ������������ ������ ������� (v30-44)

var rnd = new Random();
//ID ������
var dt = new DateTime(2000 + rnd.Next(13,15), rnd.Next(1,13), rnd.Next(1,29), rnd.Next(0,24), rnd.Next(0,31), rnd.Next(0,31));
string buildID = dt.ToString("yyyyMMddHHmmss");
// ������ �����
string [] os = {"5", "6", "7", "8", "10"};
string oscpu = String.Format("Windows NT {0}.{1}", os[rnd.Next(0,5)], rnd.Next(0,2));
string [] osarr = {"; WOW64", "; Win64", ""};
oscpu += osarr[rnd.Next(0,3)];
// ������ ��������
string version = String.Format("{0}.{1}", rnd.Next(30,45).ToString(), rnd.Next(0,2).ToString());
string UserAgent = String.Format("Mozilla/5.0 ({0}; rv:{1}) Gecko/20100101 Firefox/{1}", oscpu, version);
 
instance.SetHeader(ZennoLab.InterfacesLibrary.Enums.Browser.NavigatorField.BuildId, buildID);
project.Profile.UserAgentOsCpu = oscpu;
project.Profile.UserAgent = UserAgent;
 
return UserAgent;
