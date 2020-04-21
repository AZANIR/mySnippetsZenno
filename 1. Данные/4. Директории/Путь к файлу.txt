//Присваиваем переменной путь к папке с файлами
string strSourceDirectoryPath = project.Directory + @"\Вспомогательные файлы\Папка для получения одного файла\";
Directory.CreateDirectory(strSourceDirectoryPath); //создадим директорию, перечень файлов из которой будем получать
//создадим несколько файлов в этой директории
File.WriteAllText(strSourceDirectoryPath + "Файл 1.txt", "Это файл №1");
File.WriteAllText(strSourceDirectoryPath + "Файл 2.txt", "Это файл №1");
File.WriteAllText(strSourceDirectoryPath + "Файл 3.txt", "Это файл №1");

//Отдельной команды для получения единичного файла из папки нет. Ниже приведена возможная реализация данного функционала.
List<string> lstTemp = new List<string>(); //Создадим временный список
string strResultFileName = String.Empty; //Объявим переменную, в которую будет помещён путь к файлу
lstTemp.AddRange(Directory.GetFiles(strSourceDirectoryPath, "*.txt", SearchOption.AllDirectories)); //используйте SearchOption.TopDirectoryOnly если не нужно искать в поддиректориях
lstTemp.Sort(); //Сортируем список файлов по алфавиту
strResultFileName = lstTemp[0]; //Получаем файл по номеру. 0 - это первый файл в папке
//Чтобы получить случайный файл
lstTemp.Shuffle(); //Перемешиваем список файлов (если нужно получить случайный файл)
strResultFileName = lstTemp[0];

project.SendInfoToLog("Получено имя файла: " + strResultFileName);

//Примечания:
//1. Если нужно получить файлы с любыми расширениями, используйте вместо "*.txt" маску "*"