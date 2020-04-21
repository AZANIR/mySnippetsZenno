//http://zennolab.com/discussion/threads/vzjat-imja-vypolnjaemogo-shablona.9838/

// reading task name from the variable
var searchName = project.Variables["taskName"].Value;
var searchResult = false;
 
 
// get the task list from the ZennoPoster
var tasks = ZennoPoster.TasksList;
foreach (var tsk in tasks)
{
    // loading Xml documnt with task content
    var doc = new System.Xml.XmlDocument();
    doc.LoadXml("<Task>" + tsk + "</Task>");
 
 
    // Search task by name
    var nameElement = doc.SelectSingleNode("Task/Name");
    if(nameElement == null) continue;
    var name = nameElement.InnerText;
    // if we found our task
    if (name == searchName)
    {
        // take task id
        var idElement = doc.SelectSingleNode("Task/Id");
        if (idElement == null) continue;
        var id = Guid.Parse(idElement.InnerText);
 
 
        // take execution settings element
        var esElement = doc.SelectSingleNode("Task/ExecutionSettings");
        if (esElement == null) continue;
 
 
        // take limit of threads of the task
        var threadsElement = doc.SelectSingleNode("Task/ExecutionSettings/LimitOfThreads");
        if (threadsElement == null) continue;
       
        // change the value
        threadsElement.InnerText = "100";
 
 
        // set new settings
        ZennoPoster.SetExecutionSettings(id, esElement.InnerXml);
       
        searchResult = true;
        break;
    }
}
if (!searchResult)
    throw new Exception("Task " + searchName + " not found!");
	