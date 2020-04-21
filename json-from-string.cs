//using Newtonsoft.Json.Linq;
//using System;

string json = @"{
  ""Work"": {
    ""Count"": 5,
    ""Clients"": [
      {
        ""Id"": ""17658"",
        ""Fio"": ""Поромко С.В.""
      },
      {
        ""Id"": ""200042"",
        ""Fio"": ""Ильин А.К.""
      },
      {
        ""Id"": ""1199849"",
        ""Fio"": ""Цой А.М.""
      },
      {
        ""Id"": ""3035678"",
        ""Fio"": ""Виснецов С.В.""
      },
      {
        ""Id"": ""7579106"",
        ""Fio"": ""Гивеншина Н.""
      }
    ]
  }
}";


JObject o = JObject.Parse(json);
foreach(JToken tkn in o["Work"]["Clients"])
{
    foreach(IJEnumerable<JToken> ter in tkn.Values())
    {
        project.SendInfoToLog(ter.ToString());
    }
}