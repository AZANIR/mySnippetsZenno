lock(SyncObjects.TableSyncer)
{
    for(int i=0; i < sourceTable.RowCount; i++)
    {
        // читаем строку из таблицы (это будет массив ячеек)
        var cells = sourceTable.GetRow(i).ToArray();
        // пройдем в цикле по всем ячейкам
        for (int j=0; j < cells.Length; j++)
        {
 
            if (parserRegex.IsMatch(cells[j]))
            {
                destTable.AddRow(cells);
                break;
            }
        }
    }
}
