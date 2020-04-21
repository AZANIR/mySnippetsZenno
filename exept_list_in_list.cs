List<string> lstExcept = lst_links.Except<string>(used_lst).ToList<string>(); //уникализируем значения во временном списке
lst_links.Clear(); //очищаем исходный список
lst_links.AddRange(lstExcept);