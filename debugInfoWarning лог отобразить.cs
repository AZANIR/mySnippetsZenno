//������� ��� ����������, �� ������ � PM
project.SendInfoToLog(project.Variables["Count_steam_info"].Value +" ���������� �������������� ������� ������ ����������...", false);

//��������������, �� ������ � PM
project.SendWarningToLog(project.Variables["Count_steam_info"].Value +" ��������� ����� �� ���������� ���� � " + project.Variables["Input_captcha_fail"].Value + ", �������� � ����������:", false);

//������, �� ������ � PM
project.SendErrorToLog(project.Variables["Count_steam_info"].Value +" �� ��������� ���� �� ������ project.Variables[\"proxy\"].Value " + project.Variables["proxy"].Value  + "...", false);

//��� ������������� ���������� ��������� � ZP, � ����� ������ ���� ������ true ������ false