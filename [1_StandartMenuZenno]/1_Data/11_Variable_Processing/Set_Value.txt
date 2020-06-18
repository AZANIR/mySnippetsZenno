//Присваиваем значение переменной уровня проекта
project.Variables["test"].Value = "Проверка";

project.SendInfoToLog("Установлено значение переменной уровня проекта test.");