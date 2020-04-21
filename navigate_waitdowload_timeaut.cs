instance.ActiveTab.Navigate(he.GetAttribute("href"));
System.Threading.Thread.Sleep(Convert.ToInt32(5000));
if (instance.ActiveTab.IsBusy) instance.ActiveTab.WaitDownloading();
instance.ActiveTab.NavigateTimeout = 60;
instance.ActiveTab.WaitDownloading();