//http://zennolab.com/discussion/threads/alert-c.7860/#post45706

    // путь к файлу
    string path = project.Variables["pathToKeyWordFile"].Value;;
     // создаём список всех строк
    var lines = new List<string>();
    // получаем количество всех строк
    int count = Convert.ToInt32(Macros.FileSystem.FileCountOfLines(path));
    // загрузим все строки в список
    for(int i = 0; i < count; i++)
    {
         lines.Add(Macros.FileSystem.FileGetLine(path, i.ToString(), false));
    }
    // возвращаем ключевые слова через ; в указанном диапазоне от 3 до 6
    // т.е. начиная с 2-го индекса в количестве 4 штуки
    return string.Join(";", lines.GetRange(2, 4));
