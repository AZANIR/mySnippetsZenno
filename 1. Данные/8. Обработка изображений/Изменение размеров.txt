//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="http://zennolab.com/discussion/") {
	Tab1.Navigate("http://zennolab.com/discussion/");
	Tab1.WaitDownloading();
}

//изменяем размеры скриншота, с указанием размеров в пикселах
string strResultImagePath1 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_resize_pixel.jpg";
ZennoPoster.ImageProcessingResizeFromScreenshot(instance.Port, strResultImagePath1, 350, 250, "pixel", true, false, 100);

//изменяем размеры скриншота, с указанием размеров в процентах
string strResultImagePath2 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_resize_percent.jpg";
ZennoPoster.ImageProcessingResizeFromScreenshot(instance.Port, strResultImagePath2, 50, 40, "percent", true, false, 100);

//изменяем размеры изображения из URL (пример - только в пикселах, проценты - по аналогии с изменением размера скриншота)
string strImageURL = "http://zennolab.com/discussion/styles/Eloquent/xenforo/logo1.png";
string strResultImagePath3 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\url_resize_pixel.jpg";
ZennoPoster.ImageProcessingResizeFromUrl(strImageURL, strResultImagePath3, 500, 250, "pixel", true, true);

//изменяем размеры изображения из файла (пример - только в пикселах, проценты - по аналогии с изменением размера скриншота)
string strSourceImagePath = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\night_silence.jpg";
string strResultImagePath4 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\file_resize_pixel.jpg";
ZennoPoster.ImageProcessingResizeFromFile(strSourceImagePath, strResultImagePath4, 500, 250, "pixel", true, false);

project.SendInfoToLog(@"Проверьте результат выполнения в папке Вспомогательные файлы\Картинки\Результат");

//Примечания:
//1. Параметры ImageProcessingResizeFromScreenshot:
//	первый: порт инстанса;
//	второй: путь сохранения картинки;
//	третий: размер по горизонтали;
//	четвёртый: размер по вертикали;
//	пятый: единицы измерения (pixel/percent);
//	шестой: сохранять ли соотношение сторон картинки (true/false);
//	седьмой: уменьшать ли изображение при необходимости (true/false);
//	восьмой: качество изображения в процентах (по умолчанию 100).
//2. Параметры для ImageProcessingResizeFromUrl, ImageProcessingResizeFromFile формируются аналогично ImageProcessingResizeFromScreenshot (кроме первого параметра).
//3. Если файлы для размещения результата уже существуют - они будут перезаписаны.