//объявляем переменную, содержащую текст для обработки
string strSource = "   \t<bla>Эта строчка для проверки команд Trim.....    ";
string strResult = String.Empty; //Объявляем переменную, в которую будет помещён результат

//String.Trim: обрезаем пробелы с обеих сторон строки
strResult = strSource.Trim();
project.SendInfoToLog("Результат выполнения String.Trim: " + strResult);

//String.Trim: обрезаем пробелы только в начале строки
strResult = strSource.TrimStart(' ');
project.SendInfoToLog("Результат выполнения String.TrimStart: " + strResult);

//String.Trim: обрезаем пробелы только в конце строки
strResult = strSource.TrimEnd(' ');
project.SendInfoToLog("Результат выполнения String.TrimEnd: " + strResult);

//обрезаем определённые символы (с обеих сторон)
string strSymbolsForTrimming = "\n\t. "; //набор символов (по одному, без разделителей)
char[] arrChars = strSymbolsForTrimming.ToCharArray();
strResult = strSource.TrimStart(arrChars).TrimEnd(arrChars);
project.SendInfoToLog("Результат выполнения обрезки по собственному набору символов: " + strResult);