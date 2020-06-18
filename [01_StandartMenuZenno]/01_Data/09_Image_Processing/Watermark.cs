//Переходим на сайт (для демонстрации работы)
Tab Tab1 = instance.ActiveTab;
if (Tab1.URL!="http://zennolab.com/discussion/") {
	Tab1.Navigate("http://zennolab.com/discussion/");
	Tab1.WaitDownloading();
}

//добавляем watermark-картинку к скриншоту
string strResultImagePath1 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_watermark_image.jpg";
string strWatermark1 = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\big_watermark.png";
ZennoPoster.ImageProcessingWaterMarkImageFromScreenshot(instance.Port, strResultImagePath1, "horizontally", "center", strWatermark1, 80, 0, 150, 100);

//добавляем watermark-текст к скриншоту
string strResultImagePath2 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\instance_watermark_text.jpg";
ZennoPoster.ImageProcessingWaterMarkTextFromScreenshot(instance.Port, strResultImagePath2, "horizontally", "center", "Привет :)", 80, "", 150, 100, 100);

//добавляем watermark-картинку к изображению из URL (добавление текста - аналогично примеру "watermark-текст к скриншоту)
string strResultImagePath3 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\url_watermark_image.png";
string strWatermark2 = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\small_watermark.png";
string strImageURL = "http://zennolab.com/discussion/styles/Eloquent/xenforo/logo1.png";
ZennoPoster.ImageProcessingWaterMarkImageFromUrl(strImageURL, strResultImagePath3, "horizontally", "center", strWatermark2, 0, 0, 0, 100);

//добавляем watermark-картинку к изображению из файла (добавление текста - аналогично примеру "watermark-текст к скриншоту)
string strSourceImagePath = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\night_silence.jpg";
string strResultImagePath4 = project.Directory + @"\Вспомогательные файлы\Картинки\Результат\file_watermark_image.jpg";
string strWatermark3 = project.Directory + @"\Вспомогательные файлы\Картинки\Исходные\big_watermark.png";
ZennoPoster.ImageProcessingWaterMarkImageFromFile(strSourceImagePath, strResultImagePath4, "horizontally", "center", strWatermark3, 0, 0, 0, 100);

project.SendInfoToLog(@"Проверьте результат выполнения в папке Вспомогательные файлы\Картинки\Результат");

//Примечания:
//1. Параметры ImageProcessingWaterMarkImageFromScreenshot:
//	первый: порт инстанса;
//	второй: путь сохранения картинки;
//	третий: тип наложения. Варианты: "horizontally" (горизонтальный) или "diagonally" (диагональный);
//	четвёртый: расположение водяного знака на изображении. Варианты: "center" (по центру), "leftbottom" (слева внизу), "lefttop" (слева вверху), "rightbottom" (справа внизу), "righttop" (справа вверху).
//	пятый: изображение с водяным знаком (или текст водяного знака, если используются методы ImageProcessingWaterMarkText...)
//	шестой: прозрачность водяного знака
//	седьмой: сдвиг водяного знака от левого края изображения в пикселах
//	восьмой: сдвиг водяного знака от верхнего края изображения в пикселах
//	девятый: качество получаемого изображения в процентах (по умолчанию 100).
//	Параметры для ImageProcessingWaterMarkImageFromFromUrl, ImageProcessingWaterMarkImageFromFile формируются аналогично ImageProcessingWaterMarkImageFromScreenshot (кроме первого параметра).

//2. Параметры ImageProcessingWaterMarkTextFromScreenshot:
//	первый: порт инстанса;
//	второй: путь сохранения картинки;
//	третий: тип наложения. Варианты: "horizontally" (горизонтальный) или "diagonally" (диагональный);
//	четвёртый: расположение водяного знака на изображении. Варианты: "center" (по центру), "leftbottom" (слева внизу), "lefttop" (слева вверху), "rightbottom" (справа внизу), "righttop" (справа вверху).
//	пятый: текст водяного знака
//	шестой: прозрачность водяного знака
//	седьмой: стиль оформления текста водяного знака. Строка в формате: [Font], [Size]pt, [TextSyle], ... , [TextSyle], [Color_alfa, Color_red, Color_green, Color_blue]. Пример: "Tahoma, 24pt, Bold, Italic, Underline, [255;0;0;0]"
//	восьмой: сдвиг водяного знака от левого края изображения в пикселах
//	девятый: сдвиг водяного знака от верхнего края изображения в пикселах
//	десятый: качество получаемого изображения в процентах (по умолчанию 100).
//	Параметры для ImageProcessingWaterMarkTextFromUrl, ImageProcessingWaterMarkTextFromFile формируются аналогично ImageProcessingWaterMarkTextFromScreenshot (кроме первого параметра).

//3. Если файлы для размещения результата уже существуют - они будут перезаписаны.