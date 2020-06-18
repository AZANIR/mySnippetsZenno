//Перед выполнением этого сниппета заполните номер телефона и нажмите "Получить код" (пройдите шаги "Получить номер" и "Изменить статус").

string strRegistrationID = project.Variables["str_registration_id"].Value; //получаем ID регистрации из переменной уровня проекта.
//ZennoPoster.Sms.GetStatus: получаем текущий статус смс-сервиса (в данном случае он будет содержать код подтверждения или сообщение об ошибке)
string strConfirmationCode = ZennoPoster.Sms.GetStatus("SmsActivate.dll", strRegistrationID);

project.SendInfoToLog("Получен код подтверждения: " + strConfirmationCode);

//Примечания:
//1. Атрибуты метода ZennoPoster.Sms.GetStatus:
//	первый - имя dll-библиотеки смс-сервиса (смотрите примечание №3);
//	второй - id регистрации, полученный на шаге запроса номера телефона;

//2. Статус можно получить множество раз
//3. Перед запуском кода не забудьте прописать API-ключ или логин+пароль для смс-сервиса;
//4. ZennoPoster поддерживает три сервиса для смс-активаций: 
//		sms-activate.ru (библиотека SmsActivate.dll, описание API: http://sms-activate.ru/index.php?act=api);
//		sms-reg.com (библиотека SmsReg.dll, описание API: http://sms-reg.com/docs/API.html);
//		smsvk.net (библиотека SmsVk.dll, описание API: http://smsvk.net/api.html).
//5. По работе с смс-сервисами будет отдельный подробный подкурс, в котором будут рассмотрены все варианты команд.