//context (?<=context=).*?(?=")
string context ="";
context = Convert.ToString(Regex.Match(item_adv, @"(?<=context=).*?(?="")")).Trim();
project.SendWarningToLog(context, false);