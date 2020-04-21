//Создаём объект класса IZennoList, привязываемся к списку уровня проекта
IZennoList lstTest = project.Lists["Список 1"];
lstTest.Clear();  //очищаем список
//наполняем список тестовыми значениями
lstTest.Add("Это");
lstTest.Add("будет");
lstTest.Add("одна");
lstTest.Add("строка");

//String.Join: объединение массива строк или элементов списка в одну строку
string strListToStringDelimiter = Environment.NewLine; //если разделитель должен быть новой строкой
strListToStringDelimiter = " "; //свой разделитель
string strJoinResult = String.Join(strListToStringDelimiter, lstTest);

project.SendInfoToLog("Результат объединения элементов списка: " + strJoinResult);

//Примечания:
//1. Вариант разделителя "Указанный в списке" в реальности хранится отдельно от списка (в настройках проекта). Вы можете применять любой свой разделитель при загрузке/выгрузке данных.