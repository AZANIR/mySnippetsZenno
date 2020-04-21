int unixTimestamp = (int)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
return unixTimestamp;

//Javascript
//var sec = ({-Variable.time_end-} -  {-Variable.time_start-});
//Math.floor(sec / 3600) + " час. " + (Math.floor(sec / 60) - (Math.floor(sec / 3600) * 60)) + " мин. " + sec % 60 + " сек. ";
 