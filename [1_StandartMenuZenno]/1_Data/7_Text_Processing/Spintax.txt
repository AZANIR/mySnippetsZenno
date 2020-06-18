//объявляем переменную, содержащую текст для синонимизации
string strSource = "Всем привет! ZennoPoster - это {замечательная |отличная |{супер|суперпупер}-|мега}{программа|софтина|программулина}, позволяющая автоматизировать работу {c|над} онлайн-сервисами";

//Spintaxer.SpinString: синонимизируем текст (отобразим 10 вариантов в цикле)
for (int i=0; i<10; i++) {
	string strResult = new Macros.Spintaxer().SpinString(strSource, true); //второй параметр (extendedSyntax) указывает, использовать ли "расширенный" синтаксис синонимизации
	project.SendInfoToLog(String.Format("Результат синонимизации № {0}: {1}", i+1, strResult));
}

//Примечания
//1. Подробнее о расширенном синтаксисе вы можете узнать на странице: http://zennolab.com/wiki/ru:actions:text:extended-spintax