http://zennolab.com/discussion/threads/shifrovanie-i-rasshifrovaka-fajla.21191/#post-140147

string AesIV256 = @"qwertyuiopasdfgh"; //16 СИМВОЛОВ
string AesKey256 = @"asdfghjjkkliorcvbvbmmsadefasdfas"; //32 СИМВОЛА
 
Func<string, string> Encrypt256 = (string text) => {
    // AesCryptoServiceProvider
    var aes = new System.Security.Cryptography.AesCryptoServiceProvider();        
    aes.BlockSize = 128;
    aes.KeySize = 256;
    aes.IV = Encoding.UTF8.GetBytes(AesIV256);
    aes.Key = Encoding.UTF8.GetBytes(AesKey256);
    aes.Mode = System.Security.Cryptography.CipherMode.CBC;
    aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
 
    // Convert string to byte array
    byte[] src = Encoding.Unicode.GetBytes(text);
 
    // encryption
    using (var encrypt = aes.CreateEncryptor())
    {
        byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
 
        // Convert byte array to Base64 strings
        return Convert.ToBase64String(dest);
    }
};
Func<string, string> Decrypt256 = (string text) => {
    var aes = new System.Security.Cryptography.AesCryptoServiceProvider();
    aes.BlockSize = 128;
    aes.KeySize = 256;
    aes.IV = Encoding.UTF8.GetBytes(AesIV256);
    aes.Key = Encoding.UTF8.GetBytes(AesKey256);
    aes.Mode = System.Security.Cryptography.CipherMode.CBC;
    aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
 
    // Convert Base64 strings to byte array
    byte[] src = System.Convert.FromBase64String(text);
 
    // decryption
    using (var decrypt = aes.CreateDecryptor())
    {
        byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
        return Encoding.Unicode.GetString(dest);
    }
};
 
var text1 = "секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет секретный секрет";
return Decrypt256(Encrypt256(text1));
