//http://zennolab.com/discussion/threads/nazhatie-ctrl-p.9064/#post51963
//http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx

instance.ActiveTab.Navigate("yandex.ru","");
if(instance.ActiveTab.IsBusy) instance.ActiveTab.WaitDownloading();
lock(SyncObjects.InputSyncer)
{
      Emulator.ActiveWindow(instance.FormTitle);
      SendKeys.SendWait("^{ENTER}");
}