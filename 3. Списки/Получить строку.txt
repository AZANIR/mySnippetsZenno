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

//получаем элемент списка по номеру
string strFirstElement = lstTest[0]; //0, если необходимо получить первый элемент
//lstTest.RemoveAt(0); //раскомментируйте строку, если необходимо удалить строку после взятия

//получаем случайный элемент списка
int intRandomElementNumber = new Random().Next(0, lstTest.Count-1);
string strRandomElement = lstTest[intRandomElementNumber];
lstTest.RemoveAt(intRandomElementNumber); //закомментируйте строку, если не нужно удалять строку после взятия

project.SendInfoToLog(String.Format("Первый элемент: {0}. Случайный элемент: {1}", strFirstElement, strRandomElement));