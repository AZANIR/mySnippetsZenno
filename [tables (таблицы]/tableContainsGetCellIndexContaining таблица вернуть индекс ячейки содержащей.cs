IZennoTable table = project.Tables["table"];
 
for (int i = 0; i < table.RowCount; i++)
{
    var colums = new List<string>(table.GetRow(i));
   
    for (int j = 0; j < colums.Count; j++)
        if (colums[j].ToLower().Contains(project.Variables["lookfor"].Value.ToLower()))
        {
            project.Variables["row"].Value = i.ToString();
            project.Variables["column"].Value = j.ToString();
            return "ok";    
        }
}
return String.Format("\"{0}\" not found", project.Variables["lookfor"].Value);
