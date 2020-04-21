//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="http://zennolab.com/discussion/") {
	Tab1.Navigate("http://zennolab.com/discussion/");
	Tab1.WaitDownloading();
}

//отражаем скриншот
string strResultImagePath1 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_mirror.jpg";
ZennoPoster.ImageProcessingMirrorFromScreenshot(instance.Port, strResultImagePath1, "Horizontal", 100);

//отражаем изображение из URL
string strImageURL = "http://zennolab.com/discussion/styles/Eloquent/xenforo/logo1.png";
string strResultImagePath3 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\url_mirror.jpg";
ZennoPoster.ImageProcessingMirrorFromUrl(strImageURL, strResultImagePath3, "Vertical", 100);

//отражаем изображение из файла
string strSourceImagePath = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\night_silence.jpg";
string strResultImagePath4 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\file_mirror.jpg";
ZennoPoster.ImageProcessingMirrorFromFile(strSourceImagePath, strResultImagePath4, "HorizontalVertical", 100);

project.SendInfoToLog(@"Проверьте результат выполнения в папке Вспомогательные файлы\Картинки\Результат");

ZennoPoster.ImageProcessingMirrorFromScreenshot(instance.Port, strResultImagePath1, "Horizontal", 100);

//Примечания:
//1. Параметры ImageProcessingMirrorFromScreenshot:
//	первый: порт инстанса;
//	второй: путь сохранения картинки;
//	третий: тип отражения. Варианты: "Horizontal" (горизонтальное отражение), "Vertical" (вертикальное отражение), "HorizontalVertical" (горизональное и вертикальное отражение)
//	четвёртый: качество получаемого изображения в процентах (по умолчанию 100).
//2. Параметры для ImageProcessingMirrorFromUrl, ImageProcessingMirrorFromFile формируются аналогично ImageProcessingMirrorFromScreenshot (кроме первого параметра).
//3. Если файлы для размещения результата уже существуют - они будут перезаписаны.