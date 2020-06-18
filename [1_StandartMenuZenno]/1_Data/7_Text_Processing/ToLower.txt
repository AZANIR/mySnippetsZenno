//объявляем переменную, содержащую исходную строку
string strSource = "ЭТО ИСХОДНАЯ СТРОКА";

//String.ToUpper: приводим всю строку к нижнему регистру
string strResult = strSource.ToLower();

//делаем строчной только первую букву
strResult = char.ToLower(strSource[0]) + strSource.Substring(1);

//делаем строчной первую букву каждого слова
string[] arrWords = strSource.Split(' ');
for(int i=0; i<arrWords.Length; i++) {
	string strWord = arrWords[i];
	arrWords[i] = char.ToLower(strWord[0]) + strWord.Substring(1) + " ";
}
strResult = String.Join(String.Empty, arrWords);

project.SendInfoToLog("Готово! Результат выполнения: " + strResult);