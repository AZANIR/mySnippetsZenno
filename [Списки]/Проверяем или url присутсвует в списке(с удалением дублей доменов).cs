//создаем временный список
List<string> temp_lst = new List<string>();
//подключаем скписок с сайтами для очистки и удаления дублей
var good_lst = project.Lists["Good"];

if(good_lst.Count>0){
	for(int x=0; x<good_lst.Count; x++){
		string temp_item = good_lst[x].Trim();
		project.SendWarningToLog(temp_item, false);
		string context ="";
		context = Convert.ToString(Regex.Match(temp_item, @"(?<=//).*?(?=/)")).Trim();
		project.SendWarningToLog(context, false);
		if(temp_lst.Count == 0){
			temp_lst.Add(temp_item);
		}
		string flag ="no";
		for(int t = 0; t<temp_lst.Count; t++){
			string temp_tl = temp_lst[t];
			if(temp_tl.Contains(context)){
				project.SendWarningToLog("we found", false);
				flag = "yes";
				continue;
			}
		}
		if(flag == "no"){
			temp_lst.Add(temp_item);
		}
	}
}

var temp = project.Lists["temp"];
temp.AddRange(temp_lst);