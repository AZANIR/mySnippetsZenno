//преобразование кук в джейсон формат для других программ.

var cookie = instance.GetCookie();
var splited = cookie.Split(new []{"\r\n"}, StringSplitOptions.None)
    .Select(s => s.Split('\t')).Where(w => w.Length >= 6)
    .ToArray();
var result = new List<object>();
var baseDt = new DateTime(1970, 1, 1);
foreach (var par in splited)
    result.Add(new {
        domain = par[0],
        expirationDate = (long)(DateTime.Parse(par[4]) - baseDt).TotalSeconds,
        httpOnly = par[1] == "TRUE",
        name = par[5],
        path = par[2],
        secure = par[3] == "TRUE",
        value = par[6]
    });

return Global.ZennoLab.Json.JsonConvert.SerializeObject(result);