try{

//��� ���� ���

}
   catch(Exception expr)
   {
    project.SendErrorToLog("���������� captcha: " + ������������_����������.Value, true);
    project.SendErrorToLog("���������� ��� ��������� ����� ����� ��������� � ���������! " + expr.Message, true);
    if(null != expr.InnerException)
     project.SendErrorToLog("���������� ��� ��������� ����� ����� ��������� � ��������� (����������)! " + expr.InnerException.Message, true);
    Console.Beep(1100, 50); //�������, ������������
    Console.Beep(1000, 50); //frequency, length  
    return null;
   }
   