//Присваиваем переменной путь к удаляемой папке
string strDirectoryPath = project.Directory + @"\Вспомогательные файлы\Папка для удаления\";
//создаём папку, которая будет удалена
Directory.CreateDirectory(strDirectoryPath);

//Directory.Delete: удаляем папку
Directory.Delete(strDirectoryPath);

project.SendInfoToLog("Готово! Проверьте папка удалена: " + strDirectoryPath);

//Примечания:
//1. Если удаляемая директория не существует в системе - возникнет ошибка.