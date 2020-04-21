//project.Profile.RegenerateLogin: генерируем новый логин
string strNewLogin = project.Profile.RegenerateLogin("[Eng|3][RndNum|1970|1990]");

project.SendInfoToLog("Сгенерированный логин: " + strNewLogin);

//Примечания:
//1. Форман строки [Eng|3][RndNum|1970|1990]:
//[Eng|3]: слева от вертикальной черты - язык (возмозные варианты - Eng, Jap, Lat). 
//[Eng|3]: справа от вертикальной черты - количество СЛОГОВ на указанном языке
//[RndNum|1970|1990] - в данном случае: "случайное число между 1970 и 1990"
//2. Документация по методу RegenerateLogin (Для ветки 5.9.9): https://help.zennolab.com/en/v5/zennoposter/5.9.9/webframe.html#topic719.html