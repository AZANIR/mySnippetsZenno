//вызов в коде
//пауза отрабатывает +-10% рандомизация 
CommonCode.WaitLoad(instance, 5000);
/*
сам код добавить в общий код  
//пауза с рандомизацией в указанных процентах, также ожидание прогрузки инстансас максимальной задержкой 30сек 
public static void WaitLoad(Instance instance, int second){
			int precent = 10; //процент вариации времени  10%
			int pause_rnd = Global.Classes.rnd.Next((second-(second / 100 * precent)),(second+(second / 100 * precent))); 
			System.Threading.Thread.Sleep(pause_rnd);
			if (instance.ActiveTab.IsBusy) instance.ActiveTab.WaitDownloading();
			instance.ActiveTab.NavigateTimeout = 30;
			instance.ActiveTab.WaitDownloading();
			
		}
*/