//http://zennolab.com/discussion/threads/proekt-planiruet-sam-sebja.24040/#post-164963

var time = DateTime.Now + TimeSpan.FromDays(10);
var str = string.Format("{0}/{1}/{2} {3}:{4}:{5}", time.Month, time.Day, time.Year, time.Hour, time.Minute, time.Second);
var howMuch = 1; // сколько повторять
 
var settings =
string.Format(
@"<StartDate>{0}</StartDate>
<ShedulerOnDate>{0}</ShedulerOnDate>
<EndDate>{0}</EndDate>
<RepetitionCount>{1}</RepetitionCount>
<ScheduleType>EveryMinutes</ScheduleType>
<RepeatType>FinishAfter</RepeatType>
<ActivateTime>01/01/0001 00:00:00</ActivateTime>
<ActivateWorkTime>01/01/0001 00:00:00</ActivateWorkTime>
<IsActive>True</IsActive>
<NumberOfTries>0</NumberOfTries>
<Minutes>1</Minutes>
<Days>1</Days>
<LastScheduleDate>{0}</LastScheduleDate>
<NextScheduleDate>{0}</NextScheduleDate>
<IsClearSucces>True</IsClearSucces>"
,str, howMuch);
 
var name = "MultiThread";
ZennoPoster.SetSchedulerSettings(name, settings);