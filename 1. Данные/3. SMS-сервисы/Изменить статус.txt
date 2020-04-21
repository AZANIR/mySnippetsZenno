//Сразу после выполнения это сниппета заполните номер телефона и нажмите "Получить код". Затем без промедлений переходите к следующему сниппету "Получить статус"

string strRegistrationID = project.Variables["str_registration_id"].Value; //получаем ID регистрации из переменной уровня проекта.

//ZennoPoster.Sms.SetStatus: устанавливаем статус операции смс-сервиса
string strSetStatusResult = ZennoPoster.Sms.SetStatus("SmsActivate.dll", strRegistrationID, InterfacesLibrary.SmsService.Enums.SmsServiceStatus.Ready);
if (strSetStatusResult=="Ready") {
	project.SendInfoToLog("Теперь смс-сервис ждёт получения смс на полученный ранее номер");
}else{
	project.SendInfoToLog("Сбой в работе сервиса, сервис не готов принять СМС");
}

//Примечания:
//1. Атрибуты метода ZennoPoster.Sms.SetStatus:
//	первый - имя dll-библиотеки смс-сервиса (смотрите примечание №3);
//	второй - id регистрации, полученный на шаге запроса номера телефона;
//	третий - Перечисление InterfacesLibrary.SmsService.Enums.SmsServiceStatus для выбора статуса, который мы хотим передать сервису. Все статусы:
//		Cancel - отмена активации;
//		Close - закрыть (close) активацию;
//		Ready - На номер вскоре придёт смс с кодом от сервиса, указанного на этапе получения номера;
//		RetryGet - Необходимо принять ещё один другой код подтверждения от того же сервиса;
//		Used - номер, полученный на первом шаге, уже использовался для регистрации на этом сервисе.

//2. Перед запуском кода не забудьте прописать API-ключ или логин+пароль для смс-сервиса;
//3. ZennoPoster поддерживает три сервиса для смс-активаций: 
//		sms-activate.ru (библиотека SmsActivate.dll, описание API: http://sms-activate.ru/index.php?act=api);
//		sms-reg.com (библиотека SmsReg.dll, описание API: http://sms-reg.com/docs/API.html);
//		smsvk.net (библиотека SmsVk.dll, описание API: http://smsvk.net/api.html).
//4. По работе с смс-сервисами будет отдельный подробный подкурс, в котором будут рассмотрены все варианты команд.