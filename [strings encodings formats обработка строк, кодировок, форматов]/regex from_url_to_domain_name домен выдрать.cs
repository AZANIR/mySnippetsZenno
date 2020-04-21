//http://zennolab.com/discussion/threads/iz-url-domen-reguljarka.19396/#post-125508

//эта регулярка вытаскивает: (?<=http://).([\w\.]+)

//а так - можно и без кода:
//обработка текста - замена http://|https:// на пустоту
//и еще раз замена /.* на пустоту 

var Url = project.Variables["nazwa_zmiennej"].Value;
return new Uri(Url).Host;