HtmlElement he = instance.ActiveTab.FindElementByAttribute("a", "class", "fi\\ fi-photos\\ bb", "regexp", 0);
if (he.IsVoid) return null;