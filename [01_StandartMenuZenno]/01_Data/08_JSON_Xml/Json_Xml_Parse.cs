//парсим Xml текст из переменной
project.Xml.FromString(project.Variables["XmlText"].Value);

//парсим Json текст из переменной
project.Json.FromString(project.Variables["JsonText"].Value);