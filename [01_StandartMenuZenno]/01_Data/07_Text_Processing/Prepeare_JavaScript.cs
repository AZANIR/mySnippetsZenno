//объявляем переменную, содержащую текст для обработки
string strSource = @"Это ""строка' \для' экр@нирования' для использования в JavaScript";
project.SendInfoToLog("Исходная строка для подготовки: " + strSource);

StringBuilder sbJavaPrepare = new StringBuilder();
char[] arrPrepDictionary = new Char[] {'\'', '\"', '\\', '\b', '\f', '\n', '\r', '\t'}; //символы, которые будут экранироваться
foreach (char chrCurrentSymbol in strSource)
{
    if (arrPrepDictionary.Contains(chrCurrentSymbol)) {
		sbJavaPrepare.Append(@"\" + chrCurrentSymbol);
	}else{
		sbJavaPrepare.Append(chrCurrentSymbol);
	}
}
string strResult = sbJavaPrepare.ToString();

project.SendInfoToLog("Результат подготовки: " + strResult);

//Примечания
//1. В ASP.NET 4.0 есть специально предназначенный для данной цели метод HttpUtility.JavaScriptStringEncode, однако он требует подключения к проекту дополнительных библиотек