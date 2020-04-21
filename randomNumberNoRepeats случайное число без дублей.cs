//http://zennolab.com/discussion/threads/randomnye-ne-povtorjajuschiesja-chisla.9869/#post-115551

// получаем массив
string value = project.Variables["array"].Value;
int n = Convert.ToInt32(project.Variables["max"].Value.Trim());
List<int> array = new List<int>();
if (!String.IsNullOrWhiteSpace(value))
{
    string[] split = value.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries);
    foreach (string str in split) array.Add(Convert.ToInt32(str.Trim()));
}
 
// генерируем значение
var rnd = new Random();
 
for(int i=0;i<n;i++)
{
    int next = rnd.Next(Convert.ToInt32(project.Variables["min"].Value.Trim()), Convert.ToInt32(project.Variables["max"].Value.Trim()));
    if (!array.Contains(next))
    {
        // добавим значение
        array.Add(next);
        // запомним в массиве
        project.Variables["array"].Value = String.Join(";", array);
        // вернём результат
        return next;
    }
}