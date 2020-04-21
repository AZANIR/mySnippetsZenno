//вывести как информация, но только в PM
project.SendInfoToLog(project.Variables["Count_steam_info"].Value +" Проводится разрегистрация функции сброса переменных...", false);

//предупреждение, но только в PM
project.SendWarningToLog(project.Variables["Count_steam_info"].Value +" Достигнут порог по количеству капч в " + project.Variables["Input_captcha_fail"].Value + ", заданный в параметрах:", false);

//ошибка, но только в PM
project.SendErrorToLog(project.Variables["Count_steam_info"].Value +" Не распознан порт из строки project.Variables[\"proxy\"].Value " + project.Variables["proxy"].Value  + "...", false);

//при необходимости отображать сообщение в ZP, в конце вызова надо писать true вместо false