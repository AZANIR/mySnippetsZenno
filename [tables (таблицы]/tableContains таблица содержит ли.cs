// берем из переменной текст, который надо искать
var textContains = project.Variables["tableSearchTextContains"].Value;
// получаем таблицу, в которой будем искать
var sourceTable = project.Tables["SourceTable"];
// ищем в каждой строчке в таблице
lock(SyncObjects.TableSyncer)
{
    for(int i=0; i < sourceTable.RowCount; i++)
    {
        // читаем строку из таблицы (это будет массив ячеек)
        var cells = sourceTable.GetRow(i).ToArray();
        // пройдем в цикле по всем ячейкам
        for (int j=0; j < cells.Length; j++)
        {
            // проверяем содержание текста в ячейке, если есть совпадение возвращаем "yes"
            if (cells[j].Contains(textContains))
                return "yes";
        }
    }
}
// если ничего не нашли возвращаем "no"
return "no";
