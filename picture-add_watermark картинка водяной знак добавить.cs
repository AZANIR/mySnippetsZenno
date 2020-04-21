
//Начальные данные:
//    картинка.png (наша Watermark)
//    Папки (в папках должны быть только картинки)


//Получаем названия папок:
var textContains = project.Variables["var"].Value;
var subdir = System.IO.Directory.GetDirectories((textContains));
for(int i=0;i<subdir.Length;i++)
{
	project.Lists["list1"].Add(subdir[i]);
}

//Накладываем Watermark.
{
		using (Image image = Image.FromFile(@"{-Variable.new-}"))
		using (Image watermarkImage = Image.FromFile(@"{-Variable.leo-}"))
		using (Graphics imageGraphics = Graphics.FromImage(image))
		using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
		{
			int x = (image.Width / 2 - watermarkImage.Width / 2);
			int y = (image.Height / 2 - watermarkImage.Height / 2);
			watermarkBrush.TranslateTransform(x, y);
			imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width+1, watermarkImage.Height)));
			image.Save(@"{-Variable.line-}new\{-Variable.new1-}.jpg");
		}
	 }
		
	//На выходе     Папка1new     Папка2new и.т.д (шаблон создает новые папки с именем старых 
	//(только приставку new добавляет) и перемещает туда уже обработанные изображения .