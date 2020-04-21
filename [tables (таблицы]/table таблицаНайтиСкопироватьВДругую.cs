http://zennolab.com/discussion/threads/besplatnye-snipety-na-zakaz.23450/

//берем регулярное выражение для парсинга из переменной
var parserRegexPattern = project.Variables["tableSearchRegex"].Value;
var parserRegex = new System.Text.RegularExpressions.Regex(parserRegexPattern);
// получаем таблицу, в которой будем искать
var sourceTable = project.Tables["SourceTable"];
// получаем таблицу, в которую будем класть
var destTable = project.Tables["OutputTable"];
// ищем в каждой строчке в таблице
for(int i=0; i < sourceTable.RowCount; i++)
{
// читаем строку из таблицы (это будет массив ячеек)
var cells = sourceTable.GetRow(i).ToArray();
// проверяем вторую ячейку регулярным выражением, если есть совпадение кладем результат во вторую таблицу
if (parserRegex.IsMatch(cells[0]))
destTable.AddRow(cells);
}