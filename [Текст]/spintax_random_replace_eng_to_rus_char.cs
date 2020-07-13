//get text from variable message and replace random char english to russian
string text = project.Variables["message"].Value
    .Replace("a","{a|а}")
    .Replace("B","{B|В}")
    .Replace("E","{E|Е}")
    .Replace("e","{e|е}")
    .Replace("K","{K|К}")
    .Replace("M","{M|М}")
    .Replace("H","{H|Н}")
    .Replace("o","{o|о}")
    .Replace("O","{O|О}")
    .Replace("p","{p|р}")
    .Replace("c","{c|с}")
    .Replace("T","{T|Т}")
    .Replace("y","{y|у}")
    .Replace("P","{P|Р}")
    .Replace("x","{x|х}")
    .Replace("C","{C|С}")
    .Replace("X","{X|Х}");
	
project.Variables["message"].Value = Macros.TextProcessing.Spintax(text, true);