//объявляем переменную, содержащую исходную строку
string strSource = "ищем этот фрагмент";

//String.Substring: получаем подстроку
string strResult = strSource.Substring(5); //получаем подстроку начиная с 6 символа и до конца строки (0 - это первый символ)
strResult = strSource.Substring(5, 4); //получаем подстроку: 4 символа начиная с шестого (0 - это первый символ)

project.SendInfoToLog("Готово! Результат выполнения: " + strResult);