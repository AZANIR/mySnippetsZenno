string strSiteURL = "https://lenta.ru/";
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!=strSiteURL){
	Tab1.Navigate(strSiteURL);
	Tab1.WaitDownloading();
}

string strMainArticleContent = instance.ActiveTab.MainPageArticle;
File.WriteAllText(project.Directory + @"\MainArticle.txt", strMainArticleContent);

project.SendInfoToLog("Выполнено. Проверьте файл MainArticle.txt в папке проекта.");