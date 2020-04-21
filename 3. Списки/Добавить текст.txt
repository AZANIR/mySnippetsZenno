//Создаём объект класса IZennoList, привязываемся к списку уровня проекта (исходный список)
IZennoList lstSource = project.Lists["Список 1"];
lstSource.Clear(); //очищаем список

//добавляем текст в конец списка с разбиением на строки
string strDelimiterRegex = "\r\n"; //переменная, значение которой будет использоваться в качестве разделителя
string strText = "Привет, это первая строка" + Environment.NewLine + "...а это вторая, да";
lstSource.AddRange(Regex.Split(strText, strDelimiterRegex));

//добавляем текст в произвольную позицию списка с разбиением на строки
int intInsertPosition = 1;
List<string> lstTemp = new List<string>(); //объявляем временный список
if (intInsertPosition>0){
	lstTemp.AddRange(lstSource.Take(intInsertPosition)); //забираем во временный список элементы до позиции вставки
}
//string strDelimiterRegex = "\r\n"; //переменная-разделитель уже объявлена ранее
string strText2 = "Привет, это первая строка (в середине)" + Environment.NewLine + "...а это вторая, да (в середине)";
lstTemp.AddRange(Regex.Split(strText2, strDelimiterRegex));
for (int i=intInsertPosition; i<lstSource.Count;i++) {
	//забираем во временный список элементы после позиции вставки
	lstTemp.Add(lstSource[i]);
}
lstSource.Clear();
lstSource.AddRange(lstTemp);

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 1");

//Примечания:
//1. Функционал сниппета "Добавить текст" аналогичен сниппету "Данные-Обработка текста-В список".
//2. Вариант разделителя "Указанный в списке" в реальности хранится отдельно от списка (в настройках проекта). Вы можете применять любой свой разделитель при загрузке/выгрузке данных.