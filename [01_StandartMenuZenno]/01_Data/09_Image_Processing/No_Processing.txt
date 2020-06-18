//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="http://zennolab.com/discussion/") {
	Tab1.Navigate("http://zennolab.com/discussion/");
	Tab1.WaitDownloading();
}

//сохраняем скриншот инстанса
string strResultImagePath = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance.png"; //создаём переменную, содержащую путь к файлу с сохранённым изображением инстанса
File.WriteAllBytes(strResultImagePath, Convert.FromBase64String(instance.ActiveTab.FindElementByTag("html", 0).DrawToBitmap(false)));

project.SendInfoToLog("Скриншот инстанса сохранён: " + strResultImagePath);

//сохраняем картинку по URL
string strImageURL = "http://zennolab.com/discussion/styles/Eloquent/xenforo/logo1.png";
string strResultImageFolder = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\"; //создаём переменную, содержащую путь к файлу с сохранённым изображением инстанса
instance.DownloadsPath = strResultImageFolder;
string strDownloadResult = ZennoPoster.HttpGet(strImageURL,"","UTF-8",ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.File,5000);

project.SendInfoToLog("Изображение сохранено: " + strDownloadResult);

//Примечания:
//1. Изображение инстанса сохраняется в формате .png независимо от разрешения
//2. Перед запуском кода сохранения изображения инстанса перейдите вручную на какой-нибудь сайт (например, https://fotki.yandex.ru/next/)
//3. Если файл, путь к которому указан в переменной strResultImagePath, уже существует в системе - при сохранении изображения инстанса он будет перезаписан.
//4. Если файл с именем, совпадающим с именем сохраняемого при помощи HttpGet файла уже существует в системе - сохраняемый файл будет автоматиески переименован.