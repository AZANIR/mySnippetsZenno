//Первый способ:
string strProfile = File.ReadAllText(project.Directory + @"\Вспомогательные файлы\profile.txt"); //загружаем данные профиля из файла
project.Profile.FromString (strProfile); //Устанавливаем данные профиля из строковой переменной
//Метод только для загрузки профиля из файла с текстом, полученным при помощи
//метода Profile.ToString.