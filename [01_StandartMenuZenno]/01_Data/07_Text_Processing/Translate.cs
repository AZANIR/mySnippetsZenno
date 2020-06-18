//объявляем переменную, содержащую текст для перевода
string strSource = "Hi comaraden, my english is very very supergood! :)";

//Macros.TextProcessing.Translate: переводим текст
string strResult = Macros.TextProcessing.Translate("YandexTranslate.dll", strSource, "ru", "en");

project.SendInfoToLog("Результат перевода: " + strResult);

//Примечания
//1. Не забудьте прописать API-ключ сервиса перевода в настройкаъ ProjectMaker/ZennoPoster (Настройки-Переводчики)

//2. Как получать API-ключи сервисов перевода:
//Baidu Translate:
//Инструкция по получению ключа - http://wp-autopost.net/manual/how-to-apply-baidu-translator-api-key/
//Похоже что теперь при регистрации вместо почты требуется китайский номер телефона. Кто найдёт годную инструкцию - поделитесь.
//
//Google:
//Бесплатная пробная версия сервиса (дают $300 на баланс при регистрации) - https://console.cloud.google.com/billing/freetrial?_ga=1.56377515.1482634570.1463411489
//
//Microsoft:
//Приобретение ключа (до 2 млн. символов в месяц - бесплатно) - http://datamarket.azure.com/dataset/bing/microsofttranslator
//
//Яндекс:
//Получение ключа - https://tech.yandex.ru/key/form.xml?service=trnsl
//Документация - https://tech.yandex.ru/translate/doc/dg/concepts/api-overview-docpage/