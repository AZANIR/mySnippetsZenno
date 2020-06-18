//Создаём объект класса IZennoList, привязываемся к списку уровня проекта
IZennoList lstTest = project.Lists["Список 1"]; //из этого списка будем добавлять данные
IZennoList lstTest2 = project.Lists["Список 2"]; //в этот список будем добавлять данные
lstTest2.Clear(); //очищаем список, в который будем помещать данные

//IZennoList.AddRange: добавляем данные из списка "Список 1" в список "Список 2"
lstTest2.AddRange(lstTest);

//Добавляем данные из списка "Список 1" в список "Список 2" (без создания объектов класса IZennoList)
project.Lists["Список 2"].AddRange(project.Lists["Список 1"]);

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 2");