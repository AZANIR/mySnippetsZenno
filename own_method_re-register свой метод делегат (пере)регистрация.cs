//http://zennolab.com/discussion/threads/neponjatki-s-kontekstom.19667/
//define a function

//вызываем функцию через контекст  - пример вызова
//project.SendInfoToLog("Вызываем MyMethod", false);
//return project.Context["MyMethod"]();


if((null != project.Context["MyMethod"]))
{
	project.SendInfoToLog(project.Variables["Count_stream_info"].Value +" Проводится разрегистрация функции сброса переменных...", false);
	project.Context["MyMethod"] = null;
}


if((null == project.Context["MyMethod"]))
{
	project.SendInfoToLog(project.Variables["Count_stream_info"].Value +" Проводится регистрация функции сброса переменных...", false);

	project.Context["MyMethod"] = (Func<string>)(() => 
	{
		//операции внутри метода, вставляйте свой код сюда:
		
		return "OK";
	});
}
