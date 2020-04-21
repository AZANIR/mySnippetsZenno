var Black_List_Mainer     =  project.Lists["Black_List_Mainer"];  // список с блокируемыми доменами. майнеры и иже с ними
var White_List_JS        =  project.Lists["White_List_JS"];        // список с разрешенными доменами для яваскриптов.
///// формирование белого листа JS ////////////////
string White_List_JS_regex =  @"(?<=(^|\r\n))((?!(";
string res="";
for (int i=0; i<White_List_JS.Count; i++){
    string data=White_List_JS[i];
    res=res+data.Replace(".",@"\.")+"|";
}
res=res.TrimEnd(new char[] { '|' });
White_List_JS_regex = White_List_JS_regex + res + @")).)*(\.js)";
List<string> White_List_JS_list = new List<string>() { };
White_List_JS_list.Add(White_List_JS_regex);
/////////////////////////////////////////////////////
instance.SetContentPolicy("BlockList", Black_List_Mainer, White_List_JS_list);