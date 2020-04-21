//Создаём объект класса IZennoList, привязываемся к списку уровня проекта
IZennoList lstTest = project.Lists["Список 1"];
lstTest.Clear(); //очищаем список

//наполняем список тестовыми значениями
lstTest.Add("Это первый элемент");
lstTest.Add("Это второй элемент");
lstTest.Add("Это третий элемент");
lstTest.Add("Это четвёртый элемент");
lstTest.Add("Это пятый нулемент");
lstTest.Add("Это шестой нелемент");
lstTest.Add("Это седьмой нылемент");
lstTest.Add("Это восьмой нолемент");
lstTest.Add("Эта девятый лелемент");
lstTest.Add("Эта десятый нулемент");
lstTest.Add("Это элемент номер одиннадцать");

//IZennoList.RemoveAt: удаляем элемент с соответствующим индексом
//lstTest.RemoveAt(0);

//Удаляем элементы с указанными номерами (Номера через запятую, интервалы либо "Random", если необходимо удалить случайный элемент)
string strRemoveIndexes="0, 2-5, Random";
strRemoveIndexes = strRemoveIndexes.Replace(" ", String.Empty);
Random rndRowIndex = new Random();
List<int> lstRemoveIndexes = new List<int>();
foreach (string strRowIndex in strRemoveIndexes.Replace(" ", String.Empty).Split(',')) {
	if (Regex.IsMatch(strRowIndex, @"^\d+$")) {
		lstRemoveIndexes.Add(Convert.ToInt32(strRowIndex));
	}else if (strRowIndex.ToLower()=="random"){
		lstRemoveIndexes.Add(rndRowIndex.Next(0, lstTest.Count-1));
	}else if(strRowIndex.Contains("-")){
		int intStartIndex = Convert.ToInt32(new Regex(@"^\d(?=\D)").Match(strRowIndex).Value);
		int intEndIndex = Convert.ToInt32(new Regex(@"(?<=\D)\d$").Match(strRowIndex).Value);
		
		for (int k=intStartIndex; k<intEndIndex+1; k++) {
			lstRemoveIndexes.Add(k);
		}
	}
}
lstRemoveIndexes.Sort();
int intElementsRemoved=0;
foreach (int intRemoveIndex in lstRemoveIndexes) {
	lstTest.RemoveAt(intRemoveIndex-intElementsRemoved++);
}

lstTest.Add("этот элемент будет удалён по значению");
//IZennoList.Remove: удаляем элемент по его значению
lstTest.Remove("этот элемент будет удалён по значению");

//IZennoList.Clear: удаляем все элементы списка (раскомментируйте чтобы проверить)
//lstTest.Clear();

//Удаляем элементы, содержащие текст
string strContainsForRemove = "девятый";
int i=0;
while(true) {
	if (i==lstTest.Count||lstTest.Count==0) break;
	if (lstTest[i].Contains(strContainsForRemove)) {
		lstTest.RemoveAt(i);
	}else{
		i++;
	}
}

//Удаляем элементы, НЕ содержащие текст
string strNotContainsForRemove = "мент";
int n=0;
while(true) {
	if (n==lstTest.Count||lstTest.Count==0) break;
	if (!lstTest[n].Contains(strNotContainsForRemove)) {
		lstTest.RemoveAt(n);
	}else{
		n++;
	}
}

//Удаляем элементы, удовлетворяющие регулярному выражению
string strContainsRegex = @"н.лемент";
int m=0;
while(true) {
	if (m==lstTest.Count||lstTest.Count==0) break;
	if (new Regex(strContainsRegex).Matches(lstTest[m]).Count>0) {
		lstTest.RemoveAt(m);
	}else{
		m++;
	}
}

//Удаляем элементы, НЕ удовлетворяющие регулярному выражению
string strNotContainsRegex = @"номер";
int r=0;
while(true) {
	if (r==lstTest.Count||lstTest.Count==0) break;
	if (new Regex(strNotContainsRegex).Matches(lstTest[r]).Count==0) {
		lstTest.RemoveAt(r);
	}else{
		r++;
	}
}

//Добавляем пустой и пробельный элемент для следующего шага
lstTest.Add("");
lstTest.Add("   ");
//Удаляем пустые и содержащие только пробельные символы элементы
int p=0;
while(true) {
	if (p==lstTest.Count||lstTest.Count==0) break;
	if (String.IsNullOrWhiteSpace(lstTest[p])) {
		lstTest.RemoveAt(p);
	}else{
		p++;
	}
}

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 1");