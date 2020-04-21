//http://zennolab.com/discussion/threads/poisk-zamena-v-spiske.18675/#post-120043
//Подскажите, пожалуйста, как осуществить поиск-замену в списке, в том числе по регулярному выражению?
//Или хотя бы, как добавить какое-то определенное выражение (фразу) в начало каждой строки списка? Количество строк всегда рандомное! 

//// получаем список, в котором будем искать
var sourceList = project.Lists["Spisok"];
 
var parserRegex = new Regex("\\d{1,2}"); // Вот регулярка на поиск чисел
 
lock(SyncObjects.ListSyncer)
{
    for(int i=0; i < sourceList.Count; i++) // Пробегаемся по списку
    {
        if (parserRegex.IsMatch(sourceList[i])) // Если регулярка срабатывает, то..
        {
            sourceList[i]="1"; // Заменяем текущий элемент на цифру 1
        }
    }
}
 
 /*
 // получаем список, в котором будем искать
var sourceList = project.Lists["Spisok"];
var poisk = "2";
 
lock(SyncObjects.ListSyncer)
{
    for(int i=0; i < sourceList.Count; i++) // Пробегаемся по списку
    {
        if (sourceList[i]==poisk)
        {
            sourceList[i]="1";
           
        }
    }
}
 */