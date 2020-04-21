Решение для импорта cookies в ZennoPoster, сохранённых в файл расширением cookies.txt в Mozilla FireFox или Google Chrome

string path = project.Directory + @"\cookies.txt"; // путь к файлу cookies.txt
string cookies = string.Join("\r\n", File.ReadAllLines(path).Where(s => !Regex.Match(s, @"^#(\s|$)").Success).Select(s => Regex.Replace(s, "(\t(TRUE|FALSE)\t/\t(TRUE|FALSE)\t)(0)(\t)", "$1$5")));
instance.SetCookie(cookies);