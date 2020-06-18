//Поля профиля содержат информацию как о характеристиках браузера
//(эта информация может быть получена скриптами сайтов, с которыми вы
//будете работать), так и о "виртуальной личности", от имени которой будет
//работать бот.

//AcceptCharset - набор символов (допустимые кодировки), с которыми работает браузер профиля
//project.Profile.AcceptCharset = "iso-8859-1,*,utf-8";
project.SendInfoToLog("Profile.AcceptCharset: " + project.Profile.AcceptCharset);

//AcceptEncoding - типы сжатия данных при передаче, с которыми работает браузер профиля
//project.Profile.AcceptEncoding = "gzip, deflate";
project.SendInfoToLog("Profile.AcceptEncoding: " + project.Profile.AcceptEncoding);

//AcceptLanguage - предпочитаемая языковая локаль сайтов (языки, с которыми работает браузер профиля)
//project.Profile.AcceptLanguage = "en-US,en;q=0.5";
project.SendInfoToLog("Profile.AcceptLanguage: " + project.Profile.AcceptLanguage);

//Age - возраст "виртуальной личности" профиля
//project.Profile.Age = 25;
project.SendInfoToLog("Profile.Age: " + project.Profile.Age);
//ВНИМАНИЕ! При изменении значения свойства Age значение свойства BornYear (год рождения)
//автоматически не меняется! (информация актуальна для версии 5.9.9.1)

//AvailScreenHeight - доступная высота экрана (не включает в себя высоту таскбара Windows)
//project.Profile.AvailScreenHeight = 752;
project.SendInfoToLog("Profile.AvailScreenHeight: " + project.Profile.AvailScreenHeight);
//По умолчанию на всех машинах возвращает значение 50505 (информация актуальна для версии 5.9.9.1)

//AvailScreenWidth - доступная ширина экрана (не включает в себя ширину вертикального таскбара Windows)
//project.Profile.AvailScreenWidth = 1018;
project.SendInfoToLog("Profile.AvailScreenWidth: " + project.Profile.AvailScreenWidth);
//По умолчанию на всех машинах возвращает значение 50505 (информация актуальна для версии 5.9.9.1)

//BornDay - день рождения "виртуальной личности" профиля (только ДЕНЬ)
//project.Profile.BornDay = 5;
project.SendInfoToLog("Profile.BornDay: " + project.Profile.BornDay);
//Можно написать как 5, так и 05 - ошибки не будет

//BornDay - день рождения "виртуальной личности" профиля (только ДЕНЬ)
//project.Profile.BornDay = 5;
project.SendInfoToLog("Profile.BornDay: " + project.Profile.BornDay);
//Можно написать как 5, так и 05 - ошибки не будет

//BornDay - месяц рождения "виртуальной личности" профиля (цифрой)
//project.Profile.BornMonth = 5;
project.SendInfoToLog("Profile.BornMonth: " + project.Profile.BornMonth);
//Можно написать как 5, так и 05 - ошибки не будет
//Если попытаться присвоить строковое значение (например, "Май") - будет возвращена ошибка:
//"Неявное преобразование типа string в int невозможно"

//BornYear - год рождения "виртуальной личности" профиля
//project.Profile.BornYear = 2008;
project.SendInfoToLog("Profile.BornYear: " + project.Profile.BornYear);

//Country - страна местонахождения "виртуальной личности" профиля
//project.Profile.Country = "USA";
project.SendInfoToLog("Profile.Country: " + project.Profile.Country);

//Email - e-mail "виртуальной личности" профиля
//project.Profile.Email = "test@test.ru";
project.SendInfoToLog("Profile.Email: " + project.Profile.Email);

//EmailPassword - пароль для использования при проверке адреса электронной почты
//project.Profile.EmailPassword = "BlaBlaBla";
project.SendInfoToLog("Profile.EmailPassword: " + project.Profile.EmailPassword);

