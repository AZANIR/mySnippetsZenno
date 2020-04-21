//http://zennolab.com/discussion/threads/otpravit-svoju-kartinku-v-antikapchu.18399/#post-117911


var image = System.Drawing.Image.FromFile(@"C:\1.png");
 
string base64String = String.Empty;
 
using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
{
      image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
      byte[] imageBytes = ms.ToArray();
      base64String = Convert.ToBase64String(imageBytes);
}
 
var result = ZennoPoster.CaptchaRecognition("Anti-Captcha.dll", base64String, "");
var split = result.Split(new [] {"-|-"}, StringSplitOptions.RemoveEmptyEntries);
if (split.Length == 2) return split[0];
else throw new Exception("ERROR");