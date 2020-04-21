//Данный код отсчитывает время выполнения, своеобразный таймер, в s будет лежать пройденное время (в сек.) от заданной даты, которая и есть startime.


int s = (int)(DateTime.Now.Subtract(new DateTime(2016, 01, 21, 20, 01, 00))).TotalSeconds;
//Вместо даты и времени, хочу вставить переменную startime, которая получается следующим образом

return DateTime.Now.ToString("yyyy, MM, dd, HH, mm, ss");

