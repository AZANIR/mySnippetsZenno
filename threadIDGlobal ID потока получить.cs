//создайте глобальную переменную "Inviter","Count_steam_INFO"
//и поместите этот сниппет в начало проекта. Каждый новый поток получит собственный ID
//потом при многопоточной работе каждый поток перед своими сообщениями сможет указывать свой ID

lock(SyncObject) {
int globalCountStream = Convert.ToInt32(project.GlobalVariables["Inviter","Count_steam_INFO"].Value.ToString());
project.GlobalVariables["Inviter","Count_stream_INFO"].Value = globalCountStream + 1;
//project.SendInfoToLog("project.GetHashCode()=" + project.GetHashCode().ToString() + 
//" this.GetHashCode().ToString()="+  this.GetHashCode().ToString(), false);
project.Variables["Count_stream_info"].Value=
//project.GetHashCode().ToString() + "|"+  this.GetHashCode().ToString() + "|" +
 project.GlobalVariables["Inviter","Count_stream_INFO"].Value.ToString() + " ";
}
