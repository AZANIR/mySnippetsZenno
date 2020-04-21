var parse = project.Variables["parse"].Value;
var regex = new Regex("регулярка");
var zp_list = project.Lists["Список 1"];

regex.Matches(parse).Cast<Match>().ToList().ForEach(m=>zp_list.Add(m.Value)); 
