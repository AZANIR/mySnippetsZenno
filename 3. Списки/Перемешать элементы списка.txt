//Создаём объект класса IZennoList, привязываемся к списку уровня проекта (исходный список)
IZennoList lstSource = project.Lists["Список 1"];
lstSource.Clear(); //очищаем список
//наполняем список тестовыми значениями
lstSource.Add("Это первый элемент");
lstSource.Add("Это второй элемент");
lstSource.Add("Это третий элемент");
lstSource.Add("Это четвёртый элемент");
lstSource.Add("Это пятый элемент");
lstSource.Add("Это шестой элемент");
lstSource.Add("Это седьмой элемент");
lstSource.Add("Это восьмой элемент");
lstSource.Add("Эта девятый элемент");
lstSource.Add("Эта десятый элемент");
lstSource.Add("Это элемент номер одиннадцать");

//IZennoList.Shuffle: перемешиваем список
List<string> lstTemp = new List<string>();
lstTemp.AddRange(lstSource.Shuffle());
lstSource.Clear();
lstSource.AddRange(lstTemp);
project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 1.");

//Демонстрация различий между IZennoList.Shuffle и List.Shuffle (подробнее - в примечаниях)
List<string> lstTest = new List<string>();
lstTest.Add("Это первый элемент");
lstTest.Add("Это второй элемент");
lstTest.Add("Это третий элемент");
lstTest.Add("Это четвёртый элемент");
lstTest.Add("Это пятый элемент");
lstTest.Shuffle();
project.SendInfoToLog("Перемешивание списка типа List одной командой: " + Environment.NewLine + String.Join(Environment.NewLine, lstTest));

//Примечания:
//1. Применив метод Shuffle для объекта типа List - мы перемешаем этот список. 
//	Метод Shuffle объекта типа IZennoList только возвращает перемешанную последовательность элементов, но порядок элементов в исходном списке не изменяет