//HTTPAccept - типы контента, принимаемые браузером профиля
//project.Profile.HTTPAccept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
project.SendInfoToLog("Profile.HTTPAccept: " + project.Profile.HTTPAccept);

//Language - код основного языка "виртуальной личности" профиля
//project.Profile.Language = "en";
project.SendInfoToLog("Profile.Language: " + project.Profile.Language);

//Login - основной логин, используемый для работы с сервисами от имени данного профиля
//project.Profile.Login = "Testirator";
project.SendInfoToLog("Profile.Login: " + project.Profile.Login);

//Name - имя "виртуальной личности" профиля
//project.Profile.Name = "Иннокентий";
project.SendInfoToLog("Profile.Name: " + project.Profile.Name);

//NickName - ник "виртуальной личности" профиля
//project.Profile.NickName = "ke$haXXX";
project.SendInfoToLog("Profile.NickName: " + project.Profile.NickName);

//OuterHeightShift - внешняя высота окна браузера вместо с заголовком (http://www.w3schools.com/jsref/prop_win_outerheight.asp)?
//project.Profile.OuterHeightShift = 110;
project.SendInfoToLog("Profile.OuterHeightShift: " + project.Profile.OuterHeightShift);

//OuterHeightShift - внешняя ширина окна браузера вместе с полосой прокрутки (http://www.w3schools.com/jsref/prop_win_outerheight.asp)?
//project.Profile.OuterWidthShift = 16;
project.SendInfoToLog("Profile.OuterWidthShift: " + project.Profile.OuterWidthShift);

//Password - пароль профиля для работы с сервисами
//project.Profile.Password = "K4Shh@";
project.SendInfoToLog("Profile.Password: " + project.Profile.Password);

//CurrentRegion - регион "виртуальной личности" профиля
//project.Profile.CurrentRegion = "Texas";
project.SendInfoToLog("Profile.CurrentRegion: " + project.Profile.CurrentRegion);
//ВНИМАНИЕ! При изменении значения свойства Country(страна) значение свойства CurrentRegion (регион)
//автоматически не меняется (и наоборот)! (информация актуальна для версии 5.9.9.1)

//ScreenLeft - расстояние в пискелах от левой границы экрана до левой границы окна браузера
//project.Profile.ScreenLeft = -8;
project.SendInfoToLog("Profile.ScreenLeft: " + project.Profile.ScreenLeft);

//ScreenSizeHeight - высота окна браузера в пикселах
//project.Profile.ScreenSizeHeight = 50505;
project.SendInfoToLog("Profile.ScreenLeft: " + project.Profile.ScreenLeft);
//По умолчанию на всех машинах возвращает значение 50505 (информация актуальна для версии 5.9.9.1)

//ScreenSizeHeight - ширина окна браузера в пикселах
//project.Profile.ScreenSizeWidth = 50505;
project.SendInfoToLog("Profile.ScreenSizeWidth: " + project.Profile.ScreenSizeWidth);
//По умолчанию на всех машинах возвращает значение 50505 (информация актуальна для версии 5.9.9.1)

//ScreenTop - расстояние в пискелах от верхней границы экрана до верхней границы окна браузера
//project.Profile.ScreenTop = -8;
project.SendInfoToLog("Profile.ScreenTop: " + project.Profile.ScreenTop);

//SecretQuestionAnswer1 - ответ на "секретный вопрос №1" для использования при работе с сервисами
//project.Profile.SecretQuestionAnswer1 = "Яичница";
project.SendInfoToLog("Profile.SecretQuestionAnswer1: " + project.Profile.SecretQuestionAnswer1);

//SecretQuestionAnswer2 - ответ на "секретный вопрос №2" для использования при работе с сервисами
//project.Profile.SecretQuestionAnswer2 = "Иванова";
project.SendInfoToLog("Profile.SecretQuestionAnswer2: " + project.Profile.SecretQuestionAnswer2);

