// получаем список, в котором будем искать
var sourceList = project.Lists["список"];
int removedItemsCount = 0;

// ищем в каждой строчке в списке
lock(SyncObjects.ListSyncer)
{
    for(int i=0; i < sourceList.Count; i++)
    {
        // читаем строку из списка
        var str = sourceList[i];
        // проверяем содержание текста в строке, если есть совпадение возвращаем "yes"

		string regex = @"\b[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b";
		var reg = new System.Text.RegularExpressions.Regex(regex,  System.Text.RegularExpressions.RegexOptions.None);
		if (reg.Matches(str).Count>0)
		{
			project.SendInfoToLog("Удаляем строку " + str + " на позиции " + i, false);			
			sourceList.RemoveAt(i); //удаляем элемент
			i--; //уменьшаем счётчик, чтобы проверить новый элемент на старом месте
			removedItemsCount++;
		}
    }
}
// возвращаем количество удалённых элементов
return removedItemsCount;