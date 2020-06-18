//объявляем необходимые переменные
Tab Tab1 = instance.ActiveTab;
string strPhoneNumber = String.Empty;
string strConfirmationCode = String.Empty;

//получаем номер телефона и id регистрации
string strRegistrationID = ZennoPoster.Sms.GetNumber("SmsActivate.dll", out strPhoneNumber, "ya", "any");
project.SendInfoToLog("Получен телефонный номер: " + strPhoneNumber);

//сообщаем сервису, что в ближайшие 2 минуты на номер придёт смс от указанного нами сервиса
string strSetStatusResult = ZennoPoster.Sms.SetStatus("SmsActivate.dll", strRegistrationID, InterfacesLibrary.SmsService.Enums.SmsServiceStatus.Ready);

//получаем код подтверждения или сообщаем об ошибке
if (strSetStatusResult=="Ready") {
	//заполняем номер телефона в поле и нажимаем "Получить код"
	Tab1.FindElementByXPath("//input[@name='phone_number']", 0).SetValue(strPhoneNumber, instance.EmulationLevel);
	Tab1.FindElementByXPath("//span[contains(text(), 'Получить код')]/ancestor::button", 0).Click();
	//здесь можно сделать дополнительное ожидание, но работает и так.
	strConfirmationCode = ZennoPoster.Sms.GetStatus("SmsActivate.dll", strRegistrationID);
	
}else{
	project.SendInfoToLog("Произошла ошибка. Сервис смс-активации не готов");
	return null;
}

//Заполняем поле кодом подтверждения
Tab1.FindElementByXPath("//input[contains(@class,'code_entry')]", 0).SetValue(strConfirmationCode, instance.EmulationLevel);
project.SendInfoToLog("Получен код подтверждения: " + strConfirmationCode);