//Sex - пол "виртуальной личности" профиля
//project.Profile.Sex = ProfileSex.Male; //мужской пол
//project.Profile.Sex = ProfileSex.Female; //женский пол
project.SendInfoToLog("Profile.Sex: " + project.Profile.Sex);

//Surname - фамилия "виртуальной личности" профиля
//project.Profile.Surname = "Иннокентий";
project.SendInfoToLog("Profile.Surname: " + project.Profile.Surname);

//Town - город проживания "виртуальной личности" профиля
//project.Profile.Town = "Novosibirsk";
project.SendInfoToLog("Profile.Town: " + project.Profile.Town);

//UserAgent - заголовок "userAgent" браузера профиля (http://www.w3schools.com/jsref/prop_nav_useragent.asp)
//project.Profile.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
project.SendInfoToLog("Profile.UserAgent: " + project.Profile.UserAgent);

//UserAgentAppCodeName - заголовок "appCodeName" браузера профиля (http://www.w3schools.com/jsref/prop_nav_appcodename.asp)
//project.Profile.UserAgentAppCodeName = "Mozilla";
project.SendInfoToLog("Profile.UserAgentAppCodeName: " + project.Profile.UserAgentAppCodeName);

//UserAgentAppName - заголовок "appName" браузера профиля (http://www.w3schools.com/jsref/prop_nav_appname.asp)
//project.Profile.UserAgentAppName = "Netscape";
project.SendInfoToLog("Profile.UserAgentAppName: " + project.Profile.UserAgentAppName);

//UserAgentAppVersion - заголовок "appVersion" браузера профиля (http://www.w3schools.com/jsref/prop_nav_appversion.asp)
//project.Profile.UserAgentAppVersion = "5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";
project.SendInfoToLog("Profile.UserAgentAppVersion: " + project.Profile.UserAgentAppVersion);

//UserAgentCpuClass - разрядность браузера профиля
//project.Profile.UserAgentCpuClass = "x86";
//project.Profile.UserAgentCpuClass = "x64";
project.SendInfoToLog("Profile.UserAgentCpuClass: " + project.Profile.UserAgentCpuClass);

//UserAgentOsCpu - операционная система, разрядность ОС
//project.Profile.UserAgentOsCpu = "Windows NT 6.1; WOW64";
project.SendInfoToLog("Profile.UserAgentOsCpu: " + project.Profile.UserAgentOsCpu);

//UserAgentPlatform - платформа, для которой был скомпилирован браузер - заголовок "platform" браузера профиля (http://www.w3schools.com/jsref/prop_nav_platform.asp)
//project.Profile.UserAgentPlatform = "Win32";
project.SendInfoToLog("Profile.UserAgentPlatform: " + project.Profile.UserAgentPlatform);

//UserAgentProduct - заголовок "product" браузера профиля (http://www.w3schools.com/jsref/prop_nav_product.asp)
//project.Profile.UserAgentProduct = "Gecko";
project.SendInfoToLog("Profile.UserAgentProduct: " + project.Profile.UserAgentProduct);

//UserAgentProductSub - заголовок "productSub" браузера профиля (https://developer.mozilla.org/ru/docs/Web/API/Navigator/productSub)
//project.Profile.UserAgentProductSub = "20100101";
project.SendInfoToLog("Profile.UserAgentProductSub: " + project.Profile.UserAgentProductSub);

//ZipCode - почтовый индекс "виртуальной личности" профиля
//project.Profile.ZipCode = "630099";
project.SendInfoToLog("Profile.ZipCode: " + project.Profile.ZipCode);

//Ссылки для изучения:
//https://en.wikipedia.org/wiki/User_agent
//http://www.w3schools.com/jsref/obj_navigator.asp
//https://developer.mozilla.org/en-US/docs/Web/API/Navigator
//https://msdn.microsoft.com/en-us/library/ms537503(v=vs.85).aspx
//https://whoer.net/ru
//https://2ip.ru/
//http://yandex.ru/internet/