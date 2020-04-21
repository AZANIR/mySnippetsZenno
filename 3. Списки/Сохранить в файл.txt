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

string strDelimiter = Environment.NewLine; //разделитель элементов списка в файле
string strFilePath = project.Directory + @"\сохранённый_список.txt";

//сохраняем список в файл с заменой содержимого файла
File.WriteAllText(strFilePath, String.Join(strDelimiter, lstSource));

//сохраняем список в файл с дописыванием содержимого списка в конец файла
string strFileContent = String.Join(strDelimiter, lstSource);
if (File.Exists(strFilePath)&&File.ReadAllLines(strFilePath).Length>0) {
	strFileContent = strDelimiter + strFileContent;
}
File.AppendAllText(strFilePath, strFileContent);

project.SendInfoToLog("Выполнено. Проверьте содержимое файла Сохранённый_список.txt в папке проекта");

//Примечания:
//1. Вариант разделителя "Указанный в списке" в реальности хранится отдельно от списка (в настройках проекта). Вы можете применять любой свой разделитель при загрузке/выгрузке данных.