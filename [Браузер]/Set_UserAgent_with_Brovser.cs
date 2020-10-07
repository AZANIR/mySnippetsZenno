//получаем useragent профиля
string ua = project.Profile.UserAgent;
//получаем текущий браузер проекта
var currBrowser = Convert.ToString(instance.BrowserType);

project.SendInfoToLog("Profile UserAgent: "+ua+" Current project browser: "+currBrowser, true);

//Если в ua присутствует Chrome и текущий браузер не Chrome
if (ua.Contains("Chrome") && (currBrowser != "Chrome"))
{
    //устанавливаем браузером проекта Chrome
    instance.Launch(ZennoLab.InterfacesLibrary.Enums.Browser.BrowserType.Chrome, true);
    project.SendInfoToLog("Движок Chrome установлен как браузер проекта", true);
}

//Если в ua присутствует Firefox любой версии 4*, и движок не Firefox45,
if (ua.Contains("Firefox/4") && (currBrowser != "Firefox45"))
{
    //устанавливаем браузером проекта Firefox45
    instance.Launch(ZennoLab.InterfacesLibrary.Enums.Browser.BrowserType.Firefox45, true);
    project.SendInfoToLog("Движок Firefox45 установлен как браузер проекта", true);
}

//Если в ua присутствует Firefox любой версии 5*, 6*, 7*,
if (ua.Contains("Firefox/5") || ua.Contains("Firefox/6") || ua.Contains("Firefox/7"))
{
    //и движок не Firefox52х64
    if (ua.Contains("Win64") && currBrowser != "Firefox52x64")
    {
        //устанавливаем браузером проекта Firefox52x64
        instance.Launch(ZennoLab.InterfacesLibrary.Enums.Browser.BrowserType.Firefox52x64, true);
        project.SendInfoToLog("Движок Firefox52x64 установлен как браузер проекта", true);
    }
    //и движок не Firefox52
    if (ua.Contains("WOW64") && currBrowser != "Firefox52")
    {
        //устанавливаем браузером проекта Firefox52
        instance.Launch(ZennoLab.InterfacesLibrary.Enums.Browser.BrowserType.Firefox52, true);
        project.SendInfoToLog("Движок Firefox52 установлен как браузер проекта", true); 
    }
    
    // UA FF/5*-/6*-/7*, и не содержит Win64, и не содержит WOW64, и движок не Firefox52
    if (ua.Contains("WOW64")==false && ua.Contains("Win64")==false && currBrowser != "Firefox52")
    {
        //устанавливаем браузером проекта Firefox52
        instance.Launch(ZennoLab.InterfacesLibrary.Enums.Browser.BrowserType.Firefox52, true);
        project.SendInfoToLog("Движок Firefox52 установлен как браузер проекта", true); 
    }
}