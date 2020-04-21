//перезапуск проектов
//http://zennolab.com/discussion/threads/ostanovit-udalit-proekt-v-planirovschike.36710/#post-273135

var list_shablon=project.Lists["shablony"];//список с полными путями к шаблонам
var tasksList = new List<string>(ZennoPoster.TasksList);//список проектов в зеннопостер
 
Regex reg_id = new Regex(@"(?<=<ProjectFileLocation>).*(?=</ProjectFileLocation>)");//регуляр для поиска пути в xml zennoposter
string id_project="";
string good=list_shablon.Count+" \r\n";
// проходим по списку шаблонов
for (int j = 0; j < list_shablon.Count; j++)
{    
       // проходим по списку проектов
      for (int i = 0; i < tasksList.Count; i++)
       {
         var source = tasksList[i];
          //проверяем регуляркой на путь проекта
          Match match = reg_id.Match(source);
          if (match.Success)
            {
               id_project=match.Groups[0].Value;
                //good=good+list_shablon[j]+"="+id_project+" \r\n";
               
               if(id_project.CompareTo(list_shablon[j])==0)
                  {                  
                  good=good+list_shablon[j]+" "+" \r\n";
                   
                   var xpath = "Task/Id";
                   // Gets guid string from task data
                   var doc = new System.Xml.XmlDocument();
                   doc.LoadXml("<Task>" + source + "</Task>");
                   string result;
                   var node = doc.SelectSingleNode(xpath);
                   if (node != null)
                       result = node.InnerXml;
                   else
                       throw new InvalidDataException(string.Format("{0} is null", xpath));
                   Guid id;
                   // Parse guid
                   if (Guid.TryParse(result, out id))
                    {  // If ok, останавливаем проект
                      ZennoPoster.InterruptTask(id);
                      Thread.Sleep(2000);//пауза
                      //запускаем проект
                      ZennoPoster.StartTask(id);
                    }
                  else
                      throw new FormatException(string.Format("{0} is not guid", result));
 
       
                  }
            }
   
   }
}
return good;