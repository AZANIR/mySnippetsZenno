//http://zennolab.com/discussion/threads/c-sharp-vs-webbrowser.17300/

StringBuilder sb = new StringBuilder("Привет мир");
sb.Append("!!!");
sb.Insert(7, "Компьютерный ");
Console.WriteLine(sb);
// заменяем слово
sb.Replace("мир", "world");
Console.WriteLine(sb);
// удаляем 6 символов, начиная с 1-го
sb.Remove(0, 6);
Console.WriteLine(sb);
// получаем строку из объекта StringBuilder
string s = sb.ToString();
Console.WriteLine(s);
return s;