// 1 вариант
// Проигрывает любой .wav файл
 
System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"путь к файлу");
player.Play();
 
// 2 вариант
 
System.Media.SystemSounds.Exclamation.Play();
 
// 3 вариант
 
Console.Beep(800, 500); // частота сигнала и длительность, мс
