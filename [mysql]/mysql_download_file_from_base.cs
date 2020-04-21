public static void MysqlLoadProfile(Instance instance, IZennoPosterProjectModel project, string email)
        {
			MySqlConnection con = new MySqlConnection(connect_to_BD_zN24);
            MySqlCommand cmd;
            string CmdString = "SELECT email, f_profile FROM emails WHERE email = \'" + email + "\' LIMIT 1;";
            cmd = new MySqlCommand(CmdString, con);
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 20).Value = email;
            con.Open();
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                
                string filename = myReader.GetString(0);
                byte[] data = (byte[])myReader.GetValue(1);
                using (System.IO.FileStream fs = new System.IO.FileStream(project.Directory+"/profiles/"+filename+".zpprofile", FileMode.OpenOrCreate))
                {
                    fs.Write(data, 0, data.Length);
                    Console.WriteLine("Изображение '{0}' сохранено", filename);
                    fs.Close();
                }
            }
            myReader.Close();
            con.Close();
        }