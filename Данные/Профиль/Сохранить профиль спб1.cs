//Первый способ:
string strProfile = project.Profile.ToString(); //преобразовываем профиль в строку
File.WriteAllText(project.Directory + @"\Вспомогательные файлы\profile.txt", strProfile); //сохраняем профиль в файл D:\profile.txt
