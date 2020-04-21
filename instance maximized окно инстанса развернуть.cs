http://zennolab.com/discussion/threads/start-the-instance-maximized.10793/

//code to set up windows size the same as primary screen's resolution
foreach (var screen in System.Windows.Forms.Screen.AllScreens)
{
    if(screen.Primary)
    {
        instance.SetWindowSize(screen.WorkingArea.Width,screen.WorkingArea.Height);
                return 0;
    }
}