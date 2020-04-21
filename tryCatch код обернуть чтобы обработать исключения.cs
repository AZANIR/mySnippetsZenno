try{
//сюда помещаем наш код, в котором может случиться исключение

}
catch(Exception expr)
{

//имя переменной заменить на актуальное. То есть, вставляем ту переменную, значение которой может пригодиться для обработки ошибки
	project.SendErrorToLog(project.Variables["Count_steam_info"].Value +" Исключение при ...! " + expr.Message, true);
	if(null != expr.InnerException)
		project.SendErrorToLog(project.Variables["Count_steam_info"].Value +" Исключение при ... (внутреннее)! " + expr.InnerException.Message, true);
	Console.Beep(1100, 50); //частота, длительность
	Console.Beep(1000, 50); //frequency, length		
	return null;
}
