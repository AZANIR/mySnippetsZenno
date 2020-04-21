//http://zennolab.com/discussion/threads/search-in-list-and-tables-via-c-macro.10733/
//There is a list, where we need check a text presence
//It can be solved using this C# macro (in the attached project, we go through all domains from the list and check if domain contains ".jp")

// take search text from variable
var textContains = project.Variables["listSearchTextContains"].Value;
// get a list or search
var sourceList = project.Lists["SourceList"];
// search in each line of list
lock(SyncObjects.ListSyncer)
{
    for(int i=0; i < sourceList.Count; i++)
    {
        // get line from list
        var str = sourceList[i];
        // check if line contains text, if there are matches return "yes"
        if (str.Contains(textContains))
            return "yes";
    }
}
// ifnothing found return "no"
return "no";