//Создаём объект класса IZennoList, привязываемся к списку уровня проекта
IZennoList lstTest = project.Lists["Список 1"];

//IZennoList.Count: получаем количество строк
int intListCount = lstTest.Count;

project.SendInfoToLog(String.Format("В списке Список 1 содержится {0} записей", intListCount));