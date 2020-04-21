//Второй способ:
project.Profile.Save(project.Directory + @"\Вспомогательные файлы\profile.zpprofile", true, true, true); //сохраняем профиль в файл D:\profile.zpprofile
//расширение файла обязательно должно быть .zpprofile, иначе .zpprofile будет добавлено автоматически
//второй параметр (bool saveProxy) - сохранять ли в файле информацию о прокси
//третий параметр (bool savePlugins) - сохранять ли в файле информацию о плагинах браузера
//четвёртый параметр (bool saveLocalStorage) - сохранять ли в файле информацию локального хранилища