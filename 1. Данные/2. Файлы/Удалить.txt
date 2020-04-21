//Помещаем в переменную путь к файлу
string strFilePath = project.Directory + @"\Вспомогательные файлы\Тест удаления.txt";

//Создадим файл, который затем будет удалён
File.WriteAllText(strFilePath, "Этот файл будет удалён");

//Проверяем существование файла перед удалением
if (!File.Exists(strFilePath)) {
	project.SendErrorToLog("Файл для удаления не найден: " + strFilePath);
	return null; //прерываем выполнение (выходим по красной ветке из сниппета)
}

//File.Delete: удаляем файл
File.Delete(strFilePath);

project.SendInfoToLog("Готово! Файл удалён: " + strFilePath);

//Примечания:
//Если удаляемый файл не существует в системе - возникнет ошибка "Ссылка на объект не указывает на экземпляр объекта".