/*
	получение и установка прокси ( в инстанс и переменную "proxy")
	с проверкой на пустой список проксей (незабудьте создать список с именем "Proxy" и привязать к файлу "proxy.txt")
	с сервиса Бест прокси (http://api.best-proxies.ru/proxylist.txt?key=6f067a5e9c42fee3d73afd6f511bcbf6&speed=1&type=socks5&level=1&limit=0&includeType)
*/ 
int query_count = 0;
string resultGet = string.Empty;

if(project.Lists["Proxy"].Count == 0)
{
	//делаем запрос к сайту для получения прокси
	while(resultGet==""){
		resultGet = ZennoPoster.HttpGet(
			"http://api.best-proxies.ru/proxylist.txt?key=6f067a5e9c42fee3d73afd6f511bcbf6&speed=1&type=socks5&level=1&limit=0&includeType",
			"","UTF-8",ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.BodyOnly);
		System.Threading.Thread.Sleep(2000);
		if (++query_count>=5 && resultGet=="")
			throw new Exception("[Запрос: пустой ответ при парсинге 5 раз(а) подряд]");
	}
	// Обработка текста "В список"
	Macros.TextProcessing.ToList(resultGet, @"{-String.Enter-}", "Text", project, project.Lists["Proxy"]);
	project.Lists["Proxy"].Distinct();
}
//установка прокси 
project.Variables["proxy"].Value = project.Lists["Proxy"][0];
instance.SetProxy(project.Variables["proxy"].Value);
project.Lists["Proxy"].RemoveAt(0);