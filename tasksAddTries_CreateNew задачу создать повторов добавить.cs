//http://zennolab.com/discussion/threads/ehkshny-kubiki-potokov-i-kolichestva-vypolnenij.23257/
//Для добавления попыток можно использовать такой код
 
var id = Guid.Parse(project.TaskId);
var taskInfo = ZennoPoster.GetTaskInfo(id);
ZennoPoster.SetTries(id, 2);

//Для добавления потоков, по идее должен работать такой код
 
var id = Guid.Parse(project.TaskId);
var taskInfo = ZennoPoster.GetTaskInfo(id);
var doc = new System.Xml.XmlDocument();
doc.LoadXml("<Task>" + taskInfo + "</Task>");
var executionSettings = doc.SelectSingleNode("Task/ExecutionSettings");
var limitOfThreads = executionSettings.SelectSingleNode("LimitOfThreads");
limitOfThreads.InnerText = "2";
ZennoPoster.SetExecutionSettings(id, executionSettings.ToString());
 

//Но у меня он работать отказывается, возможно у меня ошибка, возможно баг в зенно, 
//т.к. даже если формировать xml полностью руками как указано тут
// https://help.zennolab.com/en/v5/zen...Poster~SetExecutionSettings(Guid,String).html,
//Никаких изменений с проектом не происходит. 