//Присваиваем переменной путь к папке с файлами
string strSourceDirectoryPath = project.Directory + @"\Вспомогательные файлы\Папка для получения перечня файлов\";
Directory.CreateDirectory(strSourceDirectoryPath); //создадим директорию, перечень файлов из которой будем получать
//создадим несколько файлов в этой директории
File.WriteAllText(strSourceDirectoryPath + "Файл 1.txt", "Это файл №1");
File.WriteAllText(strSourceDirectoryPath + "Файл 2.txt", "Это файл №1");
File.WriteAllText(strSourceDirectoryPath + "Файл 3.txt", "Это файл №1");
//Созданим объект списка, связанный со списком уровня проекта "Список 1", очистим этот список
IZennoList lstTest = project.Lists["Список 1"];
lstTest.Clear();

//Directory.EnumerateFiles: получаем список файлов
lstTest.AddRange(Directory.EnumerateFiles(strSourceDirectoryPath, "*.txt", SearchOption.AllDirectories));

project.SendInfoToLog("Готово! Проверьте содержимое списка Список 1");

//Примечания:
//1. Если нужно получить все файлы, используйте вместо "*.txt" маску "*"
//2. Если необходимо получить файлы только из исходной папки, но не из вложенных папок, используйте SearchOption.TopDirectoryOnly вместо SearchOption.AllDirectories