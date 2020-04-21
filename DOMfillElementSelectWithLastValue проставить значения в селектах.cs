//http://zennolab.com/discussion/threads/snipet-zapolnenija-vsex-select-na-stranice-poslednim-znacheniem.8841/#post50539

// получаем вкладку по заголовку
Tab tab = instance.GetTabByAddress(project.Variables["Caption"].Value);
// если указанная вкладка существует
if (!tab.IsVoid && !tab.IsNull)
{
    // если страница не загрузилась, подождём загрузки
    if (tab.IsBusy) tab.WaitDownloading();
    // ищем все с select на странице
    HtmlElementCollection heCol = tab.FindElementsByTags("select");
    // пройдём по всем select и заполним их
    foreach(HtmlElement he in heCol.Elements)
    {
        // найдём все элементы списка
        HtmlElementCollection children = he.FindChildrenByTags("option");
        // если элементы есть
        if (children.Count > 0)
        {
            // получаем последний элемент списка
            HtmlElement c = children.Elements[children.Count-1];
            // если элемент не пуст
            if (!c.IsVoid)
            {
                // получим значение элемента
                string outerText = c.GetAttribute("outertext");
                // установим значение
                he.SetSelectedItems(outerText);
                // задержка эмуляции
                instance.WaitFieldEmulationDelay();
            }
        }