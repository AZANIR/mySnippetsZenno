//Присваиваем переменной путь к копируемой папке
string strSourceDirectoryPath = project.Directory + @"\Вспомогательные файлы\Папка для копирования\";
//Присваиваем переменной путь к папке назначения
string strTargetDirectoryPath = project.Directory + @"\Вспомогательные файлы\Скопированная папка\";

Directory.CreateDirectory(strSourceDirectoryPath); //создадим директорию, которая будет копироваться

//Команды копирования одной строкой (например Directory.Copy) не существует. Для копирования применяется такая конструкция:
if (!Directory.Exists(strTargetDirectoryPath)) {
	Directory.CreateDirectory(strTargetDirectoryPath);
}
foreach (string dirPath in Directory.GetDirectories(strSourceDirectoryPath, "*", SearchOption.AllDirectories)) {
    Directory.CreateDirectory(dirPath.Replace(strSourceDirectoryPath, strTargetDirectoryPath));
}
foreach (string newPath in Directory.GetFiles(strSourceDirectoryPath, "*.*", SearchOption.AllDirectories)) {
    File.Copy(newPath, newPath.Replace(strSourceDirectoryPath, strTargetDirectoryPath), true); //если заменять файлы при копировании не нужно, укажите false
}

project.SendInfoToLog("Готово! Проверьте содержимое папки назначения " + strTargetDirectoryPath);

//Примечания:
//1. Если необходимо скопировать только содержимое исходной папки, но не вложенные папки и их содержимое, используйте SearchOption.TopDirectoryOnly вместо SearchOption.AllDirectories