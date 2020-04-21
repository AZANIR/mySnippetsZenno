Random rndGenerator = new Random(); //создаём объект для получения случайных чисел
int intRandomNumber = 0; //объявляем переменную, в которую будет помещено случайное число
//Random.Next: генерируем случайное число
intRandomNumber = rndGenerator.Next(); //Получаем любое положительное случайное число
intRandomNumber = rndGenerator.Next(105, 350); //Получаем случайное число между 105 и 350

project.SendInfoToLog("Сгенерированное число: " + intRandomNumber);

//Демонстрация неправильной генерации случайных чисел:
project.SendInfoToLog("Демонстрация неправильной генерации случайных чисел:");
for (int i=0; i<10; i++) {
	Random rndGenerator2 = new Random();
	project.SendInfoToLog("Числа будут повторяться: " + rndGenerator2.Next());
}

//Решение - создавать объект Random ДО циклов:
project.SendInfoToLog("Демонстрация правильной генерации случайных чисел:");
Random rndGenerator3 = new Random();
for (int i=0; i<10; i++) {
	project.SendInfoToLog("Теперь числа не повторяются: " + rndGenerator3.Next());
}