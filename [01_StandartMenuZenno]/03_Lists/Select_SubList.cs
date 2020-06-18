//Создаём объект класса IZennoList, привязываемся к списку уровня проекта (исходный список)
IZennoList lstSource = project.Lists["Список 1"];
lstSource.Clear(); //очищаем список
//наполняем список тестовыми значениями
lstSource.Add("Это первый элемент");
lstSource.Add("Это второй элемент");
lstSource.Add("Это третий элемент");
lstSource.Add("Это четвёртый элемент");
lstSource.Add("Это пятый нулемент");
lstSource.Add("Это шестой нелемент");
lstSource.Add("Это седьмой нылемент");
lstSource.Add("Это восьмой нолемент");
lstSource.Add("Эта девятый лелемент");
lstSource.Add("Эта десятый нулемент");
lstSource.Add("Это элемент номер одиннадцать");

//Создаём объект класса IZennoList, привязываемся к списку уровня проекта (список, в который будут помещаться данные)
IZennoList lstResult = project.Lists["Список 2"];
lstResult.Clear(); //очищаем список

List<string> lstElementsForRemove = new List<string>(); //создаём временный список (будет использован ниже)

//Выходим по ошибке, если список пуст
if (lstSource.Count==0) return null;

//Получаем диапазон значений из первого списка во второй список
string strElementsRange = "1-3"; //диапазон значений
int intStartIndex = 0;
int intEndIndex = 0;
if (strElementsRange.ToLower().Contains("2-4")) {
	intStartIndex =  new Random().Next(0, lstSource.Count);
	intEndIndex =  intStartIndex;
}else{
	intStartIndex =  Convert.ToInt32(new Regex(@"^\d(?=\D)").Match(strElementsRange).Value);
	intEndIndex =  Convert.ToInt32(new Regex(@"(?<=\D)\d$").Match(strElementsRange).Value);
}	
lstResult.AddRange(lstSource.ToList().GetRange(intStartIndex, intEndIndex-intStartIndex+1));
//раскомментируйте три строки ниже, если необходимо удалить строки после взятия
//for(int i=intStartIndex; i<intEndIndex+1; i++) {
//	lstSource.RemoveAt(intStartIndex);
//}

//Получаем элементы, содержащие текст, из первого списка во второй список
string strContainsText = "элемент";
//List<string> lstElementsForRemove = new List<string>(); //раскомментируйте эту строку в своём коде
foreach (string strSourceListElement in lstSource) {
	if (strSourceListElement.Contains(strContainsText)) {
		lstResult.Add(strSourceListElement);
		lstElementsForRemove.Add(strSourceListElement); //раскомментируйте эту строку, если необходимо удалять строки после взятия
	}
}
foreach (string strValueForRemove in lstElementsForRemove) lstSource.Remove(strValueForRemove);

//Получаем элементы, НЕ содержащие текст, из первого списка во второй список
string strNotContainsText = "элемент";
//List<string> lstElementsForRemove = new List<string>(); //раскомментируйте эту строку в своём коде
foreach (string strSourceListElement in lstSource) {
	if (!strSourceListElement.Contains(strNotContainsText)) {
		lstResult.Add(strSourceListElement);
		lstElementsForRemove.Add(strSourceListElement); //раскомментируйте эту строку, если необходимо удалять строки после взятия
	}
}
foreach (string strValueForRemove in lstElementsForRemove) lstSource.Remove(strValueForRemove);

//Получаем элементы, удовлетворяющие регулярному выражению, из первого списка во второй список
string strContainsRegex = @"ый\ ";
//List<string> lstElementsForRemove = new List<string>(); //раскомментируйте эту строку в своём коде
foreach (string strSourceListElement in lstSource) {
	if (new Regex(strContainsRegex).Matches(strSourceListElement).Count>0) {
		lstResult.Add(strSourceListElement);
		//lstElementsForRemove.Add(strSourceListElement); //раскомментируйте эту строку, если необходимо удалять строки после взятия
	}
}
foreach (string strValueForRemove in lstElementsForRemove) lstSource.Remove(strValueForRemove);

//Получаем элементы, НЕ удовлетворяющие регулярному выражению, из первого списка во второй список
string strNotContainsRegex = @"ый\ ";
//List<string> lstElementsForRemove = new List<string>(); //раскомментируйте эту строку в своём коде
foreach (string strSourceListElement in lstSource) {
	if (new Regex(strNotContainsRegex).Matches(strSourceListElement).Count==0) {
		lstResult.Add(strSourceListElement);
		//lstElementsForRemove.Add(strSourceListElement); //раскомментируйте эту строку, если необходимо удалять строки после взятия
	}
}
foreach (string strValueForRemove in lstElementsForRemove) lstSource.Remove(strValueForRemove);

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 2.");

//Примечания:
//1. При выборе значения "random" в поле "Диапазон" в стандартном сниппете фактически выбирается только один элемент списка. В моём коде сделано так же, хоть я и считаю что данная функция должна работать по другому
//2. Выбор элементов списка, содержащих текст, в другой список лучше всего делать при помощи Enumerable.TakeWhile (https://msdn.microsoft.com/ru-ru/library/bb534804(v=vs.110).aspx). Вместе с тем, конструкции Linq будут рассматриваться в продвинутом курсе по C# и в данном проекте не применяются. 