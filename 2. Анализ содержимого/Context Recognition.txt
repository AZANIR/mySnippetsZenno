Tab Tab1 = instance.ActiveTab;
Tab1.Navigate("http://www.bbc.com/news/world-europe-37359196");
Tab1.WaitDownloading();

string strText = Tab1.FindElementByXPath("//p[@class='story-body__introduction']", 0).GetAttribute("InnerHtml");
string strContext = ZennoPoster.ContextRecognition(strText, "general", 5, 10);
project.SendInfoToLog("Выполнено. Распознанные тематики текста: " + strContext);

//Примечания:
//1. Параметры метода ContextRecognition:
//  первый - текст для распознавания тематики (контекста)
//  второй - типы тематик. варианты значения: general или detailed. detailed пока не поддерживается (так написано в документации)
//  третий - максимальное количество возвращаемых тематик
//  четвёртый - релевантность текста тематике (до 100)