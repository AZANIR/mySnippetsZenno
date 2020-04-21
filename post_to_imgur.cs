string post_data = "----------------------8d58d7876f67e5b"+"\n"+
	"Content-Disposition: form-data; name=\"image\""+"; filename=\""+ "1.jpg"+"\"\n"+
	"Content-Type: image/jpg"+"\n"+project.Path + "error\\" + "1.jpg"+"\n"+
	"----------------------8d58d7876f67e5b--";
int query_count = 0;
string answer = string.Empty;
while(answer==""){
	answer = ZennoPoster.HttpPost(
		"https://api.imgur.com/3/image",post_data,
		"multipart/form-data",
		"",
		"utf-8",
		ZennoLab.InterfacesLibrary.Enums.Http.ResponceType.HeaderAndBody,
		30000,"","ShareX",true,10,
		new [] {
			"Host: api.imgur.com",
			"Authorization: Client-ID d297fd441566f99",
			"Content-Type: multipart/form-data; boundary=--------------------8d58d7876f67e5b",
			"Connection: keep-alive"
		}
	);
	if (++query_count>=5 && answer=="")
	{
		project.Variables["answer"].Value = "";
		throw new Exception("[Финальная отправка данных логина: пустой ответ 5 раз(а) подряд]");
	}
}
project.Variables["post_info"].Value = answer;
//парсим нашу картинку //(?<="id":").*?(?=")
string pic="";
try{pic = Convert.ToString(Regex.Match(answer, @"(?<=id"":"").*?(?="")")).Trim();}catch{}
project.Variables["id_pic"].Value = pic;
string deletehash="";
try{deletehash = Convert.ToString(Regex.Match(answer, @"(?<=deletehash"":"").*?(?="")")).Trim();}catch{}
project.Variables["deletehash"].Value = deletehash;