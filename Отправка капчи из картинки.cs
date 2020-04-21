//Отправка капчи из картинки
var captcha__get = project.Variables["captcha__get"].Value;
var image = System.Drawing.Image.FromFile(@captcha__get);
string base64String = String.Empty;
using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
{
  image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
  byte[] imageBytes = ms.ToArray();
  base64String = Convert.ToBase64String(imageBytes);
}
var result = ZennoPoster.CaptchaRecognition("Anti-Captcha.dll", base64String, "");
// отрезаем лишнее
var tmp = result.Split(new [] {"-|-"}, StringSplitOptions.None);
if (tmp.Length > 1) return tmp[0];
return result;