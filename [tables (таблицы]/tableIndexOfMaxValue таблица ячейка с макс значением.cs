//http://zennolab.com/discussion/threads/vybrat-maks-znachenija-iz-tablicy.17006/#post-106130

var column = 4;
var list = new List<int>();
lock(SyncObjects.TableSyncer){
    var table = project.Tables["table"];
    for(int i = 1; i < table.RowCount; i++){
        var tmp = table.GetCell(column,i);
        if(String.IsNullOrWhiteSpace(tmp)) tmp = "0";
        list.Add(int.Parse(tmp));
    }
}
 
int maxvalue = list.Max();
return list.IndexOf(maxvalue);