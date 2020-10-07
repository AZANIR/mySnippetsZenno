//get text from variable message and replace random char  russian to english
string text = project.Variables["message"].Value
    .Replace("а","{a|а}")
    .Replace("В","{B|В}")
    .Replace("Е","{E|Е}")
    .Replace("е","{е|e}")
    .Replace("К","{K|К}")
    .Replace("М","{M|М}")
    .Replace("Н","{Н|H}")
    .Replace("о","{o|о}")
    .Replace("О","{O|О}")
    .Replace("р","{p|р}")
    .Replace("с","{с|c}")
    .Replace("Т","{Т|T}")
    .Replace("у","{y|у}")
    .Replace("Р","{Р|P}")
    .Replace("х","{x|х}")
    .Replace("С","{С|C}")
    .Replace("Х","{Х|X}");
	
project.Variables["message"].Value = Macros.TextProcessing.Spintax(text, true);