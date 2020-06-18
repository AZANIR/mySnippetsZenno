//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="https://passport.yandex.ru/registration/") {
	Tab1.Navigate("https://passport.yandex.ru/registration/");
	Tab1.WaitDownloading();
}

string strPhoneNumber;
//ZennoPoster.Sms.GetNumber: получаем номер телефона и код регистрации для дальнейшей работы
string strRegistrationID = ZennoPoster.Sms.GetNumber("SmsActivate.dll", out strPhoneNumber, "ya", "any");
//Сохраняем полученные данные в переменных проекта для использования в следующих сниппетах
project.Variables["str_registration_id"].Value=strRegistrationID;
project.Variables["str_phone_number"].Value=strPhoneNumber;
project.SendInfoToLog(String.Format("Получен телефонный номер: {0}, id регистрации: {1}.", strPhoneNumber, strRegistrationID));

//Примечания:
//1. Атрибуты метода ZennoPoster.Sms.GetNumber:
//	первый - имя dll-библиотеки смс-сервиса (смотрите примечание №3);
//	второй - имя переменной, в которую будет помещён полученный номер телефона;
//	третий - кодовое название сервиса, на котором мы проходим регистрацию. Перечень кодовых обозначений смотрите в документации API сервиса (примечание №3)
//	четвёртый - регион оператора, к которому должен относиться полученный номер. "any" - любой оператор.
//2. Перед запуском кода не забудьте прописать API-ключ или логин+пароль для смс-сервиса;
//3. ZennoPoster поддерживает три сервиса для смс-активаций: 
//		sms-activate.ru (библиотека SmsActivate.dll, описание API: http://sms-activate.ru/index.php?act=api);
//		sms-reg.com (библиотека SmsReg.dll, описание API: http://sms-reg.com/docs/API.html);
//		smsvk.net (библиотека SmsVk.dll, описание API: http://smsvk.net/api.html).
//4. По работе с смс-сервисами будет отдельный подробный подкурс, в котором будут рассмотрены все варианты команд.