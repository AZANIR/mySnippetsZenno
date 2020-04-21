//разделить строчку на части с помощью разделителя

List<string> ipPortAsList = new List<string>(
   project.Variables["proxy"].Value.Split(new string[] { ":" }, 
   StringSplitOptions.RemoveEmptyEntries));
	if(nameSurname.Count > 0)
	{
	}