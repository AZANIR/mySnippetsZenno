//http://zennolab.com/discussion/threads/kak-zapustit-konsolnoe-prilozhenie-v-fone.13560/#post-81190

ProcessStartInfo startInfo = new ProcessStartInfo();
startInfo.FileName = "file.exe";
//—крыть окно приложени¤
startInfo.WindowStyle = ProcessWindowStyle.Hidden;
Process process = new Process();
process.StartInfo = startInfo;
//process.StartInfo.Arguments="arg1 arg2";
process.Start();
process.WaitForExit();
