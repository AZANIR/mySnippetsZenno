//http://zennolab.com/discussion/threads/search-in-list-and-tables-via-c-macro.10733/
//We need to check if there is a cell that contains a specific text.
//It can be solved using this C# macro (in the attached project, we are searching a cell that contains "Mexico")
// take text for search from a variable
var textContains = project.Variables["tableSearchTextContains"].Value;
// get table for search
var sourceTable = project.Tables["SourceTable"];
// search in each row
lock(SyncObjects.TableSyncer)
{
    for(int i=0; i < sourceTable.RowCount; i++)
    {
        // read a row (array of cells)
        var cells = sourceTable.GetRow(i).ToArray();
        // loop through all cells
        for (int j=0; j < cells.Length; j++)
        {
            // check if cell contains specified text, if there are matches return "yes"
            //если в какой-то ячейке нашлось то, что искали, то просто возвращаем "да"
            if (cells[j].Contains(textContains))
                return "yes";
        }
    }
}
// if nothing found return "no"
return "no";