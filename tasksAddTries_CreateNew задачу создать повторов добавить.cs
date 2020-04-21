//http://zennolab.com/discussion/threads/ehkshny-kubiki-potokov-i-kolichestva-vypolnenij.23257/
//��� ���������� ������� ����� ������������ ����� ���
 
var id = Guid.Parse(project.TaskId);
var taskInfo = ZennoPoster.GetTaskInfo(id);
ZennoPoster.SetTries(id, 2);

//��� ���������� �������, �� ���� ������ �������� ����� ���
 
var id = Guid.Parse(project.TaskId);
var taskInfo = ZennoPoster.GetTaskInfo(id);
var doc = new System.Xml.XmlDocument();
doc.LoadXml("<Task>" + taskInfo + "</Task>");
var executionSettings = doc.SelectSingleNode("Task/ExecutionSettings");
var limitOfThreads = executionSettings.SelectSingleNode("LimitOfThreads");
limitOfThreads.InnerText = "2";
ZennoPoster.SetExecutionSettings(id, executionSettings.ToString());
 

//�� � ���� �� �������� ������������, �������� � ���� ������, �������� ��� � �����, 
//�.�. ���� ���� ����������� xml ��������� ������ ��� ������� ���
// https://help.zennolab.com/en/v5/zen...Poster~SetExecutionSettings(Guid,String).html,
//������� ��������� � �������� �� ����������. 