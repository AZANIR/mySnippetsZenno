//объявляем переменную, содержащую код символа Unicode
string strUnicodeSymbolNumber = "0065";
//убираем первый символ "u" (оставляем только код)
if (strUnicodeSymbolNumber.StartsWith("u")) {
	strUnicodeSymbolNumber = strUnicodeSymbolNumber.Substring(2);
}
char chrResult = (char)int.Parse(strUnicodeSymbolNumber);
project.SendInfoToLog("Результат преобразования: " + chrResult.ToString());