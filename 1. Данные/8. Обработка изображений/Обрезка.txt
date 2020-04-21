//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="http://zennolab.com/discussion/") {
	Tab1.Navigate("http://zennolab.com/discussion/");
	Tab1.WaitDownloading();
}

//обрезаем скриншот, с указанием размеров в пикселах
string strResultImagePath1 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_crop_pixel.jpg";
ZennoPoster.ImageProcessingCropFromScreenshot(instance.Port, strResultImagePath1, 40, 150, 200, 300, "pixel", 100);

//обрезаем скриншот, с указанием размеров в процентах
string strResultImagePath2 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_crop_percent.jpg";
ZennoPoster.ImageProcessingCropFromScreenshot(instance.Port, strResultImagePath2, 40, 150, 30, 5, "percent", 100);

//обрезаем изображение из URL (пример - только в пикселах, проценты - по аналогии с обрезкой скриншота)
string strImageURL = "http://zennolab.com/discussion/styles/Eloquent/xenforo/logo1.png";
string strResultImagePath3 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\url_crop_pixel.jpg";
ZennoPoster.ImageProcessingCropFromUrl(strImageURL, strResultImagePath3, 20, 20, 30, 20, "pixel", 100);

//изменяем размеры изображения из файла (пример - только в пикселах, проценты - по аналогии с изменением размера скриншота)
string strSourceImagePath = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\night_silence.jpg";
string strResultImagePath4 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\file_crop_pixel.jpg";
ZennoPoster.ImageProcessingCropFromFile(strSourceImagePath, strResultImagePath4, 500, 250, 150, 150, "pixel", 100);

project.SendInfoToLog(@"Проверьте результат выполнения в папке Вспомогательные файлы\Картинки\Результат");

//Примечания:
//1. Параметры ImageProcessingCropFromScreenshot:
//	первый: порт инстанса;
//	второй: путь сохранения картинки;
//	третий: левая граница полученной области внутри изображения;
//	четвёртый: верхняя граница полученной области внутри изображения;
//	пятый: единицы измерения (pixel/percent);
//	шестой: качество получаемого изображения в процентах (по умолчанию 100).
//2. Параметры для ImageProcessingCropFromUrl, ImageProcessingCropFromFile формируются аналогично ImageProcessingCropFromScreenshot (кроме первого параметра).
//3. Если файлы для размещения результата уже существуют - они будут перезаписаны.