//Создаём объект класса IZennoList, привязываемся к списку уровня проекта (исходный список)
IZennoList lstSource = project.Lists["Список 1"];
lstSource.Clear(); //очищаем список
//наполняем список тестовыми значениями
lstSource.Add("1");
lstSource.Add("10");
lstSource.Add("2");
lstSource.Add("12");
//lstSource.Add("привет");

//Пытаемся сортировать список как числа (по возрастанию)
try{
	List<int> lstTemp = new List<int>();
	foreach (string strSourceElement in lstSource) {
		lstTemp.Add(Convert.ToInt32(strSourceElement));
	}
	lstTemp.Sort(); //Сортируем список, содержащий числа, по возрастанию
	lstSource.Clear();
	foreach (int intNumberElement in lstTemp) {
		lstSource.Add(intNumberElement.ToString());
	}
}catch{
	//сортируем список по алфавиту, если не удалось отсортировать как числа
	List<string> lstOrderByAsc = new List<string>();
	lstOrderByAsc.AddRange(lstSource.OrderBy(s=>s).ToList());
	lstSource.Clear();
	lstSource.AddRange(lstOrderByAsc);
}

//Пытаемся сортировать список как числа (по убыванию)
try{
	List<int> lstTemp = new List<int>();
	foreach (string strSourceElement in lstSource) {
		lstTemp.Add(Convert.ToInt32(strSourceElement));
	}
	lstTemp.Sort(); //Сортируем список, содержащий числа, по возрастанию
	lstTemp.Reverse(); //Реверсируем список, чтобы сделать его отсортированным по убыванию
	lstSource.Clear();
	foreach (int intNumberElement in lstTemp) {
		lstSource.Add(intNumberElement.ToString());
	}	
}catch{
	//сортируем список по алфавиту, если не удалось отсортировать как числа
	List<string> lstOrderByDesc = new List<string>();
	lstOrderByDesc.AddRange(lstSource.OrderByDescending(s=>s).ToList());
	lstSource.Clear();
	lstSource.AddRange(lstOrderByDesc);
}

project.SendInfoToLog("Выполнено. Проверьте содержимое списка Список 1");

//Примечания:
//1. Применив метод OrderBy для объекта типа List - мы сортируем этот список по возрастанию или убыванию. 
//	Метод OrderBy объекта типа IZennoList только возвращает отсортированную последовательность элементов, но порядок элементов в исходном списке не изменяет
//2. Команда lstSource.OrderBy(s=>s).ToList() содержит конструкцию Linq как параметр метода OrderBy. Хотя я стараюсь не использовать такие конструкции в демо проектах
//	этой части курса, всё же в данном случае рекомендую вам использовать код именно в таком виде. Аналог без использования Linq займёт гораздо больше места.
//	Сами Linq-запросы будут рассматриваться в продвинутом курсе.