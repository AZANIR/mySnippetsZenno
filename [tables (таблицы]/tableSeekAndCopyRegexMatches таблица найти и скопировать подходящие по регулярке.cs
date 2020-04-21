//http://zennolab.com/discussion/threads/search-in-list-and-tables-via-c-macro.10733/
//There is a table, we ned select rows, that suit search criteria and put them to another table.
//It can be solved using this C# macro (in the attached project, we are searching for people whose jobs related with sales)
// take regex for parsing from a variable
var parserRegexPattern = project.Variables["tableSearchRegex"].Value;
var parserRegex = new System.Text.RegularExpressions.Regex(parserRegexPattern);
// get a table where we search
var sourceTable = project.Tables["SourceTable"];
// get result table
var destTable = project.Tables["OutputTable"];
// search in each row
lock(SyncObjects.TableSyncer)
{
    for(int i=0; i < sourceTable.RowCount; i++)
    {
        // read a row (array of cells)
        var cells = sourceTable.GetRow(i).ToArray();
        // check the second row if it matches a regex, if there are matches we put it to result table
        if (parserRegex.IsMatch(cells[1]))
            destTable.AddRow(cells);
    }
}
 