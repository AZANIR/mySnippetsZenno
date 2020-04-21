//токен бота получаете его у @BotFather
string strToken = "468555369:AAFlAr8zrT6FXPXedmKWD_mauKBNQzI4E1M";
//чат айди или имя чата но тогда с strChatId = "@463720106";
string strChatId = "463720106";
//картинка путь //нужно проэкспериментировать с урлом картинки.
string img = "C:/1.jpg";//"C:/1.png"
string img_url = "https://i.imgur.com/vvZnHnK.png";
string smile = "%E2%9C%85";// ok %E2%9C%85
//текст который отсылаем в телегу поддерживается форматированние текста HTML
string text = "Test, простая проверка гет запроса.\n<i>Another text</i>\n<b>Тут жирный текст</b>\n<pre>Тут просто текст</pre>\n<a href=\"https://artstroy.net\">Moy sait</a>"+" "+smile;
//текст2 
string text2 = "Test, простая проверка гет запроса.\n__Another text__\n**Тут жирный текст**\n`Тут просто текст`\n[Moy sait](https://artstroy.net)";
//url
string url_link = "[Вам Телеграм](http://www.vamtlgrm.com)";
/*
разметка Markdown
1. Чтобы выделить слово жирным, нужно с двух сторон поставить по две звездочки.
Пишем **Привет** — получаем Привет.
2. Для выбора наклонного шрифта, нужно вместо звездочек поставить по два нижних подчеркивания.
Пишем __Привет__ — получаем Привет.
3. Чтобы получить моноширный однострочный шрифт (написать им вы сможете только в одну строку), нужно выделить слово грифисом. Кстати на смартфонах, при нажатии на такой текст он копируется в буфер обмена автоматически.
Пишем `Привет` — получаем Привет
4. Моноширный многострочный нужно выделить тремя грифисами с двух сторон.
` ` `Привет      —    Привет
Как дела?` ` `         Как дела?
Кроме того, в клиенте Telegram X еще есть возможность ставить гиперссылки. Для этого нужно вввести такую конструкцию: [Текст](Ссылка)
Пишем [Moy sait](https://artstroy.net) — получаем Вам Телеграм.
*/

/*
разметка Html
1. Чтобы выделить слово жирным, нужно с двух сторон поставить по две звездочки.
Пишем <b>Привет</b> — получаем Привет.
2. Для выбора наклонного шрифта, нужно вместо звездочек поставить по два нижних подчеркивания.
Пишем <i>Привет</i> — получаем Привет.
3. Чтобы получить моноширный однострочный шрифт (написать им вы сможете только в одну строку), нужно выделить слово грифисом. Кстати на смартфонах, при нажатии на такой текст он копируется в буфер обмена автоматически.
Пишем <code>Привет</code> — получаем Привет
4. Моноширный многострочный нужно выделить тремя грифисами с двух сторон.
<pre>Привет      —    Привет
Как дела?</pre>         Как дела?
Кроме того, в клиенте Telegram X еще есть возможность ставить гиперссылки. Для этого нужно вввести такую конструкцию: [Текст](Ссылка)
Пишем <a href="https://artstroy.net">Moy sait</a>) — получаем Вам Телеграм.
*/

//Режим разметки текста //"&parse_mode=Markdown" //"&parse_mode=html"
string mode = "&parse_mode=html";
string mode2 = "&parse_mode=Markdown";

//картинка без описания
string data = "";
data += "--8d769bc78125cd4\n";
data += string.Format("Content-Disposition: form-data; name=\"document\"; filename=\"{0}\"\n", img);
data += "Content-Type: application/octet-stream\n";
data += img;

//постим в телегу скриншот url картинки в нете 
ZennoPoster.HttpGet("https://api.telegram.org/bot"+strToken+"/sendPhoto?chat_id="+strChatId+"&photo="+img_url,
		"", "UTF-8", ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.BodyOnly);
//постим в телегу сообщение
ZennoPoster.HttpGet("https://api.telegram.org/bot"+strToken+"/sendMessage?chat_id="+strChatId+"&text="+text+mode,
		"", "UTF-8", ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.BodyOnly);	
//картинка безописания
string resRequest = ZennoPoster.HttpPost(
    "https://api.telegram.org/bot" + strToken + "/sendDocument?chat_id=" + strChatId,
    data,
    "multipart/form-data","","UTF-8",ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.HeaderAndBody,
    30000,"","Mozilla/5.0 (Windows NT 10.0; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0",true,5,
	new[] {"Host: api.telegram.org"});
//картинка с описанием
string resRequest2 = ZennoPoster.HttpPost(
"https://api.telegram.org/bot" + strToken + "/sendDocument?chat_id=" + strChatId+"&caption="+text2+url_link+mode2,
data,
"multipart/form-data","","UTF-8",ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.HeaderAndBody,
30000,"","Mozilla/5.0 (Windows NT 10.0; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0",true,5,
new[] {"Host: api.telegram.org"});