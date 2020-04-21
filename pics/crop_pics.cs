List<string> files = new List<string>(); 
try{var dir=new DirectoryInfo(project.Directory+@"\"+project.Variables["ID"].Value);// папка с файлами 
	// список для имен файлов 
	foreach (FileInfo file in dir.GetFiles()) // извлекаем все файлы и кидаем их в список 
	{ 
	    files.Add(file.FullName); // получаем полный путь к файлу и кидаем его в список 
	}
}catch{}
	
foreach(string pic_path in files)
{
	//берет путь к фото, обрезает со всех сторон по r_N пикселей,заменяя на первоначальный файл
	string imagePath = pic_path;
	int left =0;
	int top = 0;
	int right = 0;
	int bottom = 65;
	Image imgNew;
	 
	using(Image img = Image.FromFile(imagePath)){
	    imgNew = ((Bitmap)img).Clone(new Rectangle(left, top, img.Width - right - left, img.Height - bottom - top),img.PixelFormat);
	}
	imgNew.Save(imagePath);
}