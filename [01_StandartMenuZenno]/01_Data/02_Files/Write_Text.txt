//Присваиваем переменной путь к файлу
string strFilePath = project.Directory + @"\Вспомогательные файлы\Текст 2.txt";

//WriteAllText: записываем содержимое переменной в файл (предыдущее содержимое файла ЗАТИРАЕТСЯ)
File.WriteAllText(strFilePath, "Привет", System.Text.Encoding.UTF8); //Третий параметр - кодировка. Если не указан, по умолчанию будет UTF-8

//AppendAllText: записываем содержимое переменной в файл (предыдущее содержимое сохраняется)
File.AppendAllText(strFilePath, "Второй привет");

//В файле на этот момент находится текст: "ПриветВторой привет". Чтобы текст дописывался с новой строки - используем Environment.NewLine
File.AppendAllText(strFilePath, "Третий привет" + Environment.NewLine + "Четвёртый привет"); //с новой строки будет записано: "Четвёртый привет"

project.SendInfoToLog("Готово! Проверьте содержимое файла " + strFilePath);