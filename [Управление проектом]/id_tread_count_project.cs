/*
добавляем в общий код после 

namespace ZennoLab.OwnCode
{
	
*/

public static class TaskHelper
   {
     
       public static string GetTaskId(string TaskName)
     {
       var tasksList = ZennoPoster.TasksList;
       foreach (var task in tasksList){         
        string tname = Regex.Match(task,@"(?<=<Name>).*?(?=</Name>)").Value;
          string tid  = Regex.Match(task,@"(?<=<Id>).*?(?=</Id><Name>)").Value;
         
          if (tname == TaskName){
           return tid;
          }
       }   
       return "";
     }
     
     public static int GetNumberOfTries(string TaskName)
     {
         string sid = TaskHelper.GetTaskId(TaskName);
       var id = Guid.Parse(sid);
       var taskInfo = ZennoPoster.GetTaskInfo(id);
       string execsettings = Regex.Match(taskInfo,@"(?<=<ExecutionSettings>).*?(?=</ExecutionSettings>)").Value;
       string ntries =  Regex.Match(execsettings,@"(?<=<NumberOfTries>).*?(?=</NumberOfTries>)").Value;
       int res=0;
       Int32.TryParse(ntries,out res);
       return res;       
     }
     
     public static string GetStatus(string TaskName)
     {
       string sid = TaskHelper.GetTaskId(TaskName);
       var id = Guid.Parse(sid);
       var taskInfo = ZennoPoster.GetTaskInfo(id);
       string status = Regex.Match(taskInfo,@"(?<=<Status>).*?(?=</Status>)").Value;
       return status;
       
       //Perform - работает
       //Complite - завершен
       //Stop - остановлен
       //Schedule - запланирован
       //WaitPerform - компилится
     }
     
     public static void WaitRun(IZennoPosterProjectModel project,string TaskName)
     {
         int nt = GetNumberOfTries(TaskName);
       string status = GetStatus(TaskName);
       while( nt >0 )
       {    
         if(((ZennoLab.InterfacesLibrary.ProjectModel.Collections.IContextExt)project.Context).IsInterrupted) return; // Прерывание в ZP
         if(Global.Variables.IsProjectMaker && !Global.Variables.IsDebugMode) return; // Прерывание в PM
         
           Thread.Sleep(3000);
         
           nt = TaskHelper.GetNumberOfTries(TaskName);
         status = GetStatus(TaskName);
         
         switch (status)
         {
           case "Perform":
             break;
           case "Complite": nt = 0;
             break;
           case "Stop": nt = 0;
             break;
           case "Schedule":
             break;
           case "WaitPerform":
             break;
         }
         
           project.SendInfoToLog("Ожидаем завершения "+TaskName,true);   
       }
     }
   }
   
//Использованние
//Поиск айди шаблона по имени:
string tempname = "имя шаба";
if (TaskHelper.GetTaskId(tempname)==""){
  project.SendErrorToLog("Не смогли найти проект "+tempname, true);
  throw new Exception("Не найден проект");
}

//Добавление нужного числа исполнений и ожидание завершения:
string tempname = "имя шаба";
int tries = 50; // будет добавлено 50 исполнений
if (tries>0){
   ZennoPoster.AddTries(tempname , tries);
   TaskHelper.WaitRun(project,tempname );  //ожидаем завершения всех исполнений
}

//GetStatus - получить статус шаблона
//Perform - работает
//Complite - завершен
//Stop - остановлен
//Schedule - запланирован
//WaitPerform - компилится
//GetNumberOfTries - получить кол-во заданых исполнений


//В 7.3.0.0 Добавили возможность получить кол-во активных потоков.
var Id = Guid.Parse(project.TaskId);
int currentTaskThreadsById = ZennoPoster.GetThreadsCount(Id);
return currentTaskThreadsById