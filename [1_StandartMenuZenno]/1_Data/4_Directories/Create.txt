//Присваиваем переменной путь к создаваемой папке
string strDirectoryPath = project.Directory + @"\Вспомогательные файлы\Созданная папка\";

//Directory.CreateDirectory: создаём новую папку
Directory.CreateDirectory(strDirectoryPath);

project.SendInfoToLog("Готово! Проверьте существование папки " + strDirectoryPath);

//Примечания:
//1. Даже если создаваемая папка уже существует в системе, ошибка не возникнет