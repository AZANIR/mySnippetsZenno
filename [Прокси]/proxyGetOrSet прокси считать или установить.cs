//change proxy

// get proxy
string proxy = instance.GetProxy();
 
// if instance has proxy
if (proxy != "noproxy")
{
    // split string
    string[] args = proxy.Split(':');
    // first is id
    string ip = args[0];
    // second is port
    int port = Convert.ToInt32(args[1]);
    // third is socks or not
    bool s = Convert.ToBoolean(args[2]); 
}

// OR

instance.ClearCookie();
    instance.ClearProxy();        
    instance.SetProxy("http://174.59.74.190:1686");
            
    Tab tab = instance.ActiveTab;
    if ((tab.IsVoid) || (tab.IsNull)) return -1;
    if (tab.IsBusy) tab.WaitDownloading();
    tab.Navigate("lessons.zennolab.com", "");
    if (tab.IsBusy) tab.WaitDownloading();
            
    return 0;