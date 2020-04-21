//Создаём объект класса IZennoList, привязываемся к списку уровня проекта (исходный список)
IZennoList lstTest = project.Lists["Список 2"];
lstTest.Clear(); //очищаем список
//наполняем список тестовыми значениями
lstTest.Add("Это первый элемент");
lstTest.Add("Это второй элемент");
lstTest.Add("Это третий элемент");
lstTest.Add("Это четвёртый элемент");
lstTest.Add("Это пятый элемент");
lstTest.Add("Это шестой элемент");
lstTest.Add("Это седьмой элемент");
lstTest.Add("Это восьмой элемент");
lstTest.Add("Эта девятый элемент");
lstTest.Add("Эта десятый элемент");
lstTest.Add("Это элемент номер одиннадцать");

//указываем путь к файлу, к которому будет привязан список
string strFilePath = project.Directory + @"\привязанный_файл.txt";

//IZennoList.Bind: привязываем файл к списку
lstTest.Bind(strFilePath);

project.SendInfoToLog("Выполнено. Проверьте содержимое файла привязанный_файл.txt в папке проекта");