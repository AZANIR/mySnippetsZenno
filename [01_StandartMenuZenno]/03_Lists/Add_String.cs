//Создаём объект класса IZennoList, привязываемся к списку уровня проекта
IZennoList lstTest = project.Lists["Список 1"];
lstTest.Clear(); //очищаем список

//Добавляем строку в конец списка
lstTest.Add("Элемент 1");
lstTest.Add("Элемент 2");
lstTest.Add("Элемент 3");

//IZennoList.Insert: добавляем строку в начало списка
lstTest.Insert(0, "В начало списка");

//Добавляем строку в указанную позицию
lstTest.Insert(2, "Это будет третий элемент");

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 1");