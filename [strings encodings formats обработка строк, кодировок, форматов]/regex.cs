//https://wiki.zennolab.com/doku.php?id=ru:zennoposter:csharp-macros-replacement

string regex = project.Variables["myRegEx"].Value;
string text =  project.Variables["textToParse"].Value;
var reg = new System.Text.RegularExpressions.Regex(regex,  System.Text.RegularExpressions.RegexOptions.None);
//return reg.Matches(text)[0];

//e-mail: \b[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b 


//если ничего не нашлось, то выходим по красной
if(null == reg.Matches(text) || 0 = reg.Matches(text).Count)
return null;

//сохраняем вхождения в отдельные переменные
if(reg.Matches(text).Count > 0)
project.Variables["myVar1"].Value = reg.Matches(text)[0];
if(reg.Matches(text).Count > 1)
project.Variables["myVar2"].Value = reg.Matches(text)[1];
//.. и дальше в таком же духе

return reg.Matches(text).Count;
