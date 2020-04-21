//Преобразуем переменную уровня проекта в локальную переменную числового типа
int intTest = Convert.ToInt32(project.Variables["test"].Value);
//Увеличиваем переменную на указанное число
intTest = intTest + 1;
//Присваиваем переменной уровня проекта результат вычислений
project.Variables["test"].Value = intTest.ToString();

project.SendInfoToLog("Значение переменной уровня проекта test увеличено на заданное число.");