//http://zennolab.com/discussion/threads/zennoposter-kladez-bezgranichnyx-idej-i-vozmozhnostej-chast-2-json-api-post-get.20072/#post-131509


var json = project.Variables["json"].Value;
var keys = "first_name,last_name,online".Split(',');
var djson = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(json);
return string.Join("\r\n", ((IEnumerable<dynamic>)djson["response"]).Select(d=>string.Join(";", keys.Select(k=>d[k]))));