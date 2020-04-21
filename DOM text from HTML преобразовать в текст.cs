string y = project.Variables ["jobDescription"]. Value;
string result = System.Net.WebUtility.HtmlDecode (y);
return result; 