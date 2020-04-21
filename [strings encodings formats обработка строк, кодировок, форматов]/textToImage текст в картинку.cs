// http://zennolab.com/discussion/threads/pomogite-adaptirovat-kod-na-c-pod-zenno.24233/

//�������� ��������� using
//using System.Drawing;
//using System.Drawing.Text;
//using System.Drawing.Drawing2D;

var imageText = "imageText"; // �����
 
Bitmap bitmap = new Bitmap(1, 1);
 
int width = 0;
int height = 0;
 
// ������� ������ Font ��� "���������" �� ������.
Font font = new Font("Arial", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
 
// ������� ������ Graphics ��� ���������� ������ � ������ ������.
Graphics graphics = Graphics.FromImage(bitmap);
 
// ����������� �������� �����������.
width = (int)graphics.MeasureString(imageText, font).Width;
height = (int)graphics.MeasureString(imageText, font).Height;
 
// ����������� ������ Bitmap � ������������������� ��������� ��� ����� � �����.
bitmap = new Bitmap(bitmap, new Size(width, height));
 
// ����������� ������ Graphics
graphics = Graphics.FromImage(bitmap);
 
// ������ ���� ����.
graphics.Clear(Color.White);
// ������ ��������� ����-���������
graphics.SmoothingMode = SmoothingMode.AntiAlias;
graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
// ����� (������) �����
graphics.DrawString(imageText, font, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
graphics.Flush();
 
bitmap.Save(@"C:\image.jpg"); // ���� ��� ���������� ���������� ��������
 
bitmap.Dispose();

