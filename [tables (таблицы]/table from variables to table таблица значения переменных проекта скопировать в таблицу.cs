//http://zennolab.com/discussion/threads/method-to-change-default-value-from-c.18664/

//префикс, вхождения которого мы ищем
string prefix = "in_"; //prefix of names for dumpable variables
string tablename = "dump"; //name of table
 
lock(SyncObject){lock(SyncObjects.TableSyncer){
 
    var table = project.Tables[tablename];
 
    //load data from table into variables
    for(int i=0; i<table.RowCount;i++){
        var row = table.GetRow(i).ToArray();
        if(project.Variables.Keys.Contains(row[0]) && row[0].StartsWith(prefix))
            if(!string.IsNullOrWhiteSpace(row[1]))
                project.Variables[row[0]].Value = row[1];
    }
 
    var varkeylist = project.Variables.Keys.Where(k=>k.StartsWith(prefix)).ToList();
 
    //все элементы, содержащие префикс, копируем в таблицу
    //make some manipulations with values and save them to next threads
    //in this example each value getting increased by 1
    table.Clear();
    varkeylist.ForEach(k=> {
        var newvalue = (int.Parse(project.Variables[k].Value)+1).ToString();
        table.AddRow(new List<string> {k, newvalue});
    });
 
}}

