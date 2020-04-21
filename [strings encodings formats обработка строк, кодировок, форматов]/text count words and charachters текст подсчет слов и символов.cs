//http://zennolab.com/discussion/threads/some-useful-c-snippets-from-lokiys.12309/


// Количество слов в тексте
var inputstring = project.Variables["text"].Value;
string texttostring = (inputstring);
int count = texttostring.Split(' ').Length;
return count;


// Количество символов
string stringToCount = "Hello World";
return stringToCount.Length.ToString();