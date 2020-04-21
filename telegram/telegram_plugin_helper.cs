/*
Для тех кто не шарит в коде ничего не меняйте тут 
Те кто шарят смогут более гибко настроить сам текст для вашего сообщения
*/

//формируем текст с данными для отправки
var action_errors = "";
if(project.GetLastError() != null) action_errors = string.Format("<b>Projectname: {0}</b>\r\n <i>ActionComment: {1}.</i>\r\nActionGroupId: {2}.\r\n%E2%81%89 ActionId: <pre>{3}</pre> %E2%81%89\r\n", project.Name, project.GetLastError().ActionComment, project.GetLastError().ActionGroupId, project.GetLastError().ActionId);
//создаем директорию для скриншотов с ошибкой
if (!System.IO.Directory.Exists(project.Path +"error\\"))
	System.IO.Directory.CreateDirectory(project.Path + "error\\");
//делаем скриншот //@"\error\" + 
try{System.IO.File.WriteAllBytes(project.Path + "error\\" + project.GetLastError().ActionId + ".jpg", Convert.FromBase64String(instance.ActiveTab.FindElementByTag("html", 0).DrawToBitmap(false)));
}catch{project.SendWarningToLog("Нет инстанса для создания скриншота", true);}
//передаем плагину Айди Ошибки
project.Context["Action_Id"] = project.GetLastError().ActionId;
//передаем плагину текст для отправки
project.Context["action_errors"] = action_errors;