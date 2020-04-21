// �������� ������, � ������� ����� ������
var sourceList = project.Lists["������"];
int removedItemsCount = 0;

// ���� � ������ ������� � ������
lock(SyncObjects.ListSyncer)
{
    for(int i=0; i < sourceList.Count; i++)
    {
        // ������ ������ �� ������
        var str = sourceList[i];
        // ��������� ���������� ������ � ������, ���� ���� ���������� ���������� "yes"

		string regex = @"\b[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b";
		var reg = new System.Text.RegularExpressions.Regex(regex,  System.Text.RegularExpressions.RegexOptions.None);
		if (reg.Matches(str).Count>0)
		{
			project.SendInfoToLog("������� ������ " + str + " �� ������� " + i, false);			
			sourceList.RemoveAt(i); //������� �������
			i--; //��������� �������, ����� ��������� ����� ������� �� ������ �����
			removedItemsCount++;
		}
    }
}
// ���������� ���������� �������� ���������
return removedItemsCount;