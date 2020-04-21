//http://zennolab.com/discussion/threads/ftp-zalivka-fajlov-cherez-c.14372/
//make sure you use \\ instead of \ in local path
ZennoPoster.FtpUploadDirectory(project.Variables["ftphost"].Value, 21, "FTP", project.Variables["ftpusername"].Value, project.Variables["passacc"].Value, "", project.Variables["destination"].Value, project.Variables["sourcepath"].Value, true, false);
