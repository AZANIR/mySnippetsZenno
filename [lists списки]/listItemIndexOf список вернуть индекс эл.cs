//http://zennolab.com/discussion/threads/kak-realizovat-proverku-stroki.10402/#post60911

var url = project.Variables["url"].Value;
var check = project.Lists["List"];
return check.IndexOf(url);
