ZennoLab.Spintax.WordAi.Spintaxer waTest = new ZennoLab.Spintax.WordAi.Spintaxer();
//Объявляем переменную, содержащую исходный текст для синонимизации
string strSourceText = "The fitness trackers, which come in six bright colors, were already being distributed and were set to be available for four weeks in the United States and Canada. The plastic wrist-worn pedometer measures steps and blinks quickly or slowly depending on the pace of the person wearing it.";

//ZennoLab.Spintax.WordAi.Spintaxer.SpinTheArticle: синонимизируем текст (только английский язык)
string strResultText = waTest.SpinTheArticle(strSourceText, 1, "");

project.SendInfoToLog("Результат синонимизации: " + strResultText);

//Примечания:
//документацию по API WordAI вы можете поулчить по ссылке: https://wordai.com/users/api.php