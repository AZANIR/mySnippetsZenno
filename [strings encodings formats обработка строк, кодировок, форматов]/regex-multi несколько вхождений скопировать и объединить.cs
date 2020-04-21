var data = project.Variables["nomer2"].Value;
Regex regex = new Regex(project.Variables["regex2"].Value);
var matchesList = (from Match m in regex.Matches(data) select m.Value).ToList();
var vihod = String.Join("\n", matchesList.ToArray());
var matchesList1 = (from Match m in regex.Matches(vihod) select m.Value).ToList();
var blabla = String.Join("\n", matchesList1.ToArray());
return blabla;
