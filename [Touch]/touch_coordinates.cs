var tab = instance.ActiveTab;
var rnd = new Random();
HtmlElement el = tab.FindElementByAttribute("тэг", "имя атрибута", "значение", "regexp", 0); // ищем элемент
int elX = el.DisplacementInTabWindow.X; // находим "leftinbrowser"
int elY = el.DisplacementInTabWindow.Y; // находим "topinbrowser"
int elWidth = el.Width; // ширина элемента
int elHeight = el.Height; // высота элемента
int elCrdX = rnd.Next(elX, elX + elWidth); // вычисляем рандом координаты по Х в пределах элемента
int elCrdY = rnd.Next(elY, elY + elHeight); // вычесляем рандом координаты по У в пределах элемента
tab.Touch.Touch(elCrdX, elCrdY); // выполняем тач по коорд.
// если вам нужно чтобы область была сильно меньше чем сам элемент,
// в таком случае в rnd.Next(elX, elX + elWidth) плюсуйте к leftinbrowser - elX нужное кол-во пикселей
// например rnd.Next(elX + 50, elX + elWidth - 50) что по оси Х слева прибавит 50px а справа отнимет 50рх
// то же самое с осью У, но сильно не переусердствуйте, потому что если minValue будет больше maxValue вывалится ошибкой