//Добавить using System.Net;
byte[] captcha_byte;

// получаем каптчу
Uri url_captcha = new Uri("https://www.yandex.ru/captchaimg?aHR0cHM6Ly9leHQuY2FwdGNoYS55YW5kZXgubmV0L2ltYWdlP2tleT0wMDNsRE5ZeFlndjQyYUxyakdPZlNWb3lrTmVEZUY0QQ,,_0/1535635391/373656395b8e6649443c0a78b7ae029c_b127648832aade0bf68c0a356337ed0b");

HttpWebRequest captchaRequest = (HttpWebRequest)WebRequest.Create(url_captcha); //создаём запрос на скачивание капчи
captchaRequest.UserAgent = project.Profile.UserAgent; //Подставляем юзерагент с профиля

WebResponse captchaResponse = captchaRequest.GetResponse();
Stream responseStream = captchaResponse.GetResponseStream();

using (BinaryReader br = new BinaryReader(responseStream))
{
captcha_byte = br.ReadBytes(500000);
br.Close();
}
responseStream.Close();
captchaResponse.Close();

MemoryStream captcha_Stream = new System.IO.MemoryStream(captcha_byte);
Image image_captcha = System.Drawing.Image.FromStream(captcha_Stream);
//Bitmap bitmap_captcha = new Bitmap(image_captcha);

string base64 = Convert.ToBase64String(captcha_byte);

var result = ZennoPoster.CaptchaRecognition("Rucaptcha.dll", base64, "");
// отрезаем лишнее
var tmp = result.Split(new [] {"-|-"}, StringSplitOptions.None);
if (tmp.Length > 1)
{  
return tmp[0];
}
return result;