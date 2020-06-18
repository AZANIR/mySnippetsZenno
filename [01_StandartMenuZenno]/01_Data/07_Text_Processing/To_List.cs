//объявляем переменную, содержимое которой будет разложено по списку
string strTest = "Содер#жимое этой пер$5еме$3нн$6ой " + Environment.NewLine + "будет разло^жено по списку";

//создаём объект списка, связанный со списком уровня проекта
IZennoList lstTest = project.Lists["Список 1"];
lstTest.Clear(); //чистим список

//Добавляем отдельную строку в список (без разделения добавляемой строки на фрагменты)
lstTest.Add(strTest);

//Добавляем в список строку, разделённую по пробелам
string[] arrAddToList1 = strTest.Split(' ');
lstTest.AddRange(arrAddToList1);

//Добавляем в список строку, разделённую по Enter
string[] arrAddToList2 = strTest.Split('\n');
lstTest.AddRange(arrAddToList2);

//Добавляем в список строку, разделённую по собственному разделителю, НЕ являющемуся регулярным выражением
string strPattern = "$ # ^"; //символ (или группа символов) для использования в качестве разделителя, если разделитель НЕ является регулярным выражением
string[] arrAddToList3 = strTest.Split(strPattern.Split(' '), StringSplitOptions.None);
lstTest.AddRange(arrAddToList3);

//Добавляем в список строку, разделённую по собственному разделителю, ЯВЛЯЮЩЕМУСЯ регулярным выражением
string strPatternRegex= @"\$\d"; //регулярное выражение, использующееся в качестве разделителя
string[] arrAddToList4 = Regex.Split(strTest, strPatternRegex);
lstTest.AddRange(arrAddToList4);

project.SendInfoToLog("Готово! Проверьте содержимое списка Список 1");