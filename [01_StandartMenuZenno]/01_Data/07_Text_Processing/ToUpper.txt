//объявляем переменную, содержащую исходную строку
string strSource = "это исходная строка";

//String.ToUpper: приводим всю строку к верхнему регистру
string strResult = strSource.ToUpper();

//делаем заглавной только первую букву
strResult = char.ToUpper(strSource[0]) + strSource.Substring(1);

//делаем заглавной первую букву каждого слова
string[] arrWords = strSource.Split(' ');
for(int i=0; i<arrWords.Length; i++) {
	string strWord = arrWords[i];
	arrWords[i] = char.ToUpper(strWord[0]) + strWord.Substring(1) + " ";
}
strResult = String.Join(String.Empty, arrWords);

project.SendInfoToLog("Готово! Результат выполнения: " + strResult);