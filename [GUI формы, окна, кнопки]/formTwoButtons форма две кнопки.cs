//http://zennolab.com/discussion/threads/analog-knopki-obnovit.26208/#post-182232

System.Windows.Forms.Form F = new System.Windows.Forms.Form();
F.Text = "Refresh";
F.Width=150;
F.Height=170;
F.ControlBox  = false;
F.MaximizeBox = false;
F.MinimizeBox = false;
F.TopMost = true;
 
System.Windows.Forms.Button button = new System.Windows.Forms.Button();
button.Text = "�������� ��������";
button.Location = new System.Drawing.Point(10,10);
button.Size=new System.Drawing.Size(110,50);
F.Controls.Add(button);
 
System.Windows.Forms.Button button2 = new System.Windows.Forms.Button();
button2.Text = "���� �����";
button2.Location = new System.Drawing.Point(10,70);
button2.Size=new System.Drawing.Size(110,50);
F.Controls.Add(button2);
 
button.Click += (delegate
{
project.Variables["answer"].Value = "yes";
 
instance.ActiveTab.MainDocument.EvaluateScript("window.location.reload(true)");
F.Dispose();  
});
F.AcceptButton = button;
button2.Click += (delegate
{
project.Variables["answer"].Value = "no";
F.Dispose();
});
F.ShowDialog();
return 0;
 
 