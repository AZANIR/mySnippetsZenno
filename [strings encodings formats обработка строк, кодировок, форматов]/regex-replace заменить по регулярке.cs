//http://zennolab.com/discussion/threads/c-sharp-vs-webbrowser.17300/
//Данная версия метода Replace принимает два параметра: строку с текстом, где надо выполнить замену, и сама строка замены. Так как в качестве //шаблона выбрано выражение "\s+ (то есть наличие одного и более пробелов), метод Replace проходит по всему тексту и заменяет несколько подряд //идущих пробелов ординарными.

//Результатом обработки будет: Мама мыла раму. {вместо двух пробелов между словами, как было изначально} .
//+ не забываем вместо слов подставлять переменные.

string s = project.Variables["url"].Value;
string pattern = @"\s+";
string target = " ";
Regex regex = new Regex(pattern);
string result = regex.Replace(s, target);
return result;