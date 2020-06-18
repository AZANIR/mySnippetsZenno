//project.Variables["name"].Value: присваиваем значение переменной уровня проекта
project.Variables["test"].Value = "Значение, присвоенное из кода C#";

project.SendInfoToLog("Готово! Проверьте значение переменной уровня проекта с именем test.");