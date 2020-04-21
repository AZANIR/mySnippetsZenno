http://zennolab.com/discussion/threads/besplatnye-snipety-na-zakaz.23450/

//����� ���������� ��������� ��� �������� �� ����������
var parserRegexPattern = project.Variables["tableSearchRegex"].Value;
var parserRegex = new System.Text.RegularExpressions.Regex(parserRegexPattern);
// �������� �������, � ������� ����� ������
var sourceTable = project.Tables["SourceTable"];
// �������� �������, � ������� ����� ������
var destTable = project.Tables["OutputTable"];
// ���� � ������ ������� � �������
for(int i=0; i < sourceTable.RowCount; i++)
{
// ������ ������ �� ������� (��� ����� ������ �����)
var cells = sourceTable.GetRow(i).ToArray();
// ��������� ������ ������ ���������� ����������, ���� ���� ���������� ������ ��������� �� ������ �������
if (parserRegex.IsMatch(cells[0]))
destTable.AddRow(cells);
}