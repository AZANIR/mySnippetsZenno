string input = "text";

using (System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed())
{
    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
    var sb = new StringBuilder(hash.Length * 2);

    foreach (byte b in hash)
    {
        // can be "x2" if you want lowercase
        sb.Append(b.ToString("X2"));
    }

    return sb.ToString();
}