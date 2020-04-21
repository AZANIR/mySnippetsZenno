//Создаём объект класса IZennoList, привязываемся к списку уровня проекта
IZennoList lstTest = project.Lists["Список 1"];

lstTest.Clear();  //очищаем список
//наполняем список тестовыми значениями
lstTest.Add("Это");
lstTest.Add("будет");
lstTest.Add("будет");
lstTest.Add("будет");
lstTest.Add("список с уникальными элементами");

//удаляем дубли из списка
List<string> lstDistinct = lstTest.Distinct().ToList(); //уникализируем значения во временном списке
lstTest.Clear(); //очищаем исходный список
lstTest.AddRange(lstDistinct); //помещаем уникализированные данные в исходный список

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 1.");

//Примечания:
//1. На форуме разработчиков есть очень красивая реализация удаления дублей, однако подобные конструкции кода мы будем рассматривать в продвинутом курсе (ZennoPro Academy Expert Course):
//var list = project.Lists["Список 1"];
//var buffer = (from q in list group q by q into l where l.Count() == 1 select l.Key).ToList();
//list.Clear();
//list.AddRange(buffer);
//Ссылка на форум: http://zennolab.com/discussion/threads/udalenie-dublirujuschix-strok-v-spiske-kak-takoe-realizovat.28978/#post-208425