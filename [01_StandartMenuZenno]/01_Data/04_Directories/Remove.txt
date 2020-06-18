//Присваиваем переменной путь к перемещаемой папке
string strSourceDirectoryPath = project.Directory + @"\Вспомогательные файлы\Папка для перемещения\";
//Присваиваем переменной путь к перемещённой папке
string strTargetDirectoryPath = project.Directory + @"\Вспомогательные файлы\Перемещённая папка\";

Directory.CreateDirectory(strSourceDirectoryPath); //создадим директорию, которая будет перемещаться

//Directory.Move: перемещаем директорию
Directory.Move(strSourceDirectoryPath, strTargetDirectoryPath);

project.SendInfoToLog("Готово! Проверьте существование папки назначения " + strTargetDirectoryPath);

//Примечания:
//1. Если папка назначения уже существует, возникнет ошибка;
//2. Папка перемещается вместе со всеми содержащимися в ней подпапками и файлами
//3. Команды для переименования папок (например, Directory.Rename) не существует. Вместо этого используйте команду Move с указанием нового пути (с новым именем папки)