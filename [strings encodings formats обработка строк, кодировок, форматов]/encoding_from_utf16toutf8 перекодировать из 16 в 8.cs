//входная строка - unicodeString
//результат возвращается из asciistring

string unicodeString = "\u041f\u043e\u0436\u0430\u043b\u0443\u0439\u0441\u0442\u0430,";
//string unicodeString = "This string contains the unicode character Pi (\u03a0)";

 
      // Create two different encodings.
      Encoding ascii = Encoding.UTF8;
      Encoding unicode = Encoding.Unicode;
 
      // Convert the string into a byte array.
      byte[] unicodeBytes = unicode.GetBytes(unicodeString);
 
      // Perform the conversion from one encoding to the other.
      byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
 
      // Convert the new byte[] into a char[] and then into a string.
      char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
      ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
      string asciiString = new string(asciiChars);
 
      // Display the strings created before and after the conversion.
	project.SendInfoToLog("Original string: " + unicodeString);
      	project.SendInfoToLog("Ascii converted string: {0}" + asciiString);
	return asciiString;
	
