//������ ��� ����������� ����� ����������, ������������ ������, � s ����� ������ ���������� ����� (� ���.) �� �������� ����, ������� � ���� startime.


int s = (int)(DateTime.Now.Subtract(new DateTime(2016, 01, 21, 20, 01, 00))).TotalSeconds;
//������ ���� � �������, ���� �������� ���������� startime, ������� ���������� ��������� �������

return DateTime.Now.ToString("yyyy, MM, dd, HH, mm, ss");

