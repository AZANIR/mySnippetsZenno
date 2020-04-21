try{

//тут твой код

}
   catch(Exception expr)
   {
    project.SendErrorToLog("Переменная captcha: " + ИНТЕРЕСУЮЩАЯ_ПЕРЕМЕННАЯ.Value, true);
    project.SendErrorToLog("Исключение при обработке капчи перед отправкой в антикапчу! " + expr.Message, true);
    if(null != expr.InnerException)
     project.SendErrorToLog("Исключение при обработке капчи перед отправкой в антикапчу (внутреннее)! " + expr.InnerException.Message, true);
    Console.Beep(1100, 50); //частота, длительность
    Console.Beep(1000, 50); //frequency, length  
    return null;
   }
   