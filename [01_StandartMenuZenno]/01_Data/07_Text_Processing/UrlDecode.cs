//объявляем переменную, содержащую текст для кодирования
string strSource = "%d0%9f%d0%a0%d0%98%d0%92%d0%95%d0%a2";

//Macros.TextProcessing.UrlEncode: кодируем текст в UrlEncode
string strResult = Macros.TextProcessing.UrlDecode(strSource);

project.SendInfoToLog("Результат декодирования: " + strResult);

//Примечания
//1. Подробнее про Percent-encoding: https://en.wikipedia.org/wiki/Percent-encoding