//Присваиваем переменной путь к файлу
string strFilePath = project.Directory + @"\Вспомогательные файлы\Текст.txt";

//ReadAllText: читаем все строки файла в одну строковую переменную
string strFileText = File.ReadAllText(strFilePath);
project.SendInfoToLog("Результат выполнения ReadAllText: " + strFileText);

//ReadAllLines: читаем все строки файла в строковой массив
string[] arrFileText = File.ReadAllLines(strFilePath);
//Перебираем все строки файла из массива, полученного с помощью ReadAllText
for (int i=0; i<arrFileText.Length;i++) {
	string strFileLine = arrFileText[i];
	project.SendInfoToLog(String.Format("Строка файла номер {0}: {1}", i, strFileLine));
}

//Примечания:
//1. Если в файле содержится кириллица, кодировка файла должна быть "UTF-8"