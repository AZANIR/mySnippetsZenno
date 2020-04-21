//http://zennolab.com/discussion/threads/search-in-list-and-tables-via-c-macro.10733/
//There is a list, where we need find all elements that mach regular expression and put them to another list.
//You can use this C# macro for that (in the attached project, we go through all domains from the list and select ones that contain digitals)
//
// prepare regular expression for parsing
var parserRegexPattern = project.Variables["listSearchRegex"].Value;
var parserRegex = new System.Text.RegularExpressions.Regex(parserRegexPattern);
// get a list for searching
var sourceList = project.Lists["SourceList"];
// get result list
var destList = project.Lists["OutputList"];
// search in each line of the list
lock(SyncObjects.ListSyncer)
{
    for(int i=0; i < sourceList.Count; i++)
    {
        // take one line from the list
        var str = sourceList[i];
        // check the line on matches by regex, if there are matches we put it to result list
        if (parserRegex.IsMatch(str))
        {
            destList.Add(str);        
        }
    }
}
