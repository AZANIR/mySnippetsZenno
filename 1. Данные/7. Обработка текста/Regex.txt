//объявляем переменную, содержащую исходную строку
string strSource = "Это <i>исходная</i> строка <b>содержащая</b> теги и адреса: test@test.ru, work@blaka.ru mail@work.com";

//объявляем переменную, содержащую регулярное выражение (паттерн) для поиска адреса электронной почты (http://emailregex.com/)
string strPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

//получаем первое совпадение с регулярным выражением
string strRegexResult = new Regex(strPattern).Match(strSource).Value;
project.SendInfoToLog("Первое совпадение: " + strRegexResult);

//получаем последнее совпадение с регулярным выражением
strRegexResult = new Regex(strPattern, RegexOptions.RightToLeft).Match(strSource).Value;
project.SendInfoToLog("Последнее совпадение: " + strRegexResult);

//получаем все совпадения с регулярным выражением (результат помещается в список)
IZennoList lstTest = project.Lists["Список 1"];
lstTest.Clear(); //чистим список
foreach (Match rxMatch in Regex.Matches(strSource, strPattern)) {
	lstTest.Add(rxMatch.Value);
}
project.SendInfoToLog("Все совпадения с регулярным выражением добавлены в список Список 1");

//получаем совпадения с регулярным выражением по номерам (результат помещается в список). номера должны быть разделены запятыми. номер может быть один
string strMatchNumbers="1,3"; //номера совпадений, которые необходимо получить
MatchCollection mthRegexResults = Regex.Matches(strSource, strPattern);
foreach (string strMatchNumber in strMatchNumbers.Split(',')) {
	int intMatchNumber=Convert.ToInt32(strMatchNumber.Trim());
	if(intMatchNumber<=mthRegexResults.Count) {
		lstTest.Add(mthRegexResults[intMatchNumber-1].Value);
	}
}
project.SendInfoToLog("Все совпадения с заданными номерами добавлены в список Список 1");

//раскладываем совпадения по переменным:
MatchCollection mthRegexResults2 = Regex.Matches(strSource, strPattern);
string strEmail1 = mthRegexResults2[0].Value;
string strEmail2 = mthRegexResults2[1].Value;
string strEmail3 = mthRegexResults2[2].Value;
project.SendInfoToLog(String.Format("Результат разложения по переменным. 1:{0}, 2:{1}, 3:{2}.", strEmail1, strEmail2, strEmail3));

//раскладываем совпадения в таблицу (регулярное выражение с использованием групп - https://msdn.microsoft.com/ru-ru/library/system.text.regularexpressions.match.groups(v=vs.110).aspx)
IZennoTable tblTest = project.Tables["Таблица 1"]; //создаём объект таблицы с привязкой к таблице уровня проекта
tblTest.Clear(); //чистим таблицу
string strGroupSource = "<a>ссылка1</a><p>параграф1</p><div>div1</div><a>ссылка2</a><p>параграф2</p><div>div2</div>"; //объявляем переменную, содержащую исходную строку, которая будет разбиваться на группы
string strGroupRegex = @"(?<=<a>)(.*?)</a><p>(.*?)</p><div>(.*?)(?=</div>)"; //регулярное выражение с указание групп
string strIgnoreGroupsNums = "0,5"; //Перечисление номеров групп, которые будут игнорироваться (через запятую). Группа 0 содержит полный результат без разбивки (нужно игнорировать по умолчанию) 
int[] arrIgnoreGroupsNums = Array.ConvertAll(strIgnoreGroupsNums.Split(','), int.Parse);
foreach (Match mthRegexGroup in Regex.Matches(strGroupSource, strGroupRegex)) {
	string strTableRowContent = String.Empty;
	for (int i=0; i<mthRegexGroup.Groups.Count; i++) {
		if(!arrIgnoreGroupsNums.Contains(i)) {
			if (strTableRowContent!=String.Empty) {
				strTableRowContent += tblTest.ColSeparator;
			}
			strTableRowContent += mthRegexGroup.Groups[i].Value;
		}
	}
	tblTest.AddRow(strTableRowContent);
}