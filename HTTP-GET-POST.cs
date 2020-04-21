string token = project.Variables["access_token"].Value; // положить acces token из проекта в переменную token
var response = ZennoPoster.HTTP.Request(
ZennoLab.InterfacesLibrary.Enums.Http.HttpMethod.POST, // тип запроса
"https://api.***.com/v2/me/mail/address/", // адрес
"email=rraetbfpmbj%40dropmail.me&", // контент запроса
"application/x-www-form-urlencoded",  // тип контента
"",  // тут можно прокси прописать
"UTF-8", // кодировка
ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.HeaderAndBody, // что получать в ответ
30000, // таймаут
"", // куки
"Android 4.11.1 (GooglePlay;Free)", // юзерагент
true, //разрешить редиректы
5, //количество редиректов
    new[] {
     "Device-Id: eyJhaWQiOiIzYTMyYzg2OTE4Mjc4MDI0IiwiaSI6Ijg2NzA2NDA2MDU4MzIyNCIsInMiOiI4NjkxODI3ODAyNDNhMzJjIn0=",
     "Authorization: Bearer " + token,
     "Connection: keep-alive",
     "Accept-Encoding: gzip, deflate"
  } // дополнительные заголовки
);
return response; // положить ответ в переменную