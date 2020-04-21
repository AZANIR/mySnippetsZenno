//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
//using System;

FileStream fs = new FileStream(@"C:\temp\data.json", FileMode.Open, FileAccess.Read);
JsonTextReader reader = new JsonTextReader(new StreamReader(fs));

JObject o = JObject.Load(reader);
foreach(JToken tkn in o["Work"]["Clients"])
{
    foreach(IJEnumerable<JToken> ter in tkn.Values())
    {
        project.SendInfoToLog(ter.ToString());
    }
}