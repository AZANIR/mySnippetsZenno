//В стандартных библиотеках, подключенных к ZennoPoster по умолчанию, нет команды для генерации случайной строки
//Ниже приведена одна из возможных реализаций

Random rndTextGenerator = new Random(); //создаём объект для получения случайных чисел
string strRandom = String.Empty; //объявляем переменную, в которую будет помещён результат
int intStringLength = 22; //задаём длину строки

//Генерируем длину строки в определённом диапазоне
int intStringLengthFrom = 8; //длина строки от
int intStringLengthTo = 16; //длина строки до
intStringLength = rndTextGenerator.Next(intStringLengthFrom, intStringLengthTo);

string[] arrDictionary = new String[4];
arrDictionary[0] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Удалите содержимое строки, если в строке не нужно использовать заглавные буквы
arrDictionary[1] = "abcdefghijklmnopqrstuvwxyz"; //закомментируйте эту строку, если в строке не нужно использовать строчные буквы
arrDictionary[2]= "0123456789"; //закомментируйте эту строку, если в строке не нужно использовать цифры
arrDictionary[3] = "$^%#*"; //добавьте в эту строку любые свои символы, которые также можно использовать в строке

string strSymbols = String.Join(String.Empty, arrDictionary);
char[] arrChars = new char[intStringLength];
for (int i = 0; i < arrChars.Length; i++){
	//Генерируем строку заданной длины
    arrChars[i] = strSymbols[rndTextGenerator.Next(strSymbols.Length)];
}
strRandom = String.Join(String.Empty, arrChars); //результат, если не нужно гарантировать присутствие в строке символов всех типов

if(arrChars.Length>=arrDictionary.Length) {
	//Гарантируем, что в строке будет как минимум один символ каждого типа
	for(int i=0;i<arrDictionary.Length;i++) {
		if (arrDictionary[i]!=String.Empty) {
			arrChars[i] = Convert.ToChar(arrDictionary[i].Substring(rndTextGenerator.Next(0,arrDictionary[i].Length),1));
		}
	}
}
strRandom = String.Join(String.Empty, arrChars.Shuffle()); //результат, если нужно гарантировать присутствие в строке символов всех типов

project.SendInfoToLog("Сгенерированная строка: " + strRandom);