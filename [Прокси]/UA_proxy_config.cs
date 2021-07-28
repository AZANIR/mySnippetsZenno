//в кубик 
configSet.Thread SetExe = new configSet.Thread();
SetExe.Instance=instance;
SetExe.Project=project;
OneTread trdOne = new OneTread(SetExe);
trdOne.SetProxy();
trdOne.SetUA();
trdOne.cfgProxy = project.Variables["cfg_proxy"].Value;
//в директиву using 
using configSet;

//в общий код 
namespace configSet
{
	public class Thread {
		public IZennoPosterProjectModel Project;
		public Instance Instance;
	}

	public class OneTread {
		private configSet.Thread CurrThread;
		public OneTread(configSet.Thread SetExe) {
			CurrThread = SetExe;
		}
		
		public string cfgProxy;
		public void SetProxy() {
					IZennoPosterProjectModel project = this.CurrThread.Project;
					Instance instance = this.CurrThread.Instance;
					
							//устанавливаем прокси (при необходимости)
					switch(cfgProxy) {
						case "без прокси":
							instance.SetProxy("");
							project.SendInfoToLog("без прокси", true);
							break;
						case "прокси профиля":
							project.SendInfoToLog("прокси профиля", true);
							break;
						case "чекер (без удаления)":
							instance.SetProxy(ZennoPoster.GetProxyWithOutDelete(""));
							project.SendInfoToLog("Назначен прокси: " + instance.GetProxy(), true);
							break;
						case "чекер(с удалением)":
							instance.SetProxy(ZennoPoster.GetProxy(""));
							project.SendInfoToLog("Назначен прокси: " + instance.GetProxy(), true);
							break;
						case "proxies.txt":
							IZennoList lstProxies = project.Lists["Proxy"];
							lock(SyncObjects.ListSyncer) {
								if (lstProxies.Count>0) {
									string strProxy = lstProxies[0];
									lstProxies.RemoveAt(0);
									lstProxies.Add(strProxy);
									instance.SetProxy(strProxy);
									project.SendInfoToLog("Назначен прокси: " + instance.GetProxy(), true);
								}else{
									project.SendErrorToLog("STOP: Нет прокси в файле proxies.txt", true);
									throw new Exception("error Нет прокси в файле proxies.txt");
								}
							}
							break;
						default:
                    		project.SendWarningToLog("Используются прокси BESTPROXY отвественности за их работу нет, прокси будут сохраняться в файл proxies.txt с последующим удалением!!!", true);
                    	break;
					}
				}
		public void SetUA(){
			IZennoPosterProjectModel project = this.CurrThread.Project;
			Dictionary <string, string> build_id_list = new Dictionary <string, string>();
			build_id_list.Add("53", "20170413192749");
			build_id_list.Add("52", "20170316213829");
			build_id_list.Add("51", "20170125094131");
			build_id_list.Add("50", "20161104212021");
			build_id_list.Add("49", "20161019084923");
			build_id_list.Add("48", "20160817112116");
			build_id_list.Add("47", "20160623154057");
			build_id_list.Add("46", "20160502172042");
			build_id_list.Add("45", "20160905130425");
			build_id_list.Add("44", "20160210153822");
			build_id_list.Add("43", "20160105164030");
			build_id_list.Add("42", "20151029151421");
			build_id_list.Add("41", "20151014143721");
			build_id_list.Add("40", "20150812163655");
			build_id_list.Add("39", "20150618135210");
			build_id_list.Add("38", "20150513174244");


			string rv = ZennoLab.Macros.TextProcessing.Spintax("{38|39|40|41|42|43|44|45|46|47|48|49|50|51|52|53}");
			string win = ZennoLab.Macros.TextProcessing.Spintax("{6.1|6.3|10.0}");
			string platform = ZennoLab.Macros.TextProcessing.Spintax("{Win32|Win64}");

			string wow = string.Empty;
			if(platform=="Win32"){
				if(int.Parse(rv)>=42){
					wow = ZennoLab.Macros.TextProcessing.Spintax("{; WOW64|}");
				}
			}else{
				wow = "; Win64; x64";
			}


			project.Profile.UserAgent = string.Format("Mozilla/5.0 (Windows NT {0}{1}; rv:{2}.0) Gecko/20100101 Firefox/{2}.0", win, wow, rv);
			project.Profile.UserAgentOsCpu = "Windows NT "+win+wow;
			project.Profile.UserAgentPlatform = platform;

			string accept_lang = ZennoLab.Macros.TextProcessing.Spintax("{ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4|ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3}");
			//string accept_lang = Macros.TextProcessing.Spintax("{en-US,en;q=0.8,en-US;q=0.6,en;q=0.4|en-US,en;q=0.8,en-US;q=0.5,en;q=0.3}");
			string lang = accept_lang.Substring(0, accept_lang.IndexOf(','));

			project.Profile.AcceptLanguage = accept_lang;
			project.Profile.UserAgentBrowserLanguage = lang;
			project.Profile.UserAgentLanguage = lang;

			int [,] monitor_size = {{1366, 768},{1280, 1024},{1024, 768},{2880, 1800},{2560, 1600},{2560, 1440},{1920, 1200},
			    {1920, 1080},{1680, 1050},{1600, 1200},{1600, 900},{1440, 900},{1366, 768},{1360, 768},{1280, 1024},{1280, 800},
				{1280, 768},{1152, 864},{1080, 1920},{1024, 768},{4096, 3072},{4096, 2160},{4096, 1716},{3996, 2160},{3840, 2400},
			    {3840, 2160},{3656, 2664},{3440, 1440},{3280, 2048},{3200, 2400},{3200, 2048},{3200, 1800},{2880, 1800},{2560, 2048},
			    {2560, 1600},{2560, 1440},{2560, 1080},{2048, 1536},{2048, 1152},{2048, 1080},{1920, 1440},{1920, 1200},{1920, 1080},
			    {1768, 992},{1680, 1050},{1600, 1200},{1600, 1024},{1600, 900},{1536, 1024},{1536, 960},{1440, 1080},{1440, 1050},
			    {1440, 980},{1440, 900},{1366, 768},{1360, 768},{1280, 1024},{1280, 960},{1280, 800},{1280, 768},{1280, 720},
			    {1200, 600},{1176, 664},{1152, 864},{1080, 1920},{2880, 1800},{2560, 1600},{2560, 1440},{1920, 1200},{1920, 1080},
			    {1680, 1050},{1600, 1200},{1600, 900},{1440, 900},{1366, 768},{1360, 768},{1280, 1024},{1280, 800},{1280, 768},
			    {1152, 864},{1080, 1920},{1024, 768},{1280, 800},{1600, 900},{1920, 1080}
			};

			Random rnd = new Random();
			int index = rnd.Next(monitor_size.Length/2);

			project.Profile.ScreenSizeWidth = monitor_size[index, 0];
			project.Profile.ScreenSizeHeight = monitor_size[index, 1];

			int task_panel_height = int.Parse(ZennoLab.Macros.TextProcessing.Spintax("{0|40|40}"));

			project.Profile.AvailScreenWidth = monitor_size[index, 0];
			project.Profile.AvailScreenHeight = monitor_size[index, 1]-task_panel_height;
		}		
	}
}