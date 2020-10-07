//преобразование кук в джейсон формат для других программ.
//выполнить на текущей странице
var text = '{-Variable.CookiesZenno-}';
 
function NetscapeToJson(netscapeText){
    var arrObjects = [];
    var textArea1 = netscapeText;
    var arrayOfLines = textArea1.split("|||");
    var i = 0;
    for (i=0; i<arrayOfLines.length; i++){
        var kuka = arrayOfLines[i].split("\t");
        var cook = new Object();  
            cook.domain = kuka[0];
            cook.expirationDate = Date.parse(kuka[4]);
            console.log(cook)
            if (kuka[1] == "FALSE") cook.httpOnly = false;
            if (kuka[1] == "TRUE") cook.httpOnly = true;
 
            cook.name = kuka[5];
            cook.path = kuka[2];
           
            if (kuka[3] == "FALSE") cook.secure = false;
            if (kuka[3] == "TRUE") cook.secure = true;
 
 
            cook.value = kuka[6];
            arrObjects[i] = cook;      
    }
   
    var cookieStr = JSON.stringify(arrObjects);
    return cookieStr;
    }
   
    return NetscapeToJson(text);