http://zennolab.com/discussion/threads/project-directory-v-kode-c.12738/#post-75707

//Reduce image with saving its proportion
Func<System.Drawing.Image, int, int, System.Drawing.Image> imgReduse = (System.Drawing.Image _img, int _width, int _height) => {
var _rx = (double)_img.Width/_width;
var _ry = (double)_img.Height/_height;
var _ratio = Math.Min(_rx, _ry);
var _newW = (int)(_img.Width/_ratio);
var _newH = (int)(_img.Height/_ratio);
return new System.Drawing.Bitmap(_img, _newW, _newH);
};
string imagePath = project.Variables["AAA"].Value;
string directoryTmp = project.Directory + @"\tmp\00.JPG";
 
int imagePath1 = Convert.ToInt32(project.Variables["HHH"].Value);
int imagePath2 = Convert.ToInt32(project.Variables["WWW"].Value);
 
// Create image file
System.Drawing.Image tempimg = System.Drawing.Image.FromFile(imagePath);
System.Drawing.Image img = imgReduse(tempimg, imagePath1, imagePath2);
// Save new image
img.Save(directoryTmp, System.Drawing.Imaging.ImageFormat.Jpeg);
tempimg.Dispose();
img.Dispose();