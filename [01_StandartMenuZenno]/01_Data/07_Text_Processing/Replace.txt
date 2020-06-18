//Создаём переменные, которые потребуются нам при проведении замен
string strForReplace = "<div>Объявляем переменную, в значении которой будет производиться замена, бла бла бла</div>"; //переменная, в значении которой будет производиться замена
string strReplaceWhat = "Объявляем"; //что заменять
string strReplaceWith = "Создаём"; //чем заменять

//String.Replace: заменяем все совпадения
strForReplace = strForReplace.Replace("Объявляем", "Создаём"); //Заменяем все вхождения слова "Объявляем" в строке на "Создаём"

//заменяем только последнее совпадение
//Специализированного оператора для выполнения такой задачи нет. Ниже приведено одно из возможных решений
string strFindLast = "бла"; //что найти
string strReplaceLast = "BLA"; //на что заменить
strForReplace = strForReplace.Remove(strForReplace.LastIndexOf(strFindLast), strFindLast.Length).Insert(strForReplace.LastIndexOf(strFindLast), strReplaceLast);

//Замена совпадений с регулярным выражением
strForReplace = Regex.Replace(strForReplace, @"<.*?>", String.Empty); //Заменяем все теги HTML на пустую строку (убираем теги)

//Заменяем первые n совпадений
//Специализированного оператора для выполнения такой задачи нет. Ниже приведено одно из возможных решений
strReplaceWhat = "бл";
strReplaceWith = "Бл";
int intOccurencesToReplace = 2; //сколько первых совпадений заменять
Regex rgxReplaceOccurences = new Regex(Regex.Escape(strReplaceWhat));
strForReplace = rgxReplaceOccurences.Replace(strForReplace, strReplaceWith, intOccurencesToReplace);

//Замена только совпадений с определёнными номерами
//Специализированного оператора для выполнения такой задачи нет. Ниже приведено одно из возможных решений
strReplaceWhat = ",";
strReplaceWith = "!";
string strOccurencesNums = "2,3,5,8";
string[] arrOccurencesNums = strOccurencesNums.Split(',');
int intOccurencesDone = 0;
foreach (string strOccurenceNum in arrOccurencesNums) {
	int intOccurenceNum = Convert.ToInt32(strOccurenceNum.Trim())-intOccurencesDone++;
	Match mthReplaceOccurs = Regex.Match(strForReplace, "(("+Regex.Escape(strReplaceWhat)+").*?){"+intOccurenceNum+"}");
	if (mthReplaceOccurs.Success){
	    int intOccurIndex = mthReplaceOccurs.Groups[2].Captures[intOccurenceNum - 1].Index;
		strForReplace = strForReplace.Remove(intOccurIndex, strReplaceWhat.Length).Insert(intOccurIndex, strReplaceWith);
	}
}
	
project.SendInfoToLog("Результат выполнения всех замен: " + strForReplace);