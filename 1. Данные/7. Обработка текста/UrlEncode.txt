//объявляем переменную, содержащую текст для кодирования
string strSource = "ПРИВЕТ";

//Macros.TextProcessing.UrlEncode: кодируем текст в UrlEncode
string strResult = Macros.TextProcessing.UrlEncode(strSource);

project.SendInfoToLog("Результат кодирования: " + strResult);

//Примечания
//1. Подробнее про Percent-encoding: https://en.wikipedia.org/wiki/Percent-encoding