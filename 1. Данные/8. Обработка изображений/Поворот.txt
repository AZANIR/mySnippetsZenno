//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="http://zennolab.com/discussion/") {
	Tab1.Navigate("http://zennolab.com/discussion/");
	Tab1.WaitDownloading();
}

//поворачиваем скриншот
string strResultImagePath1 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_rotate.jpg";
ZennoPoster.ImageProcessingRotateFromScreenshot(instance.Port, strResultImagePath1, 40, 100);

//поворачиваем изображение из URL
string strImageURL = "http://zennolab.com/discussion/styles/Eloquent/xenforo/logo1.png";
string strResultImagePath3 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\url_rotate.jpg";
ZennoPoster.ImageProcessingRotateFromUrl(strImageURL, strResultImagePath3, 40, 100);

//поворачиваем изображение из файла
string strSourceImagePath = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\night_silence.jpg";
string strResultImagePath4 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\file_rotate.jpg";
ZennoPoster.ImageProcessingRotateFromFile(strSourceImagePath, strResultImagePath4, 40, 100);

project.SendInfoToLog(@"Проверьте результат выполнения в папке Вспомогательные файлы\Картинки\Результат");

//Примечания:
//1. Параметры ImageProcessingRotateFromScreenshot:
//	первый: порт инстанса;
//	второй: путь сохранения картинки;
//	третий: угол для поворота (может быть как положительным, так и отрицательным числом);
//	четвёртый: качество получаемого изображения в процентах (по умолчанию 100).
//2. Параметры для ImageProcessingRotateFromUrl, ImageProcessingRotateFromFile формируются аналогично ImageProcessingRotateFromScreenshot (кроме первого параметра).
//3. Если файлы для размещения результата уже существуют - они будут перезаписаны.