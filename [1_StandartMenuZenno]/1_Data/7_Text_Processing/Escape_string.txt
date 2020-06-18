//объявляем переменную, содержащую текст для экранирования (для последующего использования в регулярном выражении)
string strSource = "Это с$т$р$о$ка /для^ экра.*нирования";

string strResult = Regex.Escape(strSource);

project.SendInfoToLog("Результат экранирования: " + strResult);