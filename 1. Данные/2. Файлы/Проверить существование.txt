//Помещаем в переменную путь к файлу
string strFilePath = project.Directory + @"\Вспомогательные файлы\Текст.txt";

project.SendInfoToLog("Файл существует? " + File.Exists(strFilePath)); //True если файл существует, и False, если нет

//File.Exists: проверяем существование файла с применением конструкции if-else:
if (File.Exists(strFilePath)) {
	//Этот код выполнится, если файл существует
	project.SendInfoToLog("Ура! Файл на месте! " + strFilePath);
}else{
	//Этот код выполнится, если файл не существует
	project.SendInfoToLog("Такого файла в системе нет: " + strFilePath);
}