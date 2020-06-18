//Помещаем в переменную путь к файлу
string strFilePath = project.Directory + @"\Вспомогательные файлы\Тест перемещения.txt";
//Помещаем в переменную путь к папке, в которую будет перемещён файл
string strTargetFolder = project.Directory + @"\Вспомогательные файлы\Тест\";

//Создадим файл, который затем будет перемещён
File.WriteAllText(strFilePath, "Этот файл будет перемещён");

//Проверяем существование файла перед перемещением
if (!File.Exists(strFilePath)) {
	project.SendErrorToLog("Файл для перемещения не найден: " + strFilePath);
	return null; //прерываем выполнение (выходим по красной ветке из сниппета)
}

//Проверяем существование папки назначения перед перемещением
if (!Directory.Exists(strTargetFolder)) {
	project.SendErrorToLog("Папка назначения не найдена: " + strTargetFolder);
	return null; //прерываем выполнение (выходим по красной ветке из сниппета)
}

//File.Move: перемещаем файл в папку strTargetFolder (с тем же именем)
File.Move(strFilePath, strTargetFolder + new FileInfo(strFilePath).Name);
//File.Move: перемещаем файл в папку strTargetFolder (с переименованием)
//Закомментируйте первую строку File.Move перед тем как раскомментировать ту что ниже (иначе будет ошибка)
//File.Move(strFilePath, strTargetFolder + "Новое имя файла.txt");

project.SendInfoToLog("Готово! Проверьте результат в папке назначения: " + strTargetFolder);

//Примечания:
//1. Перемещения файла с заменой нет. Поэтому если в папке назначения уже есть файл с таким именем - возникнет ошибка.
//2. Команды File.Rename (для переименования файла) не существует. Если нужно переименовать файл - перемещайте его в ту же папку с изменением имени.