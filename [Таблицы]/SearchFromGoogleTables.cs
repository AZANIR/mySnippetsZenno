// сниппет ищет в гугл таблице искомый текст построчно
// поячейковое сравнение и вынос данных в переменные при совпадении искомого

var textContains = "someText";
var sourceTable = project.GoogleSpreadsheets["googleTables"];

for (int i = 0; i < sourceTable.RowCount; i++)
{
  var cells = sourceTable.GetRow(i).ToArray();
  for (int j = 0; j < cells.Length; j++)
  {
    if (cells[j].Contains(textContains))
    {
      project.Variables["date_common"].Value = sourceTable.GetCell("A", i);
      project.Variables["status_common"].Value = sourceTable.GetCell("F", i);
      project.Variables["price_common"].Value = sourceTable.GetCell("E", i);
      return i;
    }

  }
}

return "no";