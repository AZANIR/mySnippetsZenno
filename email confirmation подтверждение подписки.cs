//http://zennolab.com/discussion/threads/default-email-confirmation-snippet.13700/

// Get Email config file path
var configPath = project.Variables["emailConfPath"].Value;
// Read email Config file
var emailConfig = System.IO.File.ReadAllText(configPath);
// Get email provider from email
var rgx = Macros.TextProcessing.Split(project.Variables["email"].Value, "@", "1").First();
// Create regex to find email configuration
rgx = rgx + ":";
rgx = System.Text.RegularExpressions.Regex.Escape(rgx);
var regex = new System.Text.RegularExpressions.Regex(@"(?<=" + rgx + @").*");
var match = regex.Match(emailConfig);
string emailConfigString =  match.Groups[0].Value;
if(emailConfigString == "") return "";
// Confirm email
var emailConfirm = ZennoPoster.MailConfirm("15;30;60",
project.Variables["email"].Value,
project.Variables["emailPass"].Value,
Macros.TextProcessing.Split(emailConfigString, ";", "0").First(),
Convert.ToInt32(Macros.TextProcessing.Split(emailConfigString, ";", "1").First()),
Convert.ToBoolean(Macros.TextProcessing.Split(emailConfigString, ";", "2").First()),
Convert.ToBoolean(project.Variables["useHtml"].Value),
Convert.ToBoolean(Macros.TextProcessing.Split(emailConfigString, ";", "3").First()),
Convert.ToBoolean(Macros.TextProcessing.Split(emailConfigString, ";", "4").First()),
project.Variables["emailRegex"].Value,
project.Variables["emailRegex"].Value, 0);
return emailConfirm.Trim();


/*
To use this snippet in your project you will need to create variables. Or use my prepared template for that.

email = email to check confirmation link
emailPass = email password to check confirmation link
useHtml = if use HTML of email to find confirmation link then true if not then false and plain text will be used
emailRegex = this variable Value should contain regex how to find your confirmation email
emailConfirm = this variable value will contain Your confirmation link.

Add all email providers you use in file Email_Config.txt - You can call this file as you like and also You can save it whatever you want. Just set up project variable "emailConfPath" with your actual path to file.
In file you will find example strings like:

hotmail.com:pop3.live.com;995;true;false;false

hotmail.com: = part after @ from your email so if email is "email@hotmail.com" you should add in config hotmail.com at the beginning.
pop3.live.com = email server.
995 = email server port.
true = true or false - if email server useSsl then true otherwise false.
false = useIMAP - true or false - if use POP3 then false, if use IMAP then true.
false = removeMessages true or false - if need to remove then true if not then false.

All other Variables will be taken from project itself because such variables as emailRegex useHTML will be different for each project.

*/