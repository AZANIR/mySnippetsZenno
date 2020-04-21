//http://zennolab.com/discussion/threads/besplatnye-snipety-na-zakaz.23450/page-5#post-183362

var list = project.Lists["List"];
string text = project.Variables["Text"].Value;
list.Add(text);