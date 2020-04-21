//http://zennolab.com/discussion/threads/snipety.8815/

IZennoTable table = project.Tables["table"];
 
 
for (int i = 0; i < table.RowCount; i++)
{
    var colums = new List<string>(table.GetRow(i));
   
    for (int j = 0; j < colums.Count; j++)
        if (colums[j].ToLower() == project.Variables["lookfor"].Value.ToLower())
            return String.Format("{0}:{1}", i, j);
}
return "-1:-1";
