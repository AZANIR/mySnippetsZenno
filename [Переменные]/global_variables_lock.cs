/*задача Залочить между разными шаблонами работу с одним списком/файлом, 
не мешая работе других шаблонов или этих же, но с другими списками/файлами.*/

//Это создаётся в начале проекта:
var syncObject = project.GlobalVariables["test_namespace","my_sync_object"].Value;

lock (project.GlobalVariables)
{
  // check if exists
  try {
    var syncobj = project.GlobalVariables["test_namespace","my_sync_object"];
    return syncobj.ToString();
  } catch (KeyNotFoundException ex) {
    // create sync object
    object syncobj = new Object();
    project.GlobalVariables.SetVariable("test_namespace","my_sync_object", syncobj);
  }
}