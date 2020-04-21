public static string MysqlUploadProfile(Instance instance, IZennoPosterProjectModel project, string email, string filename)
		{
			MySqlConnection con = new MySqlConnection(connect_to_BD_zN24);
			FileStream fs;  
    		BinaryReader br;
			MySqlCommand cmd;
			try
			{
				byte[] ProfileData;
				fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				br = new BinaryReader(fs);
				ProfileData = br.ReadBytes((int)fs.Length);
				br.Close();  
            	fs.Close();
                string CmdString = "UPDATE `admin_zenno`.`emails` SET `f_profile`= @f_profile WHERE `email`=\'"+email+"\' LIMIT 1;";
				cmd = new MySqlCommand(CmdString, con);
				cmd.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = email;
                cmd.Parameters.Add("@f_profile", MySqlDbType.Blob).Value = ProfileData;
				con.Open();
				int RowsAffected = cmd.ExecuteNonQuery();
				if (RowsAffected > 0)
				{
					project.SendWarningToLog("Profile saved sucessfully!", true);
				}
				con.Close();
			}
			catch { project.SendWarningToLog("Profile not saved!", true); }
			return "mysqlUploader done!";
		}