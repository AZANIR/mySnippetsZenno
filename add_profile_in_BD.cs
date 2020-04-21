byte[] AsBytes = File.ReadAllBytes(project.Directory + @"\profiles\" + project.Variables["cfg_instauser4monitoring_login"].Value + ".zpprofile"); // в скобках получается путь к файлу
String AsBase64String = Convert.ToBase64String(AsBytes); // В результате получается длииииинная строка для записи в БД

// А это наоборот. Длинная трока в файл
byte[] tempBytes = Convert.FromBase64String(project.Variables["base64String"].Value); // Конвертим строку из переменной
File.WriteAllBytes(project.Directory + @"\profiles\" + project.Variables["cfg_instauser4monitoring_login"].Value + ".zpprofile",tempBytes); // Сохраняем как файл