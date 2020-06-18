//объявляем переменную, содержащую текст для обработки
string strSource = "Это строка для транслитерации";

string strResult = Macros.TextProcessing.Translit(strSource);

project.SendInfoToLog("Результат транслитерации: " + strResult);