//Помещаем в переменную путь к файлу
string strFilePath = project.Directory + @"\Вспомогательные файлы\Тест копирования.txt";
//Помещаем в переменную путь к папке, в которую будет скопирован файл
string strTargetFolder = project.Directory + @"\Вспомогательные файлы\Тест\";

//Создадим файл, который затем будет скопирован
File.WriteAllText(strFilePath, "Этот файл будет скопирован");

//Проверяем существование файла перед копированием
if (!File.Exists(strFilePath)) {
	project.SendErrorToLog("Файл для копирования не найден: " + strFilePath);
	return null; //прерываем выполнение (выходим по красной ветке из сниппета)
}

//Проверяем существование папки назначения перед копированием
if (!Directory.Exists(strTargetFolder)) {
	project.SendErrorToLog("Папка назначения не найдена: " + strTargetFolder);
	return null; //прерываем выполнение (выходим по красной ветке из сниппета)
}

//File.Copy: копируем файл в папку strTargetFolder (с тем же именем)
File.Copy(strFilePath, strTargetFolder + new FileInfo(strFilePath).Name, true); 
//File.Copy: копируем файл в папку strTargetFolder (с переименованием)
File.Copy(strFilePath, strTargetFolder + "Новое имя файла.txt", true);
//Третий параметр указывает, перезаписывать ли файл, если он уже есть в месте назначения.
//Если параметр не указан или установлен в False и если такой же файл уже существует - произойдёт ошибка выполнения

project.SendInfoToLog("Готово! Проверьте результат в папке назначения: " + strTargetFolder);

//Примечания:
//1. Во время копирования имя файла также можно изменить, как и при перемещении