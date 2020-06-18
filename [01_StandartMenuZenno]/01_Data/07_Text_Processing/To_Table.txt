//объявляем переменную, содержимое которой будет разложено по таблице
string strTest = "Значение_1 Значение_2$Значение_3 Значение_4" + Environment.NewLine + "Значение_5 Значение_6$Значение_7 Значение_8";

//создаём объект таблицы, связанный с таблицей уровня проекта
IZennoTable tblTest = project.Tables["Таблица 1"];
tblTest.Clear(); //чистим таблицу

//Добавляем отдельную строку в таблицу
tblTest.AddRow(strTest);

//Используем произвольные разделители строк и столбцов, НЕ являющиеся регулярными выражениями.
string strRowSeparator = "\n $"; //разделитель строк. в данном случае - Enter или символ $. Если несколько вариантов - то через пробел ("a b c")
string strColSeparator = " "; //разделитель столбцов. в данном случае - пробел. Если несколько вариантов - то через пробел ("a b c")
string[] arrRows = strTest.Split(strRowSeparator.Split(' '), StringSplitOptions.None);
foreach (string strRow in arrRows) {
	if (strColSeparator==" ") {
		tblTest.AddRow(strRow.Split(' '));
	}else{
		tblTest.AddRow(strRow.Split(strColSeparator.Split(' '), StringSplitOptions.None));
	}
}

//Используем произвольные разделители строк и столбцов, ЯВЛЯЮЩИЕСЯ регулярными выражениями.
string strRowSeparatorRegex= @"\d\$"; //регулярное выражения для использования в качестве разделителя строк
string strColSeparatorRegex = @"\ |\n"; //регулярное выражения для использования в качестве разделителя столбцов
string[] arrRows2 = Regex.Split(strTest, strRowSeparatorRegex);
foreach (string strRow in arrRows2) {
	tblTest.AddRow(Regex.Split(strRow, strColSeparatorRegex));
}

project.SendInfoToLog("Готово! Проверьте содержимое таблицы Таблица 1");