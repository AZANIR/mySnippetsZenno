// скрин
string fileTemplate = "somenamefile";
HtmlElement he = instance.ActiveTab.FindElementByAttribute("html", "fulltag", "html", "text", 0);
if (he.IsVoid)
	he = instance.ActiveTab.FindElementByAttribute("body", "fulltag", "body", "text", 0);
if (!he.IsVoid)
{
   string recognition = ZennoPoster.CaptchaRecognition("CaptchaSaver.dll", he.DrawToBitmap(false), Path.Combine(project.Directory+@"\capthas\", fileTemplate + ".jpg"));
}