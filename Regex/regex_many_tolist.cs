//pfoto сбор фотографий и скачивание 
List <string> pfoto_list = Regex.Matches(item_adv, @"https://\d+\.img\.avito\.st/640x480/.*?\.jpg").Cast<Match>().Select(x=>x.Value).ToList();