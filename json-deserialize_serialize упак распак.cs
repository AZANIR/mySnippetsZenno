//вернуть строку, разделённую точкой с запятой

var tmp = project.Variables["tmp"].Value;
var fields = "uid,name,description,shortname,picAvatar,members_count,shop_visible_public".Split(',');

var regex = new Regex("\"([^\"]+)\":\"?(.*?)\"?(,|}|\\])");
var d = regex.Matches(tmp).Cast<Match>().ToDictionary(k=>k.Groups[1].Value, v=>v.Groups[2].Value);
return string.Join(";", fields.Select(f=>(d.Keys.Contains(f))?d[f]:"")); 

http://zennolab.com/discussion/threads/json-i-c.16858/#post-105530

//from json to table
string json = project.Variables["json"].Value;
var table =  project.Tables["table"];
 
List<string> id_list = System.Text.RegularExpressions.Regex.Matches(json, "(?<=id\":\").*?(?=\")").Cast<System.Text.RegularExpressions.Match>().Select(v=>v.Value).ToList<string>();
List<string> text_list = System.Text.RegularExpressions.Regex.Matches(json, "(?<=text\":\").*?(?=\")").Cast<System.Text.RegularExpressions.Match>().Select(v=>v.Value).ToList<string>();
 
lock(SyncObjects.TableSyncer){
    for(int i=0; i<id_list.Count; i++)
        table.AddRow(new List<string> {id_list[i], text_list[i]});
}

//from json to table
string json = project.Variables["json"].Value;
var table =  project.Tables["table"];
 
var json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
Dictionary<string,object> mes = json_serializer.Deserialize<Dictionary<string,object>>(json);
var list = (System.Collections.ArrayList)mes["mes"];
lock(SyncObjects.TableSyncer){
    foreach (var item in list){
        string id = (string)((Dictionary<string, object>)(item))["id"];
        string text = (string)((Dictionary<string, object>)(item))["text"];
        table.AddRow(new List<string> {id, text});
    }
}

//http://zennolab.com/discussion/threads/reguljarka-v-snipete.20636/#post-136117
//from json to table - many columns
var tmp = project.Variables["tmp"].Value;
var fields = "uid,name,description,shortname,picAvatar,members_count,shop_visible_public".Split(',');

var regex = new Regex("\"([^\"]+)\":\"?(.*?)\"?(,|}|\\])");
var d = regex.Matches(tmp).Cast<Match>().ToDictionary(k=>k.Groups[1].Value, v=>v.Groups[2].Value);
return string.Join(";", fields.Select(f=>(d.Keys.Contains(f))?d[f]:"")); 